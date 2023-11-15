using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;
using EspacioTablero;
using System.Runtime.CompilerServices;

namespace EspacioController;

public class TableroController : ControllerBase{
    private ITableroRepository tableroRepository;
    private ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    //● POST /api/Tablero: Permite crear un tableros.
    [HttpPost("Crear_Tablero")]
    public ActionResult<Tablero> Crear_Tablero(Tablero tablero){
        tableroRepository.CrearTablero(tablero);
        return Ok(tablero);
    }
    //● GET /api/tableros: Permite listar los tableros existentes.
    [HttpGet("ListarTablero")]
    public ActionResult<List<Tablero>> ListarTablero(){
        List<Tablero> listado = tableroRepository.GetTodos();
        return Ok(listado);
    }
}