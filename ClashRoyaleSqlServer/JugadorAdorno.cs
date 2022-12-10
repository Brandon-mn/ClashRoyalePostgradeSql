﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashRoyaleSqlServer
{
    public partial class JugadorAdorno : Form
    {
        public JugadorAdorno()
        {
            InitializeComponent();
        }
        string consulta;
        private void MostrarDatos()
        {
            dataGridView1.DataSource = conexinsqlserver.ejecutaConsultaSelect("SELECT *FROM JugadorAdorno ORDER BY idJugadorAdorno");

        }
        private void JugadorAdorno_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idJugador = textBox1.Text;
            string idAdorno = textBox2.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO JugadorAdorno (idJugador, idAdorno,  estatus) " +
                "values('" + idJugador + "', '" + idAdorno + "', '" + estatus + "')";
            conexinsqlserver.ejecutaConsulta(consulta);
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int identificador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            string idJugador = textBox1.Text;
            string idAdorno = textBox2.Text;
            string estatus = textBox4.Text;
            consulta = "UPDATE JugadorAdorno SET idJugador = '" + idJugador + "',idAdorno = '" + idAdorno +
                "',estatus = '" + estatus + "' WHERE idJugadorAdorno = " + identificador.ToString();
            conexinsqlserver.ejecutaConsulta(consulta);
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int identificador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE JugadorAdorno SET Estatus = false WHERE idJugadorAdorno = " + identificador.ToString(); ;
            conexinsqlserver.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 abrir = new Form1();
            abrir.Show();
            this.Hide();
        }
    }
}