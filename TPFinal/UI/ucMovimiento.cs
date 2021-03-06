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
    public partial class ucMovimiento : UserControl
    {
        private static readonly Type refleccion = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(refleccion);

        private Movimiento _movimiento;

        public ucMovimiento()
        {
            log.Debug("Inicializando ucMovimiento...");
            InitializeComponent();
            log.Debug("ucMovimiento inicializado.");
        }

        public Movimiento Movimiento
        {
            set
            {
                this._movimiento = value;
                labelFecha.Text = this._movimiento.fecha;
                labelMonto.Text = Convert.ToString(this._movimiento.cantidad);
                
                if (this._movimiento.cantidad < 0)
                {
                    labelMonto.ForeColor = Color.DarkRed;
                }
                else
                {
                    labelMonto.ForeColor = Color.Green;
                }
                
            }
        }
    }
}
