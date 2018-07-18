using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace Presentacion
{
    public partial class ABMTerritories : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["solver"] = new SolverTerritories();
                Response.Write(DateTime.Now);
            }

            Limpiar();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void CargarGrilla()
        {
            SolverTerritories sol = (SolverTerritories) Session["solver"];

            this.Grid1.DataSource = sol.GetTerritories();
            this.Grid1.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            SolverTerritories sol = (SolverTerritories)Session["solver"];

            sol.CrearTerritory(this.txtTerritoryId.Text,
                                  this.txtDescription.Text,
                                  this.listRegion.SelectedValue);

            Limpiar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            SolverTerritories sol = (SolverTerritories)Session["solver"];

            sol.ModificarTerritory(this.txtTerritoryId.Text,
                                      this.txtDescription.Text,
                                      this.listRegion.SelectedValue);

            Limpiar();
        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            SolverTerritories sol = (SolverTerritories)Session["solver"];

            sol.AdjuntarTerritory(this.txtTerritoryId.Text,
                                      this.txtDescription.Text,
                                      this.listRegion.SelectedValue);

            Limpiar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            SolverTerritories sol = (SolverTerritories)Session["solver"];

            sol.BorrarTerritory(this.txtTerritoryId.Text,
                                      this.txtDescription.Text,
                                      this.listRegion.SelectedValue);

            Limpiar();
        }

        protected void Grid1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            SolverTerritories sol = (SolverTerritories)Session["solver"];

            String region = sol.BuscarRegion(int.Parse(this.Grid1.SelectedRow.Cells[3].Text.Trim()));

            this.listRegion.SelectedValue = region;
            this.txtDescription.Text = this.Grid1.SelectedRow.Cells[2].Text.Trim();
            this.txtTerritoryId.Text = this.Grid1.SelectedRow.Cells[1].Text.Trim();
        }

        protected void Limpiar()
        {
            SolverTerritories sol = (SolverTerritories)Session["solver"];

            this.txtDescription.Text = "";
            this.txtTerritoryId.Text = "";

            this.listRegion.DataSource = sol.GetRegiones;
            this.listRegion.DataBind();

            CargarGrilla();
        }
    }
}