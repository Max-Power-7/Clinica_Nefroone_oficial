﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capa_presentacion.Usuarios.secretario
{
    public partial class formularioprincipalS : Form
    {
        public formularioprincipalS()
        {
            InitializeComponent();
        }
        
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = PanelFormulario.Controls.OfType<MiForm>().FirstOrDefault();//busca en la coleccion de formlario si el formulario instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PanelFormulario.Controls.Add(formulario);
                PanelFormulario.Tag = formulario;
                formulario.Show();                
                formulario.BringToFront();
            }

            else
            {
                formulario.BringToFront();
            }

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRegPac_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmRegistrarPacientes>();
        }

        private void btnConsPac_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmConsultarPacientes>();
        }

        private void btnHojaSec_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmHojaSecretaria>();
            
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInicioSesion frm = new FrmInicioSesion();
            frm.Show();
        }

        private void btnConsHojSec_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmConsultaHojaSec>();
        }
    }
}
