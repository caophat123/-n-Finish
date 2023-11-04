using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnPC.Models;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace DoAnPC.Controllers
{
    public class ProductsController : Controller
    {
        private LoginEntities2 db = new LoginEntities2();


        // GET: Products
       
            public ActionResult ProductList(string SearchString)
            {   // SearchString : tên sản phẩm cần tìm
                var products = db.Pro.Include(p => p.Category1);
                //Tìm kiếm chuỗi truy vấn theo NamePro, nếu chuỗi truy vấn SearchString khác rỗng, null
                if (!String.IsNullOrEmpty(SearchString))
                {
                    products = products.Where(s => s.NamePro.Contains(SearchString));
                }
                return View(products.ToList());
            }

        








        // GET: Products
        public ActionResult Index()
        {
            var products = db.Pro.Include(p => p.Category1);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Pro.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Category, "IDCate", "NameCate");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,NamePro,DecriptionPro,Category,Price,ImagePro")] Products Products, HttpPostedFileBase ImagePro)
        {
            if (ModelState.IsValid)
            {
                if (ImagePro != null)
                {
                    //Lấy tên file của hình được up lên

                    var fileName = Path.GetFileName(ImagePro.FileName);

                    //Tạo đường dẫn tới file

                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    //Lưu tên

                    Products.ImagePro = fileName;
                    //Save vào Images Folder
                    ImagePro.SaveAs(path);

                }
                db.Pro.Add(Products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Category, "IDCate", "NameCate", Products.Category);
            return View(Products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products proDucts = db.Pro.Find(id);
            if (proDucts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.Category, "IDCate", "NameCate", proDucts.Category);
            return View(proDucts);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,NamePro,DecriptionPro,Category,Price,ImagePro")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Category, "IDCate", "NameCate", products.Category);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products proDucts = db.Pro.Find(id);
            if (proDucts == null)
            {
                return HttpNotFound();
            }
            return View(proDucts);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products proDucts = db.Pro.Find(id);
            db.Pro.Remove(proDucts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
