using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AcademiaLider.Entidades;
using AcademiaLider.CapaLogicaNegocio;

namespace AcademiaLider.CapaPresentacion
{
    public partial class frmGradosAcademicos : Form
    {
        private clnGrados action;
        private Grados updateLocal;
        public frmGradosAcademicos()
        {
            InitializeComponent();
        }

        public void selectAll()
        {
            action = new clnGrados();
            dgvList.DataSource = this.action.getAll();

        }

        public void actionDataGrid()
        {
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            lblMessage.Text = "Mensaje:";
        }
        public void disableDataGrid()
        {
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

        }
        public void clean()
        {
            txtGradoAcademico.Text = "";

        }
        public Boolean validar()
        {

            if (txtGradoAcademico.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnNuevo_Click(Object sender, EventArgs e)
        {
            if (validar())
            {

               Grados mongo = new Grados();
                mongo.Nombres = txtGradoAcademico.Text;

                action = new clnGrados();
                lblMessage.Text = action.insert(mongo);
                selectAll();
                clean();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos...");

            }
        }

        private void btnModificar_Click(Object sender, EventArgs e)
        {
            if (validar())
            {

                Grados mongo = new Grados();
                mongo.Codigo = updateLocal.Codigo;
                mongo.Nombres = txtGradoAcademico.Text;
                action = new clnGrados();
                lblMessage.Text = action.update(mongo);
                selectAll();
                clean();
                disableDataGrid();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos...");

            }
        }

        private void btnEliminar_Click(Object sender, EventArgs e)
        {

            if (validar())
            {

                Grados mongo = new Grados();
                mongo.Codigo = updateLocal.Codigo;
                mongo.Nombres = txtGradoAcademico.Text;
                action = new clnGrados();
                lblMessage.Text = action.delete(mongo);
                selectAll();
                clean();
                disableDataGrid();

            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos...");

            }
        }

        private void btnActulizar_Click(Object sender, EventArgs e)
        {
            clean();
            selectAll();
            disableDataGrid();
        }

        private void txtBuscar_TextChanged(Object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                action = new clnGrados();
                dgvList.DataSource = action.busqueda(txtBuscar.Text);

            }
            else
            {
                selectAll();
            }
        }

        private void frmGradosAcademicos_Load(Object sender, EventArgs e)
        {
           
            selectAll();
            disableDataGrid();
        }

        private void btnVolver_Click(Object sender, EventArgs e)
        {
        
        }

        private void dgvCargar(Object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvList.Rows.Count - 1)
            {
                updateLocal = new Grados();
                updateLocal.Codigo = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());
                updateLocal.Nombres = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtGradoAcademico.Text = updateLocal.Nombres;
                actionDataGrid();
            }



        }
    }
}
