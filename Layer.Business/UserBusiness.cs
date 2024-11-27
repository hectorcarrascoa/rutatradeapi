using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class UserBusiness
    {
        #region ----- Declaración -----
        private readonly IUserRepository userRepository;
        private readonly IOptions<MyConfig> config;
        #endregion

        #region ----- Constructores -----
        public UserBusiness(IUserRepository repository, IOptions<MyConfig> config)
        {
            userRepository = repository;
            this.config = config;
        }
        #endregion

        public async Task<UserDto> UserAuthentication(string userName, string userPassword)
        {
            return await userRepository.UserAuthenticationAsync(userName, userPassword);
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync(FiltroReporteDto filter)
        {
            var items = await userRepository.GetAllUserAsync(filter);
            //items = ((List<UserDto>)items).FindAll(p => p.IdProfile > 2);

            return items;
        }

        public async Task<IEnumerable<User>> GetUserByCompany(FiltroReporteDto filter)
        {
            var items = await userRepository.GetUserByCompany(filter);
            items = ((List<User>)items).FindAll(p => p.IdProfile > 2);
            return items;
        }

        public User GetUserById(int idUser)
        {
            return userRepository.GetById(idUser);
        }

        public async Task<User> GetUserByIdAsync(int idUser)
        {
            return await userRepository.GetByIdAsync(idUser);
        }

        public async Task<User> SaveItemAsync(User obj)
        {
            var passEncriptada = Functions.Encrypt.EncryptString(obj.UserPassword, config.Value.StringPassword);
            obj.UserPassword = passEncriptada;
            var user= await userRepository.CreateAsync(obj);

            return user;
        }

        public void UpdateItem(UserCreationDto obj)
        {
            var orItem = GetUserById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Active = obj.Active;
            orItem.IdClient = obj.IdClient;
            //orItem.IdClient = obj.IdClient;
            orItem.IdProfile = obj.IdProfile;
            orItem.UserEmail = obj.UserEmail;
            orItem.UserFirstAccess = obj.UserFirstAccess;
            orItem.UserId = obj.UserId;
            orItem.UserLastNames = obj.UserLastNames;
            orItem.UserName = obj.UserName;
            orItem.UserNames = obj.UserNames;
            orItem.UserPhone = obj.UserPhone;
            orItem.UserPicture = obj.UserPicture;

            userRepository.Update((int)orItem.Id, orItem);
        }
    }
}
