using Layer.Dao.IRepository;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class ProfileBusiness
    {
        #region ----- Declaración -----
        private readonly IProfileRepository proRepository;
        #endregion

        #region ----- Constructores -----
        public ProfileBusiness(IProfileRepository repository)
        {
            proRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<Profile>> GetProfiles(int idBusinessClient)
        {
            return await proRepository.GetProfiles(idBusinessClient);
        }
    }
}
