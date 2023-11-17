using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;
using EspacioTablero;
using System.Runtime.CompilerServices;

namespace EspacioController;

public class TareaController : ControllerBase{
    private ITareaRepository tareaRepository;
    private ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    //● POST /api/tarea: Permite crear una Tarea.
    [HttpPost("CrearTarea")]

    public ActionResult<bool> CrearTarea(int idTablero, Tarea tarea){
        tareaRepository.CrearTarea(idTablero,tarea);
        return Ok("Se creo con exito");
    }
    //● PUT /api/Tarea/{id}/Nombre/{Nombre}: Permite modificar una Tarea.
    [HttpPost("UpdateTarea")]
    public ActionResult<bool> UpdateTarea(int id, string nombre){
        tareaRepository.Update(id, nombre);
        return Ok("Se Modifico con Exito");
    }
    //● PUT /api/Tarea/{id}/Estado/{estado}: Permite modificar el estado de una Tarea.
    [HttpPost("ModificarEstado")]
    public ActionResult<bool> ModificarEstado(int id, EstadoTarea estado){
        tareaRepository.UpdateEstado(id, estado);
        return Ok("Modificacion del Estado existosa");
    }
    //● DELETE /api/Tarea/{id}: Elimina una tarea por su ID.
    [HttpDelete("EliminarTarea")]
    public ActionResult<bool> EliminarTarea(int id){
        tareaRepository.RemoveTarea(id);
        return Ok("Eliminacion Exitosa");
    }
    //● GET /api/Tarea/{Estado}: Cantidad de tareas en un estado
    //● GET /api/Tarea/Usuario/{Id}: Listar tareas asignada a un usuario
    [HttpGet("ListarTareaUsuario")]
    public ActionResult<List<Tarea>> ListarTareaUsuario(int idUsuario){
        List<Tarea> listado = new List<Tarea>();
        listado = tareaRepository.GetTareaUsuario(idUsuario);
        return Ok(listado);
    }
    //● GET /api/Tarea/Tablero/{Id}: Listar tareas asignada de un tablero
    [HttpGet("ListarTareaTablero")]
    public ActionResult<List<Tarea>> ListarTareaTablero(int id){
        List<Tarea> listado = new List<Tarea>();
        listado = tareaRepository.GetTareaTablero(id);
        return Ok(listado);
    }

    
}