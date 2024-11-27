using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class IndicatorBusiness
    {
        #region ----- Declaración -----
        private readonly IIndicatorRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public IndicatorBusiness(IIndicatorRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<Indicator>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public Indicator GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<Indicator> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<Indicator> SaveItemAsync(Indicator obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(IndicatorDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Type = obj.Type;
            orItem.Name = obj.Name;
            orItem.Description = obj.Description;
            orItem.Imagen = obj.Imagen;
            orItem.Estado = obj.Estado;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(IndicatorDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(IndicatorDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
