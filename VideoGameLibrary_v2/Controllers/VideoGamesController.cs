using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameLibrary_v2.CustomAttribute;
using VideoGameLibrary_v2.Models;

namespace VideoGameLibrary_v2.Controllers
{
    public class VideoGamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Index(string sortOrder, int? page)
        {
            ApplicationDbContext dbLocal = new ApplicationDbContext();

            // create a distinct list of years for the years filter
            ViewBag.Years = ListOfYears();

            // return the data context as an enumerable
            IEnumerable<VideoGame> videoGames;
            using (dbLocal)
            {
                videoGames = dbLocal.VideoGames.ToList() as IList<VideoGame>;
            }

            // sort by name unless posted as a new sort
            // *Note* don't need .ToList() ?... videoGames = videoGames.ToList().OrderBy(v => v.ReleaseDate);
            switch (sortOrder)
            {
                case "ReleaseDate":
                    videoGames = videoGames.OrderBy(v => v.ReleaseYear);
                    break;
                default:
                    videoGames = videoGames.OrderBy(v => v.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            videoGames = videoGames.ToPagedList(pageNumber, pageSize);

            return View(videoGames);
        }

        [HttpPost]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Index(string searchCriteria, string yearFilter, int? page)
        {
            ApplicationDbContext dbLocal = new ApplicationDbContext();

            // create a distinct list of years for the years filter
            ViewBag.Years = ListOfYears();

            // return the data context as an enumerable
            IEnumerable<VideoGame> videoGames;
            using (dbLocal)
            {
                videoGames = dbLocal.VideoGames.ToList() as IList<VideoGame>;
            }

            // if posted with a search on video game name
            if (searchCriteria != null)
            {
                videoGames = videoGames.Where(v => v.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            // if posted with a filter on release year
            if (yearFilter != "" || yearFilter == null)
            {
                videoGames = videoGames.Where(v => v.ReleaseYear == yearFilter);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            videoGames = videoGames.ToPagedList(pageNumber, pageSize);

            return View(videoGames);
        }

        [NonAction]
        private IEnumerable<string> ListOfYears()
        {
            ApplicationDbContext dbLocal = new ApplicationDbContext();

            // return the data context as an enumerable
            IEnumerable<VideoGame> videoGames;
            using (dbLocal)
            {
                videoGames = dbLocal.VideoGames.ToList() as IList<VideoGame>;
            }

            // get a distinct list of years
            var years = videoGames.Select(v => v.ReleaseYear).Distinct().OrderBy(x => x);

            return years;
        }

        // GET: VideoGames/Details/5
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // GET: VideoGames/Create
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,ReleaseDate,ReleaseYear,Developer,Publisher,YouTubeEmbedLink")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.VideoGames.Add(videoGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,ReleaseDate,ReleaseYear,Developer,Publisher,YouTubeEmbedLink")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Site Admin,Video Game Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
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
