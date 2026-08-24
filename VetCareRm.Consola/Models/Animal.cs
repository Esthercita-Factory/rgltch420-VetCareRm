using System;

namespace VetCareRm.Consola.Models;

/// <summary>
/// Clase base que representa un animal genérico.
/// </summary>
public class Animal
{
    /// <summary>Nombre del animal.</summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Edad del animal.</summary>
    public int Edad { get; set; }

    /// <summary>Especie del animal (ej. Perro, Gato).</summary>
    public string Especie { get; set; } = string.Empty;

    /// <summary>
    /// Emite el sonido característico del animal.
    /// Se declara virtual para que las clases derivadas puedan sobrescribirlo y demostrar polimorfismo.
    /// </summary>
    public virtual string EmitirSonido()
    {
        return "Sonido genérico";
    }
}
