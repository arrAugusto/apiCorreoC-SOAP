using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
namespace wsEmailCorp
{
    /// <summary>
    /// Descripción breve de wsUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsUsuarios : System.Web.Services.WebService
    {
        //logueo the user
        [WebMethod]
        public List<string> usuarioConect(string usuario, string password)
        {
            return new Models.ClassUsuario().usuarioConect(usuario, password);
        }
        //Consult user with identifcator
        [WebMethod]
        public List<string> usuarioConsult(int idUsuario)
        {
            return new Models.ClassUsuario().usuarioConsult(idUsuario);
        }
        //reset password
        [WebMethod]
        public string resetPass(string usuario)
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "AC367f2e82ca8c563b3dab4c8f30930095";
            const string authToken = "d0d17ab0fed92bb95a31de812048e7ba";

            TwilioClient.Init(accountSid, authToken);

            try
            {
                var message = MessageResource.Create(
                    body: "This is the ship that made the Kessel Run in fourteen parsecs?",
                    from: new Twilio.Types.PhoneNumber("+19096554933"),
                    to: new Twilio.Types.PhoneNumber("+50252637059")
                );

                Console.WriteLine(message.Sid);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
            }

            Console.Write("Press any key to continue.");
            Console.ReadKey();
            return "OK";

        }
        //new user in the database
        [WebMethod]
        public int newUsuario(string nitProve, string nom_usuarioParam, string ape_usuarioParam, string name_emailParam, string pass_emailParam, string telefonoParam, int nivelParam)
        {
            return new Models.ClassUsuario().newUsuario(nitProve, nom_usuarioParam, ape_usuarioParam, name_emailParam, pass_emailParam, telefonoParam, nivelParam);
        }
        //new user in the database
        [WebMethod]
        public int deleteUsuario(int id_user)
        {
            return new Models.ClassUsuario().deleteUsuario(id_user);
        }
        //view all user
        [WebMethod]
        public List<string> allUser()
        {
            return new Models.ClassUsuario().allUser();
        }
        //       user the system
        [WebMethod]
        public int editUsuario(string nom_usuarioParam, string ape_usuarioParam, string name_emailParam, string pass_emailParam, string telefonoParam,  int isActivo, int nivelParam, int idUser)
        {
            return new Models.ClassUsuario().editUsuario(nom_usuarioParam, ape_usuarioParam, name_emailParam, pass_emailParam, telefonoParam, isActivo, nivelParam, idUser);
        }

    }
}
    