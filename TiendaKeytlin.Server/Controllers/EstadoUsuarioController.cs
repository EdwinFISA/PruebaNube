﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaKeytlin.Server.Data;
using TiendaKeytlin.Server.Models;

[Route("api/estados")]
[ApiController]
public class EstadoUsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public EstadoUsuarioController(AppDbContext context)
    {
        _context = context;
    }

    // Obtener todos los estados de usuario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstadoUsuario>>> GetEstados()
    {
        return await _context.Estados.ToListAsync();
    }

    // Obtener un estado por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<EstadoUsuario>> GetEstado(int id)
    {
        var estado = await _context.Estados.FindAsync(id);
        if (estado == null) return NotFound();
        return estado;
    }

    // Crear un nuevo estado
    [HttpPost]
    public async Task<ActionResult<EstadoUsuario>> PostEstado(EstadoUsuario estado)
    {
        _context.Estados.Add(estado);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEstado), new { id = estado.Id }, estado);
    }

    // Actualizar un estado
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEstado(int id, EstadoUsuario estado)
    {
        if (id != estado.Id) return BadRequest();
        _context.Entry(estado).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Eliminar un estado
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstado(int id)
    {
        var estado = await _context.Estados.FindAsync(id);
        if (estado == null) return NotFound();
        _context.Estados.Remove(estado);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
