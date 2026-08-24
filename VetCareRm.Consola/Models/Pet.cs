using System;

namespace VetCareRm.Consola.Models;

/// <summary>
/// Interfaz que indica que un objeto puede ser registrado en el sistema.
/// </summary>
public interface IRegistrable
{
    void Registrar();
}

/// <summary>
/// Representa una mascota (paciente) de la clínica.
/// Hereda de Animal y implementa IRegistrable.
/// </summary>
public class Pet : Animal, IRegistrable
{
    public Guid Id { get; set; }

    // Raza específica de la mascota
    public string Raza { get; set; } = string.Empty;

    public string Sintoma { get; set; } = string.Empty;

    public Usuario Propietario { get; set; } = new Usuario();

    public void Registrar()
    {
        Console.WriteLine($"Mascota registrada: {Nombre} ({Especie})");
    }

    // Override EmitirSonido to provide species‑specific sounds
    public override string EmitirSonido()
    {
        return Especie switch
        {
            "Perro" => "Guau",
            "Gato" => "Miau",
            _ => base.EmitirSonido()
        };
    }
}

/// <summary>
/// Clase base abstracta para servicios veterinarios.
/// </summary>
public abstract class ServicioVeterinario
{
    public abstract void Atender(Pet mascota);
}

/// <summary>
/// Servicio de consulta general.
/// </summary>
public class ConsultaGeneral : ServicioVeterinario
{
    public override void Atender(Pet mascota)
    {
        Console.WriteLine($"Realizando consulta general a {mascota.Nombre} ({mascota.Especie})");
    }
}

/// <summary>
/// Servicio de vacunación.
/// </summary>
public class Vacunacion : ServicioVeterinario
{
    public override void Atender(Pet mascota)
    {
        Console.WriteLine($"Aplicando vacunación a {mascota.Nombre} ({mascota.Especie})");
    }
}
