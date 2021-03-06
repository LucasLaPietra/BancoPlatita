﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal
{
    public partial class ucPin : UserControl
    {
        private static readonly Type refleccion = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(refleccion);

        private static ucPin _instancia;
        private static ButtonBase _botonSiguiente;

        public TextBoxBase CajaTexto { get; set; }

        public ucPin()
        {
            log.Debug("Inicializando ucPin...");
            InitializeComponent();
            CajaTexto = maskedTextBox;
            log.Debug("ucPin inicializado.");
        }

        public static ucPin Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ucPin();
                }
                return _instancia;
            }
        }

        public ButtonBase BotonSiguiente
        {
            get
            {
                return _botonSiguiente;
            }

            set
            {
                _botonSiguiente = value;
                _botonSiguiente.Visible = false;
                _botonSiguiente.Enabled = false;
            }
        }

        private void maskedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox.MaskCompleted)
            {
                _botonSiguiente.Visible = true;
                _botonSiguiente.Enabled = true;
            }
            else
            {
                _botonSiguiente.Enabled = false;
            }
        }
    }
}
