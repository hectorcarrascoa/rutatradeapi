using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class ClientBusiness
    {
        #region ----- Declaración -----
        private readonly IClientRepository clientRepository;
        #endregion

        #region ----- Constructores -----
        public ClientBusiness(IClientRepository repository)
        {
            clientRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<Client>> GetAlltAsync()
        {
            return await clientRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await clientRepository.GetClientsAsync();
        }
    }
}
