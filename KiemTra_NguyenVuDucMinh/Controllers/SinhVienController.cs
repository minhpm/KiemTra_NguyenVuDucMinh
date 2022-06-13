using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenVuDucMinh.Models;

namespace KiemTra_NguyenVuDucMinh.Controllers
{
    public class SinhVienController : Controller
    {
        Model1 data = new Model1(); 
        // GET: SinhVien
        public ActionResult ListSV()
        {
            var all_sinhvien = from ss in data.SinhViens select ss;
            return View(all_sinhvien);
        }
        public ActionResult Details(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];

            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.HoTen = hoten.ToString();
                s.GioiTinh = gioitinh.ToString();
                s.NgaySinh = DateTime.Parse(ngaysinh);
                s.Hinh = hinh.ToString();
                s.MaNganh = manganh.ToString();
                data.SinhViens.Add(s);
                data.SaveChanges();
                return RedirectToAction("ListSV");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var sinhVien = data.SinhViens.First(x => x.MaSV == id);
            return View(sinhVien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var masv = data.SinhViens.First(x => x.MaSV == id);
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];
            masv.MaSV = id;
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                masv.HoTen = hoten.ToString();
                masv.GioiTinh = gioitinh.ToString();
                masv.NgaySinh = DateTime.Parse(ngaysinh);
                masv.Hinh = hinh.ToString();
                masv.MaNganh = manganh.ToString();
                UpdateModel(masv);
                data.SaveChanges();
                return RedirectToAction("ListSV");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(string id)
        {
            var sinhvien = data.SinhViens.First(x => x.MaSV == id);
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var sinhvien = data.SinhViens.Where(x => x.MaSV == id).First();
            data.SinhViens.Remove(sinhvien);
            data.SaveChanges();
            return RedirectToAction("ListSV");
        }

        //---Get link image---
        public String ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }


    }
}