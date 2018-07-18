using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RegionDAO : DAO<Region>
    {
        public void Create(Region r)
        {
            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                Region region = r;

                var query = contexto.Region.Where(c => c.RegionID == region.RegionID);

                /* var query = from reg in contexto.Region
                            where reg.RegionID == region.RegionID
                            select new
                            {
                                RegionID = reg.RegionID,
                                RegionDescription = region.RegionDescription
                            };
                */

                if (query.Any())
                {
                    region.RegionID = contexto.Region.ToList().Max(c => c.RegionID) + 1;
                }

                contexto.Region.Add(region);

                contexto.SaveChanges();
            }
        }

        public void Delete(Region r)
        {
            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                Region region = r;

                if (contexto.Region.Contains(region)) {

                    contexto.Region.Remove(region);
                }
                
                contexto.SaveChanges();
            }
        }

        public List<Region> GetList()
        {
            List<Region> regs = null;

            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                regs = contexto.Region.ToList();

                contexto.SaveChanges();
            }

            return regs;
        }

        public void Update(Region r)
        {
            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                Region region = r;

                var query = contexto.Region.Where(c => c.RegionID==region.RegionID);

                foreach (var c in query)
                {
                    c.RegionDescription = region.RegionDescription;
                }

                contexto.SaveChanges();
            }
        }

        public void Attach(Region r)
        {
            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                Region region = r;

                var query = contexto.Region.Max(c => c.RegionID) + 1;

                region.RegionID = query;

                contexto.Region.Attach(region);

                contexto.SaveChanges();
            }
        }
    }
}
