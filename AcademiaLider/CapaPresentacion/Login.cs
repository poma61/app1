using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademiaLider.CapaLogicaNegocio;
using AcademiaLider.CapaPresentacion;
namespace AcademiaLider.CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(Object sender, EventArgs e)
        {

        }

        private void lblRecuperarPassword_Click(Object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(Object sender, EventArgs e)
        {
            logicaLogin verificar = new logicaLogin(txtUsuario.Text, txtPassword.Text);
            if (verificar.validar())
            {
                frmCatalogos cat = new frmCatalogos();
                this.Hide();
               
                cat.Show();
            }else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void btnSalir_Click(Object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
