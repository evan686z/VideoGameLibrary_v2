using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameLibrary_v2.Models;

namespace VideoGameLibrary_v2.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            return View(BuildVideoGameReviewViewModelList(db.Reviews.ToList()));
        }

        // GET: Reviews/Details/5
        public ActionResult Details([Bind(Include ="DateCreated,Content,VideoGameName")]int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            VideoGameReviewViewModel videoGameReviewViewModel = BuildVideoGameReviewViewModel(review);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(videoGameReviewViewModel);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            // generate select list with ids for video games dropdown
            var videoGameList = db.VideoGames.Select(v => v);
            ViewBag.SelectVideoGameList = new SelectList(videoGameList, "Id", "Name");

            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateCreated,Content,VideoGameId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            // generate select list with ids for video games dropdown
            var videoGameList = db.VideoGames.Select(v => v);
            ViewBag.SelectVideoGameList = new SelectList(videoGameList, "Id", "Name");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            VideoGameReviewViewModel videoGameReviewViewModel = BuildVideoGameReviewViewModel(review);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(videoGameReviewViewModel);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateCreated,Content,VideoGameId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            VideoGameReviewViewModel videoGameReviewViewModel = BuildVideoGameReviewViewModel(review);
            return View(videoGameReviewViewModel);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            VideoGameReviewViewModel videoGameReviewViewModel = BuildVideoGameReviewViewModel(review);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(videoGameReviewViewModel);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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

        [NonAction]
        private VideoGameReviewViewModel BuildVideoGameReviewViewModel(Review review)
        {
            // generate a dictionary with video game ids and names for lookup
            var videoGameNames = db.VideoGames.ToDictionary(v => v.Id, v => v.Name);

            return new VideoGameReviewViewModel()
            {
                Id = review.Id,
                DateCreated = review.DateCreated,
                Content = review.Content,
                VideoGameId = review.Id,
                VideoGameName = videoGameNames[review.VideoGameId]
            };
        }

        [NonAction]
        private List<VideoGameReviewViewModel> BuildVideoGameReviewViewModelList(List<Review> reviews)
        {
            List<VideoGameReviewViewModel> videoGameReviewsViewModel = new List<VideoGameReviewViewModel>();

            // generate a dictionary with video game ids and name for lookup
            var videoGameNames = db.VideoGames.ToDictionary(v => v.Id, v => v.Name);

            foreach (var videoGameReview in reviews)
            {
                videoGameReviewsViewModel.Add(new VideoGameReviewViewModel
                {
                    Id = videoGameReview.Id,
                    DateCreated = videoGameReview.DateCreated,
                    Content = videoGameReview.Content,
                    VideoGameId = videoGameReview.VideoGameId,
                    VideoGameName = videoGameNames[videoGameReview.VideoGameId]
                });
            }
            return videoGameReviewsViewModel;
        }

        public ActionResult ListOfReviewsByVideoGame(int id)
        {
            var videoGameReviews = db.Reviews.Where(r => r.VideoGameId == id).ToList();

            // get video Game to pass
            var videoGame = db.VideoGames.FirstOrDefault(v => v.Id == id);
            ViewBag.VideoGame = videoGame;

            if (videoGame != null)
            {
                return View(videoGameReviews);
            }
            else
            {
                // redirect to error page with error message
                ViewBag.ErrorMessage = "Video Game not found.";
                return View("Index");
            }
        }

    }
}
