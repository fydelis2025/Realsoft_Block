using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Realsoft_Block
{
    public class Realsoft_Bloqueio
    {

        public static void BloquearSite(String strBloqueio)
        {
            try
            {

                string Caminho = @"C:\Windows\System32\drivers\etc\hosts";

                StreamWriter sw = new StreamWriter(Caminho, true);

                string sitetoblock = "\r\n127.0.0.1 http://" + strBloqueio +
                    " 127.0.0.1 http://www." + strBloqueio;

                sw.Write(sitetoblock);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BloquearNavegador()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BloquearControlPanel()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}
