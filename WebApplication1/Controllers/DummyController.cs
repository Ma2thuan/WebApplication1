using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DummyController : Controller
    {
        private QLBanHangQuanAoEntities db = new QLBanHangQuanAoEntities();
        // GET: Dummy

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index(int? page)
        //{
        //    ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");

        //    int pageSize = 4;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    //var ListSanPham = db.SanPhams.ToList();
        //    var listSanPham = db.SanPhams.AsNoTracking().OrderBy(x => x.TenSanPham);

        //    PagedList<SanPham> list = new PagedList<SanPham>(listSanPham, pageNumber, pageSize);

        //    return View(list);
        //}

        public ActionResult RenderNavProductType()
        {
            List<PhanLoaiPhu> listLoai = db.PhanLoaiPhus.ToList();

            return PartialView("ProductType", listLoai);
        }


        public ActionResult RenderProduct()
        {
            List<SanPham> listHangHoa = db.SanPhams.ToList();

            // Nếu cần điều kiện thì như sau:
            // List<SanPham> listHangHoa = db.SanPhams.Where(a => a.GiaNhap > 50000).ToList();
            return PartialView("MainContent", listHangHoa);
        }


        public ActionResult RenderProductByCatId(int CatId)
        {
            //List<SanPham> listSanPham = db.SanPhams.Where(a =>a.MaPhanLoai.Contains(CatId.ToString())).ToList();

            string id = CatId.ToString();

            List<SanPham> listSanPham = db.SanPhams.Where(a => a.MaPhanLoaiPhu.Contains(id)).ToList();

            return PartialView("MainContent", listSanPham);
        }


        public ActionResult Create()
        {
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return Redirect("Index");
        }
        //public ActionResult Index(int? page , int? MaPhanLoai)
        //{
        //    var listSanPham = db.SanPhams.Include(a => a.PhanLoai);


        //    ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");

        //    int pageSize = 4;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    //var ListSanPham = db.SanPhams.ToList();

        //    // Filter based on the selected kind of product
        //    if (MaPhanLoai.HasValue && MaPhanLoai.Value > 0)
        //    {
        //        listSanPham = listSanPham.Where(x => x.MaPhanLoai);
        //    }

        //    listSanPham = listSanPham.OrderBy(x => x.TenSanPham);

        //    PagedList<SanPham> list = new PagedList<SanPham>(listSanPham, pageNumber, pageSize);

        //    return View(list);
        //}

    }
}