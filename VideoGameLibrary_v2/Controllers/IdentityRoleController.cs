using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameLibrary_v2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using System.Data.Entity;
using VideoGameLibrary_v2.CustomAttribute;

namespace VideoGameLibrary_v2.Controllers
{
    public class IdentityRoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdentityRole
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: IdentityRole/Details
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET IdentityRole/Create
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndentityRole/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Create([Bind(Include = "Id,Name")]IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET IdentityRole/Edit
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        // POST IdentityRole/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name")]IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET IndentityRole/Delete
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                HttpNotFound();
            }

            return View(role);
        }

        // POST IdentityRole/DeleteConfirm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin")]
        public ActionResult DeleteConfirm(string id)
        {
            IdentityRole identityRoleTemp = db.Roles.Find(id);
            db.Roles.Remove(identityRoleTemp);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}