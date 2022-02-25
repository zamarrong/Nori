using NoriSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nori.Restaurante
{
    public partial class frmRestaurante : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmRestaurante()
        {
            InitializeComponent();
			this.MetodoDinamico();

            CargarAsync();

            lblEstacion.Caption = Program.Nori.Estacion.nombre;
            lblUsuario.Caption = Program.Nori.UsuarioAutenticado.nombre;

            CargarMesas();

            frmComanda f = new frmComanda();
            f.Show();
        }

        private async void CargarAsync()
        {
            try
            {
                Extensiones.SetImage(panelMesas, await Funciones.CargarImagen(Program.Nori.Empresa.logotipo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMesas()
        {
            List<Mesa> mesas = Mesa.ObtenerPorComedor(0);

            panelMesas.Controls.Clear();
            foreach(Mesa mesa in mesas)
            {
                Button boton = new Button();

                boton.Name = mesa.id.ToString();
                boton.Text = mesa.nombre;

                boton.Width = mesa.ancho;
                boton.Height = mesa.alto;

                boton.Font = new Font(boton.Font, FontStyle.Bold);

                boton.Location = new Point(mesa.x, mesa.y);

                ControlManager.ControlMoverOrResizer.Init(boton);

                panelMesas.Controls.Add(boton);
            }
        }

        private void GuardarMesas()
        {
            List<Mesa> mesas = Mesa.ObtenerPorComedor(0);
            foreach (Mesa mesa in mesas)
            {
                Control control = panelMesas.Controls.Find(mesa.id.ToString(), true)[0];

                mesa.ancho = control.Width;
                mesa.alto = control.Height;
                mesa.x = control.Location.X;
                mesa.y = control.Location.Y;

                mesa.Actualizar();
            }
        }

        private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mesa mesa = new Mesa();

            mesa.codigo = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el código de la mesa", "Mesas", mesa.codigo);
            mesa.nombre = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el nombre de la mesa", "Mesas", mesa.nombre);

            mesa.Agregar();

            CargarMesas();
        }

        private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuardarMesas();
        }
    }
}