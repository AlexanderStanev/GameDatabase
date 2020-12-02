namespace GamesDatabase.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using GamesDatabase.Data;
    using GamesDatabase.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ReviewsController : BaseController
    {
        private readonly GamesDatabaseContext context;

        public ReviewsController(GamesDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gamesDatabaseContext = this.context.Reviews.Include(r => r.Author).Include(r => r.Game);
            return this.View(await gamesDatabaseContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await context.Reviews
                .Include(r => r.Author)
                .Include(r => r.Game)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(context.ApplicationUsers, "Id", "Id");
            ViewData["GameId"] = new SelectList(context.Games, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,AuthorId,Rating,Title,Content,CreatedOn,EditedOn,Id")] Review review)
        {
            if (ModelState.IsValid)
            {
                context.Add(review);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(context.ApplicationUsers, "Id", "Id", review.AuthorId);
            ViewData["GameId"] = new SelectList(context.Games, "Id", "Id", review.GameId);
            return View(review);
        }

        // GET: Administration/Reviews/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(context.ApplicationUsers, "Id", "Id", review.AuthorId);
            ViewData["GameId"] = new SelectList(context.Games, "Id", "Id", review.GameId);
            return View(review);
        }

        // POST: Administration/Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,AuthorId,Rating,Title,Content,CreatedOn,EditedOn,Id")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(review);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(context.ApplicationUsers, "Id", "Id", review.AuthorId);
            ViewData["GameId"] = new SelectList(context.Games, "Id", "Id", review.GameId);
            return View(review);
        }

        // GET: Administration/Reviews/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await context.Reviews
                .Include(r => r.Author)
                .Include(r => r.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Administration/Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var review = await context.Reviews.FindAsync(id);
            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return context.Reviews.Any(e => e.Id == id);
        }
    }
}
