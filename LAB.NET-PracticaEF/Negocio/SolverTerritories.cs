using System;
using System.Collections.Generic;
using System.Data;
using Datos;

namespace Negocio
{
    public class SolverTerritories
    {
        private DAO<Territories> dao;
        private SolverRegion solRegions;

        public SolverTerritories()
        {
            dao = new TerritoriesDAO();
            solRegions = new SolverRegion();
        }


        public DataTable GetTerritories()
        {
            DataTable territories;

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
                row["RegionDescription"] = BuscarRegionID(t.RegionID).RegionDescription;

                territories.Rows.Add(row);
            }

            return territories;
        }

        public void ModificarTerritory(string id, string description, string region)
        {
            Region r = BuscarRegionDesc(region);

            Territories t = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = description,
                RegionID = r.RegionID,
            };

            dao.Update(t);
        }

        public void AdjuntarTerritory(string id, string description, string region)
        {
            Region r = BuscarRegionDesc(region);

            Territories t = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = description,
                RegionID = r.RegionID,
            };

            dao.Attach(t);
        }

        public void CrearTerritory(string id, string description, string region){

            Region r = BuscarRegionDesc(region);

            Territories t = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = description,
                RegionID = r.RegionID,
            };

            r.Territories.Add(t);

            dao.Create(t);
        }

        public void BorrarTerritory(string id, string description, string region)
        {
             Region r = BuscarRegionDesc(region);

            Territories t = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = description,
                RegionID = r.RegionID,
            };

            dao.Delete(t);
        }

        private Region BuscarRegionDesc(string region)
        {
            Region ret = solRegions.BuscarDescripcion(region);

            return ret;
        }

        private Region BuscarRegionID(int region)
        {
            Region ret = solRegions.BuscarId(region);

            return ret;
        }

        public String BuscarRegion(int region)
        {
            BuscarRegionID(region);

            return BuscarRegionID(region).RegionDescription;
        }

        public List<string> GetRegiones => solRegions.Descripciones();
    }
}
