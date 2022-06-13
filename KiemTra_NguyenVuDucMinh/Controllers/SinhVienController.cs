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
        public ActionResult Details(int id)
        {
            var D_sinhvien = data.SinhViens.Where(m => Convert.ToInt32(m.MaSV) == id).First();
            return View(D_sinhvien);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_tensinhvien = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = Convert.ToInt32(collection["MaNganh"]);
            if (string.IsNullOrEmpty(E_tensinhvien))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.HoTen = E_tensinhvien.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh;
                s.MaNganh = E_manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Create();
        }
        //public ActionResult Edit(int id)
        //{
        //    var E_sach = data.SinhViens.First(m => m.masach == id);
        //    return View(E_sach);
        //}
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    var E_sach = data.SinhViens.First(m => m.masach == id);
        //    var E_tensach = collection["tensach"];
        //    var E_hinh = collection["hinh"];
        //    var E_giaban = Convert.ToDecimal(collection["giaban"]);
        //    var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
        //    var E_soluongton = Convert.ToInt32(collection["soluongton"]);
        //    E_sach.masach = id;
        //    if (string.IsNullOrEmpty(E_tensach))
        //    {
        //        ViewData["Error"] = "Don't empty!";
        //    }
        //    else if (!(E_soluongton >= 0))
        //    {
        //        ViewData["Error"] = "So luong phai it nhat phai la 1";

        //    }
        //    else
        //    {
        //        E_sach.tensach = E_tensach;
        //        E_sach.hinh = E_hinh;
        //        E_sach.giaban = E_giaban;
        //        E_sach.ngaycapnhat = E_ngaycapnhat;
        //        E_sach.soluongton = E_soluongton;
        //        UpdateModel(E_sach);
        //        data.SubmitChanges();
        //        return RedirectToAction("ListSach");
        //    }
        //    return this.Edit(id);
        //}
        ////-----------------------------------------
        //public ActionResult Delete(int id)
        //{
        //    var D_sach = data.Saches.First(m => m.masach == id);
        //    return View(D_sach);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    var D_sach = data.Saches.Where(m => m.masach == id).First();
        //    data.Saches.DeleteOnSubmit(D_sach);
        //    data.SubmitChanges();
        //    return RedirectToAction("ListSach");
        //}
        //public string ProcessUpload(HttpPostedFileBase file)
        //{
        //    if (file == null)
        //    {
        //        return "";
        //    }
        //    file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
        //    return "/Content/images/" + file.FileName;
        //}
    }
}