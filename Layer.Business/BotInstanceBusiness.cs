using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class BotInstanceBusiness
    {
        #region ----- Declaración -----
        private readonly IBotInstanceRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public BotInstanceBusiness(IBotInstanceRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<BotInstance>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public BotInstance GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<BotInstance> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<BotInstance> SaveItemAsync(BotInstance obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(BotInstanceDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = obj.Estado;
            orItem.Name = obj.Name;
            orItem.IdBroker = obj.IdBroker;
            orItem.IdBot = obj.IdBot;
            orItem.IdConfig = obj.IdConfig;
            orItem.TakeProfir = obj.TakeProfir;
            orItem.StopLoss = obj.StopLoss;
            orItem.Apalanca = obj.Apalanca;
            orItem.IdUser = obj.IdUser;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(BotInstanceDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(BotInstanceDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
