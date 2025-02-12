﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using capa_datos;
using capa_negocio;

//using System.Linq;
using capa_presentacion.Usuarios.Medico;
using capa_presentacion.Usuarios.Farmaceutico;
using capa_presentacion.Usuarios.secretario;
using capa_presentacion.Usuarios.Enfermero;

namespace capa_presentacion
{
    public partial class FrmInicioSesion : Form
    {
        public FrmInicioSesion()
        {
            InitializeComponent();
        }

        E_Users objeuser = new E_Users();
        N_Users objnuser = new N_Users();
        
        void p_login()
        {
            DataTable dt = new DataTable();
            objeuser.Usuario = txtUsuario.Text;
            objeuser.Contraseña = txtContraseña.Text;

            dt = objnuser.N_user(objeuser);

            if (dt.Rows.Count > 0)
            {                                
                //Identificar el tipo y el ID del usuario/empleado que está ingresando al sistema
                ClsConexion cs = new ClsConexion();
                Metodos met = new Metodos();

                //Acude al método en la clase ClsConexion para consultar a la base de datos
                DataTable dtTipo = cs.EncontrarTipoUsuario(txtUsuario.Text,txtContraseña.Text);
                DataTable dtIDEmp = cs.EncontrarIDUsuario(txtUsuario.Text, txtContraseña.Text);

                //Devuelve en un string el tipo de usuario
                string tipo = met.DatatableToString(dtTipo);
                
                //Igualmente guardo en un string el ID del empleado/usuario que está iniciando sesión
                Constantes.ID_Emp = met.DatatableToString(dtIDEmp);
                
                //Muestra el tipo de usuario en pantalla con una bienvenida
                MessageBox.Show("¡Welcome! " + tipo);

                //Abre el menú respectivo al tipo de usuario ingresando
                if(tipo != "")
                {
                    switch (tipo)
                    {
                        case "Administrador":
                            FrmAreaAdministrativa adm = new FrmAreaAdministrativa();
                            adm.Show();
                            break;
                        case "Medico":
                            formularioprincipalM med = new formularioprincipalM();
                            med.Show();
                            break;
                        case "Farmaceutico":
                            formularioprincipalF far = new formularioprincipalF();
                            far.Show();
                            break;
                        case "Secretario":
                            formularioprincipalS sec = new formularioprincipalS();
                            sec.Show();
                            break;
                        case "Enfermera":
                            formularioprincipalE enf = new formularioprincipalE();
                            enf.Show();
                            break;                            
                        default:
                            Console.WriteLine("No es un tipo de usuario válido en el sistema");
                            break;
                    }
                }
                //Para ocultar el formulario al iniciar sesión exitosamente
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña invalido");
            }
        }    
        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {            
            p_login();                        

            //Este procedimiento debería establecer la ruta de cada menú para cada tipo de empleado que inicie sesión como usuario
            //VerificarLogin();
        }

        private void VerificarLogin()
        {
            /*if()
            {

            }
            else
            {

            }*/

            throw new NotImplementedException();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            //Para ocultar el formulario al iniciar sesión exitosamente
            this.Hide();

            //Mostrar Formulario de creación de nueva cuenta
            FrmCrearCuenta frm = new FrmCrearCuenta();
            frm.Show();
        }        

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
