using FurryFriendsMVC.Data;
using FurryFriendsMVC.Models.Post;
using FurryFriendsMVC.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace FurryFriendsMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostServices _postServices;
        private readonly ApplicationDbContext _DbContext;


        public PostController(IPostServices postServices, ApplicationDbContext dbContext)
        {
            _postServices = postServices;
            _DbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PostListItem> posts = await _postServices.GetAllPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _postServices.CreatePostAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            PostDetail post = await _postServices.GetPostByIdAsync(id);
            if (post == null)
                return RedirectToAction(nameof(Index));
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            PostEntity post = await _DbContext.Post.FindAsync(id);
            if (post == null)
                return RedirectToAction(nameof(Index));

            PostEdit postEdit = new PostEdit()
            {
                Id = post.Id,
                Text = post.Text,
                DateTimeUpdated = DateTime.Now
            };
            return View(postEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostEdit postEdit)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            bool hasUpdated = await _postServices.EditPostAsync(postEdit);
            if (!hasUpdated)
                return View(postEdit);
            return RedirectToAction(nameof(Detail), new
            {
                id = postEdit.Id
            });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            PostDetail post = await _postServices.GetPostByIdAsync(id);
            if (post == null)
                return RedirectToAction(nameof(Index));
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PostDetail model)
        {
            bool wasDeleted = await _postServices.DeletePost(model.Id);
            if (!wasDeleted)
                //_DbContext.Post.Remove(post);   Need to figure this out
                await _DbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}