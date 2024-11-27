using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class UserBrokerBusiness
    {
        #region ----- Declaración -----
        private readonly IUserBrokerRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public UserBrokerBusiness(IUserBrokerRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<UserBroker>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public UserBroker GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<UserBroker> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<UserBroker> SaveItemAsync(UserBroker obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(UserBrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = obj.Estado;
            orItem.Credential1 = obj.Credential1;
            orItem.Credential2 = obj.Credential2;
            orItem.Label = obj.Label;
            orItem.IdConfig = obj.IdConfig;
            orItem.IdBroker = obj.IdBroker;
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(UserBrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(UserBrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
