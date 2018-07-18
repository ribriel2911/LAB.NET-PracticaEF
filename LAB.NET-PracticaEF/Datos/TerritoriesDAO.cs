using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class TerritoriesDAO : DAO<Territories>
    {
        NorthwindEntities contexto;

        public TerritoriesDAO()
        {
            contexto = new NorthwindEntities();
        }

        public void Create(Territories t)
        {
                Territories territory = t;

                contexto.Territories.Add(territory);

                contexto.SaveChanges();
        }

        public List<Territories> GetList()
        {
            List<Territories> regs = null;

                regs = contexto.Territories.ToList();

                //contexto.SaveChanges();

            return regs;
        }

        public void Delete(Territories t)
        {
                Territories territory = t;

                var query = contexto.Territories.Where(c => c.TerritoryID.Equals(territory.TerritoryID));

                foreach (var c in query)
                {
                    contexto.Territories.Remove(c);
                }

                contexto.SaveChanges();
        }

        public void Update(Territories t)
        {
                Territories territory = t;

                var query = contexto.Territories.Where(c => c.TerritoryID.Equals(territory.TerritoryID));

                foreach (var c in query)
                {
                    c.RegionID = t.RegionID;
                    c.TerritoryDescription = territory.TerritoryDescription;
                }

                contexto.SaveChanges();
        }

        public void Attach(Territories t)
        {
                Territories territory = t;

                var query = contexto.Territories.Max(c => c.TerritoryID)+1;

                territory.TerritoryID = query;

                contexto.Territories.Attach(territory);

             //   contexto.Entry<Territories>(territory).State = System.Data.Entity.EntityState.Detached;

               // contexto.SaveChanges();
        }
    }
}
