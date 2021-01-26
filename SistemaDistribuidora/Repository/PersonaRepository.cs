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
        public bool CreateCliente(int clienteId, string razonSocial, int telefono, string dirrecion, string mail, int codigoPostal, string actividadComercial, int antiguedadEnEmpresa, string cargo, int cUIT, int personaId)
        {
            try
            {
                _context.Add(new ClienteModel(razonSocial,telefono,dirrecion,mail,codigoPostal,actividadComercial,antiguedadEnEmpresa,cargo,cUIT,personaId));
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
        /// <param name="Cliente"></param>
        public void CrearConjuntoPersonaClienteUsuario(SolicitudUsuarioClienteModel Cliente)
        {
            //TODO: mejorar esto para que reconosca clientes, persona y usuarios ya existentes
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Creo la persona
                    PersonaModel persona = new PersonaModel(Cliente.DNIPersona, Cliente.NombresPersona, Cliente.ApellidosPersona, Cliente.TelefonoPersona, Cliente.CelularPersona, Cliente.MailPersona);
                    _context.Add(persona);
                    _context.SaveChanges();
                    // Creo el cliente
                    _context.Add(new ClienteModel(Cliente.RazonSocialCliente, Cliente.TelefonoCliente, Cliente.DirrecionCliente, Cliente.MailCliente, Cliente.CodigoPostalCliente, Cliente.ActividadComercialCliente , Cliente.AntiguedadEnEmpresaCliente, Cliente.CargoCliente, Cliente.CUIT,persona.PersonaId));
                    _context.SaveChanges();
                    // Creo el usuario de tipo cliente
                    _context.Add(new UsuarioModel(Cliente.NombreUsuario,Cliente.ContraseñaUsuario,Cliente.ConfirmarContraseñaUsuario,persona.PersonaId,1));
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
