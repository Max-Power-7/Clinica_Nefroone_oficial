﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_negocio;

using capa_datos;

namespace capa_presentacion
{
    public partial class FrmDialisisPeritoneal : Form
    {
        public FrmDialisisPeritoneal()
        {
            InitializeComponent();
        }
        ClsDialisisPeritoneal dp = new ClsDialisisPeritoneal();

        private void LimpiarTexto()
        {
            TimeInfucionesInicio.ResetText();
            TimeInfucionesFin.ResetText();
            txtBalanceParcial.Clear();
            txtInfusionesVolumen.Clear();
            txtBalanceTotal.Clear();
            txtDrenajeVolumen.Clear();
            txtBalanceParcial.Clear();
            BoxSolucion1.ClearSelected();
            BoxSolucion2.ClearSelected();
            textobservaciones.Clear();
            textidsesion.Clear();
            textidhojadp.Clear();
        }
        private void binsertar_Click(object sender, EventArgs e)
        {
            try
            {
                /*dp.Ainfucion_Inicio = TimeInfucionesInicio.Text;
                dp.Ainfucion_Final = TimeInfucionesFin.Text;
                dp.Ainfucion_Volumen = txtInfusionesVolumen.Text;
                dp.Adrenaje_Inicio = TimeDrenajeInicio.Text;
                dp.Adrenaje_Volumen = txtDrenajeVolumen.Text;
                dp.Abalance_Parcial = txtBalanceParcial.Text;
                dp.Abalance_Total = txtBalanceTotal.Text;
                dp.Asolucion_Usada1 = BoxSolucion1.Text;
                dp.Asolucion_Usada2 = BoxSolucion2.Text;
                dp.Aobservacion_Balance = textobservaciones.Text;
                dp.Aid_sesion = textidsesion.Text;
                dp.Aid_hojaDP = textidhojadp.Text;

                dp.Guardar_Registros();
                LimpiarTexto();*/
                MessageBox.Show("Insertado correctamente", "INFORMACION");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al insertar" + er.ToString());

            }

        }

        private void bmostrar_Click(object sender, EventArgs e)
        {
            dda.DataSource = dp.Mostrar_Registros();
            dda.DataMember = "tac";
            dda.AutoResizeColumns();
            dda.AutoResizeRows();
        }


        private void FrmDialisisPeritoneal_Load(object sender, EventArgs e)
        {
             dda.DataSource = dp.Mostrar_Registros();
            dda.DataMember = "tac";
            dda.AutoResizeColumns();
            dda.AutoResizeRows();
        }
        
        private void bhojaenfermeria_Click(object sender, EventArgs e)
        {

            FrmHojaEnfermeria frm = new FrmHojaEnfermeria();
            frm.Show();
        }

        private void binsertar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
