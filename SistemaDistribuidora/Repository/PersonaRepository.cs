using SistemaDistribuidora.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDistribuidora.Models;

namespace SistemaDistribuidora.Repository
{
    public class PersonaRepository
    {

        private readonly DistribuidoraContext _context;
        public PersonaRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crear una nueva persona en la BD
        /// </summary>
        /// <returns></returns>
        public bool CreatePersona(int personaId, string dNI, string nombres, string apellidos, int telefono, int celular, string mail)
        {
            try
            {
                _context.Add(new PersonaModel(dNI, nombres, apellidos, telefono, celular, mail));
                _context.SaveChangesAsync();
            }
            catch { return false; }
            return true;            
        }

        /// <summary>
        /// Crear un nuevo cliente
        /// </summary>
        /// <returns></returns>
        public bool CreateCliente(int clienteId, string razonSocial, int telefono, string dirrecion, string mail, int codigoPostal, string actividadComercial, int antiguedadEnEmpresa, string cargo, int cUIT, int personaId, int localidadId)
        {
            try
            {
                _context.Add(new ClienteModel(razonSocial,telefono,dirrecion,mail,codigoPostal,actividadComercial,antiguedadEnEmpresa,cargo,cUIT, personaId, localidadId));
                _context.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Crear un nuevo usuario
        /// </summary>
        /// <returns></returns>
        public bool CreateUsuario(int usuarioId, string nombreUsuario, string contraseña, string confirmarContraseña, int personaId, int tipoUsuario)
        {
            try
            {
                _context.Add(new UsuarioModel(nombreUsuario,contraseña, confirmarContraseña, personaId, tipoUsuario));
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Crear la persona, el cliente y el usuario segun una solicitud de clienteUsuario
        /// </summary>
        /// <param name="Solicitud"></param>
        public void CrearConjuntoPersonaClienteUsuario(SolicitudUsuarioClienteModel Solicitud)
        {
            //TODO: mejorar esto para que reconosca clientes, persona y usuarios ya existentes
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Creo la persona
                    PersonaModel persona = new PersonaModel(Solicitud.DNIPersona, Solicitud.NombresPersona, Solicitud.ApellidosPersona, Solicitud.TelefonoPersona, Solicitud.CelularPersona, Solicitud.MailPersona);
                    _context.Add(persona);
                    _context.SaveChanges();
                    // Creo el cliente
                    _context.Add(new ClienteModel(Solicitud.RazonSocialCliente, Solicitud.TelefonoCliente, Solicitud.DirrecionCliente, Solicitud.MailCliente, Solicitud.CodigoPostalCliente, Solicitud.ActividadComercialCliente , Solicitud.AntiguedadEnEmpresaCliente, Solicitud.CargoCliente, Solicitud.CUIT,persona.PersonaId,Solicitud.LocalidadId));
                    _context.SaveChanges();
                    // Creo el usuario de tipo cliente
                    _context.Add(new UsuarioModel(Solicitud.NombreUsuario,Solicitud.ContraseñaUsuario,Solicitud.ConfirmarContraseñaUsuario,persona.PersonaId, Solicitud.TipoUsuarioId));
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
