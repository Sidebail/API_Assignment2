using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        // db
        private ProjectModel db;

        public ReviewsController(ProjectModel db)
        {
            this.db = db;
        }

        // GET: api/reviews
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return db.Reviews.OrderBy(a => a.review_name).ToList();
        }

        // GET: api/reviews/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Review review = db.Reviews.Find(id);

            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST: api/reviews
        [HttpPost]
        public ActionResult Post([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reviews.Add(review);
            db.SaveChanges();
            return CreatedAtAction("Post", review);
        }

        // PUT: api/reviews/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/reviews/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Review review = db.Reviews.Find(id);

            if (review == null)
            {
                return NotFound();
            }

            db.Reviews.Remove(review);
            db.SaveChanges();
            return Ok();
        }
    }
}
