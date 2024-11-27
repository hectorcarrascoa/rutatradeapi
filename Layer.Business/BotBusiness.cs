using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class BotBusiness
    {
        #region ----- Declaración -----
        private readonly IBotRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public BotBusiness(IBotRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<Bot>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public Bot GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<Bot> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<Bot> SaveItemAsync(Bot obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(BotDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = obj.Estado;
            orItem.Name = obj.Name;
            orItem.Description = obj.Description;
            orItem.Temp = obj.Temp;
            orItem.IdUser = obj.IdUser;
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(BotDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(BotDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
