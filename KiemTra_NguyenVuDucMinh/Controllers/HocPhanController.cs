using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenVuDucMinh.Models;

namespace KiemTra_NguyenVuDucMinh.Controllers
{
    public class HocPhanController : Controller
    {
        Model1 data = new Model1();
        // GET: HocPhan
        public ActionResult listHP()
        {
            var all_hocphan = from ss in data.HocPhans select ss;
            return View(all_hocphan);
        }

        public ActionResult HocPhan()
        {
            List<HocPhan> lstHocPhan = Layhocphan();
            ViewBag.Tongsoluong = TongHocPhan();
            ViewBag.Tongsoluongsanpham = TongSoLuongHocPhan();
            return View(lstHocPhan);
        }

        public List<HocPhan> Layhocphan()
        {
            List<HocPhan> lstHocPhan = Session["HocPhan"] as List<HocPhan>;
            if (lstHocPhan == null)
            {
                lstHocPhan = new List<HocPhan>();
                Session["Giohang"] = lstHocPhan;
            }
            return lstHocPhan;
        }

        //public ActionResult ThemHocPhan(string id, string strURL)
        //{
        //    List<HocPhan> lstHocPhan = Layhocphan();
        //    HocPhan monhoc = lstHocPhan.Find(n => n.MaHP == id);
        //    if (monhoc == null)
        //    {              
        //        monhoc = new HocPhan(id);
        //        lstHocPhan.Add(monhoc);
        //        return Redirect(strURL);
        //    }
        //    else
        //    {
        //        monhoc.iSoluong++;
        //        return Redirect(strURL);
        //    }
        //}
        private int TongHocPhan()
        {
            int tsl = 0;
            List<HocPhan> lstHocPhan = Session["HocPhan"] as List<HocPhan>;
            if (lstHocPhan != null)
            {
                tsl = lstHocPhan.Sum(n => n.iSoluong);
            }
            return tsl;
        }

        private int TongSoLuongHocPhan()
        {
            int tsl = 0;
            List<HocPhan> lstHocPhan = Session["HocPhan"] as List<HocPhan>;
            if (lstHocPhan != null)
            {
                tsl = lstHocPhan.Count;
            }
            return tsl;
        }

        public ActionResult HocPhanPartial()
        {
            ViewBag.Tongsoluong = TongHocPhan();
            ViewBag.Tongsoluongsanpham = TongSoLuongHocPhan();
            return PartialView();
        }

        public ActionResult XoaHocPhan(string id)
        {
            List<HocPhan> lstHocPhan = Layhocphan();
            HocPhan monhoc = lstHocPhan.SingleOrDefault(n => n.MaHP == id);
            if (monhoc != null)
            {
                lstHocPhan.RemoveAll(n => n.MaHP == id);
                return RedirectToAction("HocPhan");
            }
            return RedirectToAction("HocPhan");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<HocPhan> lstHocPhan = Layhocphan();
            lstHocPhan.Clear();
            return RedirectToAction("HocPhan");
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")

                return RedirectToAction("DangNhap", "NguoiDung");

            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Sach");
            }
            List<HocPhan> lstHocPhan = Layhocphan();
            ViewBag.Tongsoluong = TongHocPhan();
            ViewBag.Tongsoluongsanpham = TongSoLuongHocPhan();
            return View(lstHocPhan);
        }
        //public ActionResult DangKyHocPhan(FormCollection collection)
        //{
        //    HocPhan dh = new HocPhan();
        //    SinhVien kh = (SinhVien)Session["MSSV"];
        //    HocPhan s = new HocPhan();
        //    List<HocPhan> gh = Layhocphan();
        //    dh.MaHP = kh.MaSV;
        //    data.HocPhans.Add(dh);
        //    data.SaveChanges();
        //    foreach (var item in gh)
        //    {
        //        ChiTietDangKy cthp = new ChiTietDangKy();
        //        cthp.MaHP = dh.MaHP;
        //        cthp.MaDK = item.MaHP;
        //        cthp.gia = (decimal)item.giaban;
        //        s = data.Saches.Single(n => n.masach == item.masach);
        //        s.soluongton = ctdh.soluong;
        //        data.SaveChanges();
        //        data.HocPhans.Add(cthp);
        //    }
        //    data.SaveChanges();
        //    Session["HocPhan"] = null;
        //    return RedirectToAction("XacnhanHocphan", "HocPhan");
        //    //return RedirectToAction("Index", "Home");
        //}
    }
}