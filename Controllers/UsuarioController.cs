using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;
using EspacioTablero;

namespace EspacioController;
public class UsuarioController : ControllerBase
{
    private IUsuarioRepository usuarioRepository;
    private ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    //● POST /api/usuario: Permite crear un nuevo usuario.
    [HttpPost("CrearUsuario")]
    //[Route("/api/usuario")]

    public ActionResult<Usuario> CrearUsuario(Usuario usu)
    {
        usuarioRepository.Create(usu);
        return Ok(usu);
    }


    //● GET /api/usuario: Permite listar los usuarios existentes.
    [HttpGet("ListarUsuario")]
  //  [Route("/api/usuario")]

    public ActionResult<List<Usuario>> ListarUsuario()
    {
        List<Usuario> listado = usuarioRepository.GetAll();
        return Ok(listado);
    }
    //● PUT /api/tarea/{Id}/Nombre : Permite modificar un nombre de un Usuario.*/

    [HttpPut("ModificarUsuario")]
   // [Route("/api/tarea/{Id}/Nombre")]

    public ActionResult<bool> ModificarUsuario(int Id, string Nombre)
    {
        usuarioRepository.Update(Id, Nombre);
        return Ok("Usuario modificado");
    }

    //● GET /api/usuario/{Id}: Permite buscar un usuarios por id.
    [HttpPut("BuscarUsuario")]
   // [Route("/api/usuario/{Id}")]

    public ActionResult<Usuario> BuscarUsuario(int Id)
    {
        Usuario usu = new Usuario();
        usu = usuarioRepository.GetById(Id);
        return Ok(usu);
    }



}
