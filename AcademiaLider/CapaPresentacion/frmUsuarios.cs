﻿using System;
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
    public partial class frmUsuarios : Form
    {

        private clnUsuarios action;
        private Usuarios update;
       
        public frmUsuarios()
        {
            InitializeComponent();

        }
        public void selectAll()
        {
            action = new clnUsuarios();
             dgvList.DataSource = this.action.getAll();
           
        }
    
        public void actionDataGrid()
        {
            btnNuevo.Enabled = false;
            txtConfirmarPassword.Enabled = false;
            txtPassword.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            lblMessage.Text = "Mensaje:";

        }
        public void disableDataGrid()
        {
            btnNuevo.Enabled = true;
            txtConfirmarPassword.Enabled = true;
            txtPassword.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        
        }
        public void clean()
        {
            txtNombres.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtCorreo.Text = "";
            txtConfirmarPassword.Text = "";
        }
        public Boolean validar()
        {
   
            if (txtNombres.Text == "" || txtUsuario.Text=="" || txtCorreo.Text=="" )
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
                if(txtPassword.Text == txtConfirmarPassword.Text)
                {
                    Usuarios user = new Usuarios();
                    user.Nombres = txtNombres.Text;
                    user.Usuario = txtUsuario.Text;
                    user.Password = txtPassword.Text;
                    user.Correo = txtCorreo.Text;
                    action = new clnUsuarios();
                    lblMessage.Text = action.insert(user);
                    selectAll();
                    clean();
                }else
                {

                    MessageBox.Show("Las contraseñas no coinciden...");
                }
   
            }else
            {
       MessageBox.Show("Debe llenar todos los campos...");
                     
            }

        }

        private void dgvCargarList(Object sender, DataGridViewCellMouseEventArgs e)
        {
           if (e.RowIndex >= 0 && e.RowIndex < dgvList.Rows.Count - 1)
            {
                update = new Usuarios();
                update.Codigo =Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());
                update.Nombres = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                update.Usuario = dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
                update.Correo = dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNombres.Text = update.Nombres;
                txtUsuario.Text = update.Usuario;
                txtCorreo.Text = update.Correo;
                actionDataGrid();
            }
         
        }

        private void frmUsuarios_Load(Object sender, EventArgs e)
        {
            selectAll();
            disableDataGrid();
        }

        private void btnCancelar_Click(Object sender, EventArgs e)
        {
            clean();
            selectAll();
            disableDataGrid();
        }

        private void btnModificar_Click(Object sender, EventArgs e)
        {
            if (validar())
            {
               
                    Usuarios user = new Usuarios();
                    user.Codigo = update.Codigo;
                    user.Nombres = txtNombres.Text;
                    user.Usuario = txtUsuario.Text;
                    user.Password = txtPassword.Text;
                    user.Correo = txtCorreo.Text;
                    action = new clnUsuarios();
                    lblMessage.Text = action.update(user);
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

                Usuarios user = new Usuarios();
                user.Codigo = update.Codigo;
                user.Nombres = txtNombres.Text;
                user.Usuario = txtUsuario.Text;
                user.Password = txtPassword.Text;
                user.Correo = txtCorreo.Text;
                action = new clnUsuarios();
                lblMessage.Text = action.delete(user);
                selectAll();
                clean();
                disableDataGrid();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos...");

            }



        }

        private void txtBuscar_TextChanged(Object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                action = new clnUsuarios();
             dgvList.DataSource= action.busqueda(txtBuscar.Text);

            }
            else
            {
                selectAll();
            }
        }
    }
}
