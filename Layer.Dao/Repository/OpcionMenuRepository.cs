using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Menu;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Dao.Repository
{
    public class OpcionMenuRepository : GenericRepository<Navigation>, IOpcionMenuRepository
    {
        private readonly DataContext _dbContext;

        public OpcionMenuRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Navigation> GetOpciones()
        {
            Navigation item = new Navigation();

            try
            {
                var nodes = await _dbContext.Node
                                           .Include(n => n.Children)
                                           .ToListAsync();

                // Construir el árbol jerárquico a partir de los nodos raíz
                List<Node> rootNodes = BuildTree(null, nodes);
                item.compact = rootNodes;
                item.futuristic = rootNodes;
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static List<Node> BuildTree(long? parentId, List<Node> nodes)
        {
            return nodes
                .Where(n => n.ParentId == parentId)
                .Select(n => new Node
                {
                    Id = n.Id,
                    ParentId = parentId,
                    Title = n.Title,
                    Type = n.Type,
                    Icon = n.Icon,
                    Link = n.Link,
                    Children = BuildTree(n.Id, nodes)
                })
                .ToList();
        }
    }
}
