using System;
using System.Collections.Generic;

namespace VetCareRm.Consola.Models;

/// <summary>
/// Representa al propietario de una o varias mascotas.
/// </summary>
public class Usuario : IRegistrable
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    // Cada propietario puede tener varias mascotas
    public List<Pet> Mascotas { get; set; } = new List<Pet>();

    public void Registrar()
    {
        Console.WriteLine($"Propietario registrado: {Nombre}");
    }
}
