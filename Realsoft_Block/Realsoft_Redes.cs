using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Realsoft_Block
{
    public class Realsoft_Redes
    {
        public int _ID;
        private int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public string _NomePC;
        private string NomePC
        {
            get
            {
                return this._NomePC;
            }
            set
            {
                this._NomePC = value;
            }
        }

        public string _IPLocal;
        private string IPLocal
        {
            get
            {
                return this._IPLocal;
            }
            set
            {
                this._IPLocal = value;
            }
        }

        public  string _IPValido;
        private string IPValido
        {
            get
            {
                return this._IPValido;
            }
            set
            {
                this._IPValido = value;
            }
        }

        public string _Mac;
        private string Mac
        {
            get
            {
                return this._Mac;
            }
            set
            {
                this._Mac = value;
            }
        }

        public int _PortaComunicacao;
        private int PortaComunicacao
        {
            get
            {
                return this._PortaComunicacao;
            }
            set
            {
                this._PortaComunicacao = value;
            }
        }
    }
}
