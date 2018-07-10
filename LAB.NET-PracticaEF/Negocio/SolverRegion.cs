using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SolverRegion
    {
        private DataTable regiones;
        private DAO<Region> dao;

        public SolverRegion()
        {
            dao = new RegionDAO();

            CargarRegiones();
        }

        public void CargarRegiones()
        {
            regiones = new DataTable("Region");
            regiones.Columns.Add(new DataColumn("RegionID", typeof(int)));
            regiones.Columns.Add(new DataColumn("RegionDescription", typeof(string)));

            foreach (Region r in dao.GetList())
            {
                DataRow row = regiones.NewRow();
                row["RegionID"] = r.RegionID;
                row["RegionDescription"] = r.RegionDescription;

                regiones.Rows.Add(row);
            }
        }

        public void CrearRegion(int id, string description)
        {
            Region r = new Region()
            {
                RegionID = id,
                RegionDescription = description
            };

            dao.Create(r);
            CargarRegiones();
        }

        public List<string> Descripciones()
        {
            List<string> ret = new List<string>();

            foreach(DataRow r in regiones.Rows)
            {
                ret.Add((string) r["RegionDescription"]);
            }

            return ret;
        }

        public Region BuscarDescripcion(string description)
        {
            Region ret = null;

            DataRow[] rows = regiones.Select(String.Format("RegionDescription='{0}'",description));

            if (rows.Length != 0)
            {
                DataRow row = rows[0];

                ret = new Region
                {
                    RegionID = (int)row["RegionID"],
                    RegionDescription = (string)row["RegionDescription"]
                };
            }

            return ret;
        }

        internal Region BuscarId(int id)
        {
            Region ret = null;

            DataRow[] rows = regiones.Select(String.Format("RegionID='{0}'",id));

            if (rows.Length != 0)
            {
                DataRow row = rows[0];

                ret = new Region
                {
                    RegionID = (int)row["RegionID"],
                    RegionDescription = (string)row["RegionDescription"]
                };
            }

            return ret;
        }

        public DataTable GetRegiones => regiones;
    }
}
