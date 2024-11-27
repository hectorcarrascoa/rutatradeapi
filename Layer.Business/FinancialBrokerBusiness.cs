using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class FinancialBrokerBusiness
    {
        #region ----- Declaración -----
        private readonly IFinancialBrokerRepository rRepository;
        #endregion

        #region ----- Constructores -----
        public FinancialBrokerBusiness(IFinancialBrokerRepository repository)
        {
            rRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<FinancialBroker>> GetItems(FiltroReporteDto filtro)
        {
            return await rRepository.GetItems(filtro);
        }

        public FinancialBroker GetItemById(int id)
        {
            return rRepository.GetById(id);
        }

        public async Task<FinancialBroker> GetItemByIdAsync(int id)
        {
            return await rRepository.GetByIdAsync(id);
        }

        public async Task<FinancialBroker> SaveItemAsync(FinancialBroker obj)
        {
            return await rRepository.CreateAsync(obj);
        }

        public void UpdateItem(FinancialBrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.IdBroker = obj.IdBroker;
            orItem.IdFinancial = obj.IdFinancial;
            orItem.Symbol = obj.Symbol;
            orItem.Name = obj.Name;
            orItem.Apalanca = obj.Apalanca;
            orItem.Estado = obj.Estado;
            rRepository.Update((int)orItem.Id, orItem);
        }

        public void DeleteItem(FinancialBrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.UpdDate = DateTime.Now;
            orItem.UpdUser = obj.UpdUser;
            orItem.Estado = false;

            rRepository.Update((int)orItem.Id, orItem);
        }

        public void SaveAvatar(FinancialBrokerDto obj)
        {
            var orItem = GetItemById((int)obj.Id);
            orItem.Imagen = obj.Imagen;
            rRepository.Update((int)orItem.Id, orItem);
        }
    }
}
