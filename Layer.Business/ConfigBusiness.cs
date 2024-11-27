using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class ConfigBusiness
    {
        #region ----- Declaración -----
        private readonly IConfigRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public ConfigBusiness(IConfigRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<Config>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public Config GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<Config> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<Config> SaveItemAsync(Config obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(ConfigDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = obj.Estado;
            orItem.Descripcion = obj.Descripcion;
            orItem.IdUser = obj.IdUser;
            orItem.Quantity = obj.Quantity;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(ConfigDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(ConfigDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
