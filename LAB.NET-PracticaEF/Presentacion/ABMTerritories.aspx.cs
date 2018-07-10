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
        SolverTerritories solver;

        protected void Page_Init(object sender, EventArgs e)
        {
            solver = new SolverTerritories();

            CargarGrilla();
            Limpiar();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            solver.CargarTerritories();

            this.Grid1.DataSource = solver.GetTeritories;
            this.Grid1.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            solver.CrearTerritory(this.txtTerritoryId.Text,
                                  this.txtDescription.Text,
                                  this.listRegion.SelectedValue);

            Limpiar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            solver.ModificarTerritory(this.txtTerritoryId.Text,
                                      this.txtDescription.Text,
                                      this.listRegion.SelectedValue);

            Limpiar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            solver.BorrarTerritory(this.txtTerritoryId.Text);

            Limpiar();
        }

        protected void Grid1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.txtDescription.Text = this.Grid1.SelectedRow.Cells[2].Text.Trim();

            this.txtTerritoryId.Text = this.Grid1.SelectedRow.Cells[1].Text.Trim();
        }

        protected void Limpiar()
        {
            this.txtDescription.Text = "";
            this.txtTerritoryId.Text = "";

            this.listRegion.DataSource = solver.GetRegiones;
            this.listRegion.DataBind();

            CargarGrilla();
        }
    }
}