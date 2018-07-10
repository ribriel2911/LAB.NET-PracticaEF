using System;
using System.Collections.Generic;
using System.Data;
using Datos;

namespace Negocio
{
    public class SolverTerritories
    {
        private DataTable territories;
        private DAO<Territories> dao;
        SolverRegion solRegions;

        public SolverTerritories()
        {
            dao = new TerritoriesDAO();
            solRegions = new SolverRegion();

            CargarTerritories();
        }


        public void CargarTerritories()
        {
            territories = new DataTable("Territories");
            territories.Columns.Add(new DataColumn("TerritoryID", typeof(string)));
            territories.Columns.Add(new DataColumn("TerritoryDescription", typeof(string)));
            territories.Columns.Add(new DataColumn("RegionID", typeof(int)));
            territories.Columns.Add(new DataColumn("RegionDescription", typeof(string)));

            foreach (Territories t in dao.GetList())
            {
                DataRow row = territories.NewRow();
                row["TerritoryID"] = t.TerritoryID;
                row["TerritoryDescription"] = t.TerritoryDescription;
                row["RegionID"] = t.RegionID;
                row["RegionDescription"] = BuscarRegion(t.RegionID).RegionDescription;

                territories.Rows.Add(row);
            }
        }

        public void ModificarTerritory(string id, string description, string region)
        {
            Region r = BuscarRegion(region);

            Territories t = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = description,
                RegionID = r.RegionID,
            };

            r.Territories.Add(t);

            dao.Update(t);
            CargarTerritories();
        }

        public void CrearTerritory(string id, string description, string region){

            Region r = BuscarRegion(region);

            Territories t = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = description,
                RegionID = r.RegionID,
            };

            r.Territories.Add(t);

            dao.Create(t);
            CargarTerritories();
        }

        public void BorrarTerritory(string valor)
        {
            Territories t = BuscarTerritory(valor);

            dao.Delete(t);
            CargarTerritories();
        }

        private Territories BuscarTerritory(string valor)
        {
            Territories ret = null;

            DataRow[] rows = territories.Select(String.Format("TerritoryID='{0}'", valor));

            if(rows == null) rows = territories.Select(String.Format("TerritoryDescription='{0}'", valor));

            if (rows != null)
            {
                DataRow row = rows[0];

                ret = new Territories()
                {
                    TerritoryID = (string) row["TerritoryID"],
                    TerritoryDescription = (string) row["TerritoryDescription"],
                    RegionID = (int) row["RegionID"],
                };
            }

            return ret;
        }

        private Region BuscarRegion(string region)
        {
            Region ret = solRegions.BuscarDescripcion(region);

            return ret;
        }

        private Region BuscarRegion(int region)
        {
            Region ret = solRegions.BuscarId(region);

            return ret;
        }

        public DataTable GetTeritories => territories;
        public List<string> GetRegiones => solRegions.Descripciones();
    }
}
