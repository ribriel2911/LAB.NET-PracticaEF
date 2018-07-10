using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class TerritoriesDAO : DAO<Territories>
    {
        public void Create(Territories t)
        {
            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                Territories territory = t;

                contexto.Territories.Add(territory);

                contexto.SaveChanges();
            }
        }

        public List<Territories> GetList()
        {
            List<Territories> regs = null;

            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                regs = contexto.Territories.ToList();

                contexto.SaveChanges();
            }

            return regs;
        }

        public void Delete(Territories t)
        {
            using (NorthwindEntities contexto = new NorthwindEntities())
            {
                Territories territory = t;

                var query = contexto.Territories.Where(c => c.TerritoryID.Equals(territory.TerritoryID));

                foreach (var c in query)
                {
                    contexto.Territories.Remove(c);
                }

                contexto.SaveChanges();
            }
        }

        public void Update(Territories t)
        {
           
        }
    }
}
