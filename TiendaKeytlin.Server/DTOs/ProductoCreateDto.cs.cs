﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TiendaKeytlin.Server.Models;

namespace TiendaKeytlin.Server.DTOs
{
    
public class ProductoCreateDto
{
    [Required(ErrorMessage = "El nombre del producto es obligatorio")]

    public string Nombre { get; set; }

    [Required(ErrorMessage = "El código del producto es obligatorio")]
    public string CodigoProducto { get; set; }
    public string? MarcaProducto { get; set; }

    [Required(ErrorMessage = "El precio de adquisición es obligatorio")]
    [Range(0, 999999, ErrorMessage = "El precio de adquisición debe estar entre 0 y 999999")]
    public decimal PrecioAdquisicion { get; set; }

    [Required(ErrorMessage = "El precio de venta es obligatorio")]
    [Range(0, 999999, ErrorMessage = "El precio de venta debe estar entre 0 y 999999")]
    public decimal PrecioVenta { get; set; }

    public string? Descripcion { get; set; }

    public string Imagen { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria")]
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "El proveedor es obligatorio")]
    public int ProveedorId { get; set; }

   public int EstadoId { get; set; }
    }

}