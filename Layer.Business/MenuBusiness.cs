using Layer.Dao.IRepository;
using Layer.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;
using Layer.Entity.Menu;

namespace Layer.Business
{
    public class MenuBusiness
    {
        #region ----- Declaración -----
        private readonly IOpcionMenuRepository omRepository;
        #endregion

        #region ----- Constructores -----
        public MenuBusiness(IOpcionMenuRepository repository)
        {
            omRepository = repository;
        }
        #endregion

        public async Task<Navigation> GetOpcionesMenu()
        {
            var items = await omRepository.GetOpciones();

            return items;
        }
    }
}
