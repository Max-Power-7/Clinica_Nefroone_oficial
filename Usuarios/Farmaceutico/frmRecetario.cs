﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_datos;
using capa_negocio;
namespace capa_presentacion.Usuarios.Farmaceutico
{
    public partial class frmRecetario : Form
    {
        
        public frmRecetario()
        {
            InitializeComponent();
        }
        clsRecetario Rec= new clsRecetario();



        private void LimpiarTexto()
        {
            txtFecha.Clear();
           txtIdMedico.Clear();
           txtIdMedicamento.Clear();
            txtCantidad.Clear();
            txtPaciente.Clear();
            
        }


        private void seguirlista()
        {
            txtIdMedicamento.Clear();
            txtCantidad.Clear();

        }
        //*//  public void ExportarDatos(DataGridView datalistado)
        //  {
        ///    Microsoft.Office.Interop.Excel.Application exportar = new Microsoft.Office.Interop.Excel.Application();
        ///    exportar.Application.Workbooks.Add(true);
        //     int indice = 0;
        //      foreach(DataGridViewColumn column in datalistado.Columns)
        //    {
        ///         indice++;
        ///        exportar.Cells[1, indice] = Columns.Name;

        ///      }
        //*///
        /// }
        /// 




        private void limpiarbtn() {
            rbCateter.Checked = false;
            rbFistula.Checked = false;
            rbPeritoneal.Checked = false;

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCateter.Checked == true)
            {
                dgvMedicamento.DataSource = Rec.Mostrar_RegistrosC();

                dgvMedicamento.DataMember = "tac";
                dgvMedicamento.AutoResizeColumns();
                dgvMedicamento.AutoResizeRows();
              
            
            }
           
        }

        private void frmRecetario_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFistula.Checked == true)
            {
                dgvMedicamento.DataSource = Rec.Mostrar_RegistrosF();
                dgvMedicamento.DataMember = "tac";
             
                dgvMedicamento.AutoResizeColumns();
                dgvMedicamento.AutoResizeRows();
             
            }
      
        }

        private void rbPeritoneal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPeritoneal.Checked == true)
            {
                dgvMedicamento.DataSource = Rec.Mostrar_RegistrosP();
                dgvMedicamento.DataMember = "tac";
                dgvMedicamento.AutoResizeColumns();
                dgvMedicamento.AutoResizeRows();
                
            }
        
        }

        private void btnInsertarRegistros_Click(object sender, EventArgs e)
        {
            try
            {


                Rec.Fecha = txtFecha.Text;
                Rec.Cantida_Recetada = txtCantidad.Text;
                Rec.Id_medicamento = txtIdMedicamento.Text;
                Rec.Ci = txtPaciente.Text;
                Rec.Id_Empleado = txtIdMedico.Text;

              
                Rec.Guardar_Registros();
                seguirlista();

                DataSet ds = new DataSet();
                ds = Rec.Mostrar_Registros(txtFecha.Text, txtPaciente.Text);
                dgvreceta.DataSource = ds;
                dgvreceta.DataMember = "tac";
                dgvreceta.AutoResizeColumns();
                dgvreceta .AutoResizeRows();





                MessageBox.Show("Insertado correctamente", "INFORMACION");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al insertar" + er.ToString());
            }
        }

        private void dgvMedicamento_MouseClick(object sender, MouseEventArgs e)
        {  
           
        }
    }
}
