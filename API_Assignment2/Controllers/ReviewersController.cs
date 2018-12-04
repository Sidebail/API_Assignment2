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
    public class ReviewersController : ControllerBase
    {
        // db
        private ProjectModel db;

        public ReviewersController(ProjectModel db)
        {
            this.db = db;
        }

        // GET: api/reviewers
        [HttpGet]
        public IEnumerable<Reviewer> Get()
        {
            return db.Reviewers.OrderBy(a => a.reviewer_name).ToList();
        }

        // GET: api/reviewers/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Reviewer reviewer = db.Reviewers.Find(id);

            if (reviewer == null)
            {
                return NotFound();
            }
            return Ok(reviewer);
        }

        // POST: api/reviewers
        [HttpPost]
        public ActionResult Post([FromBody] Reviewer reviewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reviewers.Add(reviewer);
            db.SaveChanges();
            return CreatedAtAction("Post", reviewer);
        }

        // PUT: api/reviewers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Reviewer reviewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(reviewer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/reviewers/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Reviewer reviewer = db.Reviewers.Find(id);

            if (reviewer == null)
            {
                return NotFound();
            }

            db.Reviewers.Remove(reviewer);
            db.SaveChanges();
            return Ok();
        }
    }
}