using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace wsEmailCorp
{
    /// <summary>
    /// Descripción breve de wsEmailEnviado
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEmailEnviado : System.Web.Services.WebService
    {

        [WebMethod]
        public int newEmailEnviado(int idUserEnvia, int idUserRecibe, string asuntEnvia, string correoCuerpo)
        {
            return new Models.ClassEmailEnviado().newEmailEnviado(idUserEnvia, idUserRecibe, asuntEnvia, correoCuerpo);
        }
    }
}
