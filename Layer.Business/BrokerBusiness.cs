using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class BrokerBusiness
    {
        #region ----- Declaración -----
        private readonly IBrokerRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public BrokerBusiness(IBrokerRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<Broker>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public Broker GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<Broker> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<Broker> SaveItemAsync(Broker obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(BrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Color = obj.Color;
            orItem.Name = obj.Name;
            orItem.Description = obj.Description;
            orItem.Imagen = obj.Imagen;
            orItem.Estado = obj.Estado;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(BrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(BrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
