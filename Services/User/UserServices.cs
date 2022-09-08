using FurryFriendsMVC.Data;
using FurryFriendsMVC.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FurryFriendsMVC.Services.User
{
    public class UserServices : IUserServices
    {

        private readonly ApplicationDbContext _DbContext;
        public UserServices(ApplicationDbContext DbContext)
        {

            _DbContext = DbContext;
        }

        public async Task<bool> CreateUserAsync(UserCreate model)
        {
            var newUser = new UserEntity()
            {
                Name = model.Name,
                Age = model.Age,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PetType = (Data.PetTypes)model.PetType,
                BreedId = (Data.Breeds)model.BreedId,
                Bio = model.Bio,
                Size = model.Size,
                CityID = (Data.CityNames)model.CityID
            };
            _DbContext.User.Add(newUser);
            return await _DbContext.SaveChangesAsync() == 1;
        }

        public async Task<UserDetail> GetUserByIdAsync(int userId)
        {
            UserEntity userById = await _DbContext.User
                .FirstOrDefaultAsync(r => r.Id == userId);
            if (userById == null)
                return null;
            UserDetail userDetail = new UserDetail()
            {
                Id = userById.Id,
                Name = userById.Name,
                Age = userById.Age,
                Username = userById.Username,
                FirstName = userById.FirstName,
                LastName = userById.LastName,
                PetType = (Models.User.PetTypes)userById.PetType,
                BreedId = (Models.User.Breeds)userById.BreedId,
                Bio = userById.Bio,
                Size = userById.Size,
                CityID = (Models.User.CityNames)userById.CityID
            };
            return userDetail;

        }

        public async Task<List<UserListItem>> GetAllUsersAsync()
        {
            List<UserListItem> users = await _DbContext.User
             .Select(r => new UserListItem()
             {
                 Id = r.Id,
                 Name = r.Name,
                 Age = r.Age,
                 Username = r.Username,
                 PetType = (Models.User.PetTypes)r.PetType,
                 BreedId = (Models.User.Breeds)r.BreedId,
                 Bio = r.Bio,
                 Size = r.Size,
                 CityID = (Models.User.CityNames)r.CityID

             }).ToListAsync();
            return users;

        }

        public async Task<bool> EditUsersAsync(UserEdit model)
        {
            UserEntity user = await _DbContext.User.FindAsync(model.Id);
            if (user == null)
                return false;
            user.Name = model.Name;
            user.Age = model.Age;
            user.Email = model.Email;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PetType = (Data.PetTypes)model.PetType;
            user.BreedId = (Data.Breeds)model.BreedId;
            user.Bio = model.Bio;
            user.Size = model.Size;
            user.CityID = (Data.CityNames)model.CityID;
            return await _DbContext.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteUser(int id)
        {
            UserEntity user = await _DbContext.User.FindAsync(id);
            if (user == null)
                return false;

            _DbContext.User.Remove(user);
            return await _DbContext.SaveChangesAsync() == 1;
        }


    }
}