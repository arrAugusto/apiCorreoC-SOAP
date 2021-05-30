using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace wsEmailCorp
{
    /// <summary>
    /// Descripción breve de wsProveedor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsProveedor : System.Web.Services.WebService
    {
        //create proveedor
        [WebMethod]
        public int newProveedor(string razon_socialParam, string dominio_emailParam, string nitParam, string telefonoParam, string direccionParam)
        {
            return new Models.ClassProveedor().newProveedor(razon_socialParam, dominio_emailParam, nitParam, telefonoParam, direccionParam);

        }
        //edit proveedor
        [WebMethod]
        public int updateProveedor(string razon_socialParam, string dominio_emailParam, string nitParam, string telefonoParam, string direccionParam, int id_prove)
        {
            return new Models.ClassProveedor().updateProveedor(razon_socialParam, dominio_emailParam, nitParam, telefonoParam, direccionParam, id_prove);

        }
        //mostrar todos los proveedor
        [WebMethod]
        public List<string> allProveedores()
        {
            return new Models.ClassProveedor().allProveedores();
        }
        //delete proveedor
        [WebMethod]
        public int deletteProveedor(int idProve)
        {
            return new Models.ClassProveedor().deletteProveedor(idProve);
        }

    }
}
