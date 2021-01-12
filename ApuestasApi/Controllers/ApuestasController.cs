using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApuestasApi.Models;
using Microsoft.AspNetCore.Http;

namespace ApuestasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApuestasController : ControllerBase
    {
        ApuestasMContext db = new ApuestasMContext();

        [HttpPost]
        public int CrearRuleta()
        {
            Ruletum ruleta = new Ruletum();
            ruleta.Activo = false;
            db.Ruleta.Add(ruleta);
            db.SaveChanges();

            return ruleta.Id;
        }

        [HttpPost]
        public string AbrirRuleta(int id)
        {
            Ruletum ruleta = db.Ruleta.Find(id);
            string mensaje = "";
            if(ruleta == null)
            {

                mensaje = "denegada";
            }
            if(ruleta.Activo)
            {

                mensaje = "denegada";
            }
            ruleta.Activo = true;
            try
            {
                db.SaveChanges();
            }
            catch
            {

                mensaje = "denegada";
            }
            mensaje = "exitosa";

            return mensaje;
        }
        [HttpPost]
        public string ApostarRuleta(int UsuarioId, decimal valorapuesta, string apuesta, int IdRuleta)
        {
            string respuesta = "";
            UsuarioApostador usuario = db.UsuarioApostadors.Find(UsuarioId);
            Ruletum ruleta = db.Ruleta.Find(IdRuleta);
            if(usuario == null)
            {
                respuesta = "Usuario no existe";
            }
            else if(usuario.Credito < valorapuesta)
            {
                respuesta = "Usuario no cuenta con suficiente crédito";
            }
            else if(ruleta == null)
            {
                respuesta = "Ruleta no existe";
            }
            else if(!ruleta.Activo)
            {
                respuesta = "Ruleta se encuentra cerrada";
            }
            else
            {
                int apuestaAux = -1;
                Int32.TryParse(apuesta, out apuestaAux);
                if(apuesta == "negro" || apuesta == "rojo" || (apuestaAux >= 0 && apuestaAux <= 36))
                {
                    Apuestum apuestau = new Apuestum();
                    apuestau.IdRuleta = IdRuleta;
                    apuestau.IdUsuario = UsuarioId;
                    apuestau.ValorApuesta = valorapuesta;
                    apuestau.FechaApuesta = DateTime.Now;
                    apuestau.Activa = true;
                    usuario.Credito = usuario.Credito - valorapuesta;
                    db.Apuesta.Add(apuestau);
                    db.SaveChanges();
                    respuesta = "Apuesta registrada correctamente";
                }
                else
                {
                    respuesta = "La apuesta no tiene el valor correcto";
                }
            }

            return respuesta;
        }
    }
}