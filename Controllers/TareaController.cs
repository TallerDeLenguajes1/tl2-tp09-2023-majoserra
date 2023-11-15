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

    
}