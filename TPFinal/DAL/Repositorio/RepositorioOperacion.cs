﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DAL.Interfaces;
using TPFinal.Clases;
using TPFinal.DTO;

namespace TPFinal.DAL.Repositorio
{
    class RepositorioOperacion : RepositorioGeneral<Operacion, ContextoBanco>, IRepositorioOperacion
    {
        public RepositorioOperacion(ContextoBanco pContext) : base(pContext)
        {
            
        }

        public void Agregar(string pTipoOperacion, string pTiempoInsumido, DTOUsuario pUsuario)
        {
            Usuario iUsuario = iContext.Usuario.FirstOrDefault(n => n.Nombre == pUsuario.Nombre && n.Categoria == pUsuario.Categoria);
            Operacion iOperacion = new Operacion(pTipoOperacion, pTiempoInsumido, iUsuario);
            this.iContext.Set<Operacion>().Add(iOperacion);
        }

        public void Eliminar(int pOperacionId)
        {
            Operacion iOperacion = Obtener(pOperacionId);
            if (iOperacion == null)
            {
                throw new ArgumentNullException(nameof(iOperacion));
            }
            this.iContext.Set<Operacion>().Remove(iOperacion);
        }
    }
}
