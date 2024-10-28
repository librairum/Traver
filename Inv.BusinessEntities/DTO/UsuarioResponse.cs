using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inv.BusinessEntities.DTO
{
    public class UsuarioResponse
    {


        private int CodigoGeologoField;

        private int CodigoPerfilField;

        private int CodigoTomadorMuestraField;

        private string CodigoTrabajadorField;

        private string CodigoUsuarioField;

        private string NombreGeologoField;

        private string NombrePerfilField;

        private string NombreTomadorMuestraField;

        private string NombreUsuarioField;

        public int CodigoGeologo
        {
            get
            {
                return this.CodigoGeologoField;
            }
            set
            {
                this.CodigoGeologoField = value;
            }
        }

        
        public int CodigoPerfil
        {
            get
            {
                return this.CodigoPerfilField;
            }
            set
            {
                this.CodigoPerfilField = value;
            }
        }

        
        public int CodigoTomadorMuestra
        {
            get
            {
                return this.CodigoTomadorMuestraField;
            }
            set
            {
                this.CodigoTomadorMuestraField = value;
            }
        }

        
        public string CodigoTrabajador
        {
            get
            {
                return this.CodigoTrabajadorField;
            }
            set
            {
                this.CodigoTrabajadorField = value;
            }
        }

        
        public string CodigoUsuario
        {
            get
            {
                return this.CodigoUsuarioField;
            }
            set
            {
                this.CodigoUsuarioField = value;
            }
        }

        
        public string NombreGeologo
        {
            get
            {
                return this.NombreGeologoField;
            }
            set
            {
                this.NombreGeologoField = value;
            }
        }

        
        public string NombrePerfil
        {
            get
            {
                return this.NombrePerfilField;
            }
            set
            {
                this.NombrePerfilField = value;
            }
        }

        
        public string NombreTomadorMuestra
        {
            get
            {
                return this.NombreTomadorMuestraField;
            }
            set
            {
                this.NombreTomadorMuestraField = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return this.NombreUsuarioField;
            }
            set
            {
                this.NombreUsuarioField = value;
            }
        }

    }
}
