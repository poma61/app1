using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademiaLider.CapaPresentacion;
namespace AcademiaLider.CapaPresentacion
{
    public partial class frmCatalogos : Form
    {
        public frmCatalogos()
        {
            InitializeComponent();
           
        }
        public frmCatalogos fm;
        private void pictureBox1_Click(Object sender, EventArgs e)
        {
            frmProfesiones fr = new frmProfesiones();
            this.Hide();
            fr.ShowDialog();
        }

        private void pictureBox2_Click(Object sender, EventArgs e)
        {
            frmGradosAcademicos fr = new frmGradosAcademicos();
            this.Hide();
            fr.ShowDialog();
        }

        private void pictureBox3_Click(Object sender, EventArgs e)
        {
            frmCiudades city = new frmCiudades();
            this.Hide();
            city.ShowDialog();
 
        }

        private void pictureBox4_Click(Object sender, EventArgs e)
        {
            frmEventos fr = new frmEventos();
            this.Hide();
            fr.ShowDialog();
        }
    }
}
