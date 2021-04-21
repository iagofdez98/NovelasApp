﻿using NovelasAPP.Core.Personajes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelasAPP.UI.Views
{
    using WFrms = System.Windows.Forms;
    public class PersonajesView : WFrms.Form
    {

        public PersonajesView()
        {
            this.Build();
        }

        void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill
            };
            mainPanel.Controls.Add(this.BuildCreate());
            mainPanel.Controls.Add(this.BuildDelete());

            Datos = new DataGridView();
            
            Datos.Size = new Size(390, 200);
            mainPanel.Controls.Add(Datos);
            TablaMultifuncion_Load();
            
            

            this.Size = new Size(580, 340);

            this.Controls.Add(mainPanel);
        }

        WFrms.Button BuildCreate()
        {

            BtCrearPersonaje = new Button
            {
                Text = "Crear personaje",
                Dock = DockStyle.Top
            };


            return BtCrearPersonaje;

        }


        /*
        WFrms.Button BuildShow()
        {

            BtMostrarPersonajes = new Button
            {
                Text = "Mostrar personajes",
                Dock = DockStyle.Top
            };

            return BtMostrarPersonajes;

        }
        */

        WFrms.Button BuildDelete()
        { 

            BtBorrarPersonajes = new Button
            {
                Text = "Borrar personajes",
                Dock = DockStyle.Top
            };

            return BtBorrarPersonajes;
        }

        private void TablaMultifuncion_Load()
        {
            ColocarDataGridView();
            IntroducirDatos();
        }


        private void ColocarDataGridView()
        {

            Datos.ColumnCount = 2;


            Datos.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Datos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            Datos.RowHeadersVisible = false;
            Datos.ReadOnly = true;


            Datos.Columns[0].Name = "Nombre";
            Datos.Columns[1].Name = "Descripción";

            Datos.Columns[0].Width = 200;
            Datos.Columns[1].Width = 350;


            Datos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            Datos.Dock = DockStyle.Fill;
        }

        public void IntroducirDatos()
        {
            Datos.Rows.Clear();

            RegistroPersonajes registro = new RegistroPersonajes();
            registro = registro.RecuperaXml();
            
            foreach(Personaje p in registro.Personajes)
            {
                Datos.Rows.Add(p.Nombre,p.Descripcion);
            }


        }


        public WFrms.Button BtCrearPersonaje
        {
            get; private set;
        }
        public WFrms.Button BtMostrarPersonajes
        {
            get; private set;
        }
        public WFrms.Button BtBorrarPersonajes
        {
            get; private set;
        }

        public WFrms.DataGridView Datos
        {
            get;private set;
        }

    }
}
