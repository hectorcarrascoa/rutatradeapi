using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class GroupFinancialBusiness
    {
        #region ----- Declaración -----
        private readonly IGroupFinancialRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public GroupFinancialBusiness(IGroupFinancialRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<GroupFinancialAsset>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public GroupFinancialAsset GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<GroupFinancialAsset> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<GroupFinancialAsset> SaveItemAsync(GroupFinancialAsset obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(GroupFinancialAssetDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Name = obj.Name;
            orItem.Description = obj.Description;
            orItem.Imagen = obj.Imagen;
            orItem.Estado = obj.Estado;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(GroupFinancialAssetDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(GroupFinancialAssetDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
