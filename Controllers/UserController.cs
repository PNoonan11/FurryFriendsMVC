using FurryFriendsMVC.Data;
using FurryFriendsMVC.Models.User;
using FurryFriendsMVC.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace FurryFriendsMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ApplicationDbContext _DbContext;
        public UserController(IUserServices userServices, ApplicationDbContext dbContext)
        {
            _userServices = userServices;
            _DbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<UserListItem> users = await _userServices.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _userServices.CreateUserAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            UserDetail user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
                return RedirectToAction(nameof(Index));
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            UserEntity user = await _DbContext.User.FindAsync(id);
            if (user == null)
                return RedirectToAction(nameof(Index));

            UserEdit userEdit = new UserEdit()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PetType = (Models.User.PetTypes)user.PetType,
                BreedId = (Models.User.Breeds)user.BreedId,
                Bio = user.Bio,
                Size = user.Size,
                CityID = (Models.User.CityNames)user.CityID

            };
            return View(userEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserEdit userEdit)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            bool hasUpdated = await _userServices.EditUsersAsync(userEdit);
            if (!hasUpdated)
                return View(userEdit);
            return RedirectToAction(nameof(Detail), new
            {
                id = userEdit.Id
            });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            UserDetail user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
                return RedirectToAction(nameof(Index));
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, UserDetail model)
        {
            bool wasDeleted = await _userServices.DeleteUser(model.Id);
            if (!wasDeleted)
                // _DbContext.User.Remove(model);   
                await _DbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}