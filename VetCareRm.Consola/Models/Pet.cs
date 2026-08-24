using System;
using VetCareRm.Consola.Interfaces;

namespace VetCareRm.Consola.Models;

/// <summary>
/// Interfaz que indica que un objeto puede ser registrado en el sistema.
/// </summary>
public interface IRegistrable
{
    void Registrar();
}

/// <summary>
/// Representa una mascota o paciente de la clínica.
/// Hereda de Animal e implementa IRegistrable e INotificable.
/// </summary>
public class Pet : Animal, IRegistrable, INotificable
{
    public Guid Id { get; set; }

    public string Raza { get; set; } = string.Empty;

    public string Sintoma { get; set; } = string.Empty;

    public Usuario Propietario { get; set; } = new Usuario();

    public void Registrar()
    {
        Console.WriteLine($"Mascota registrada: {Nombre} ({Especie})");
    }

    /// <summary>
    /// Simula el envío de un recordatorio de cita.
    /// </summary>
    public void EnviarNotificacion()
    {
        Console.WriteLine($"Recordatorio de cita enviado para {Nombre}.");
    }

    /// <summary>
    /// Implementación polimórfica del sonido de la mascota.
    /// </summary>
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
/// Clase base abstracta para los servicios veterinarios.
/// </summary>
public abstract class ServicioVeterinario
{
    public abstract void Atender(Pet mascota);
}

/// <summary>
/// Servicio de consulta general.
/// Implementa IAtendible para demostrar el uso de interfaces.
/// </summary>
public class ConsultaGeneral : ServicioVeterinario, IAtendible
{
    /// <summary>
    /// Método definido por IAtendible.
    /// </summary>
    public void Atender()
    {
        Console.WriteLine("Realizando consulta general.");
    }

    /// <summary>
    /// Atiende una mascota específica.
    /// Se mantiene para conservar el comportamiento de S3.
    /// </summary>
    public override void Atender(Pet mascota)
    {
        Console.WriteLine(
            $"Realizando consulta general a {mascota.Nombre} ({mascota.Especie})"
        );
    }
}

/// <summary>
/// Servicio de vacunación.
/// Implementa IAtendible para demostrar el uso de interfaces.
/// </summary>
public class Vacunacion : ServicioVeterinario, IAtendible
{
    /// <summary>
    /// Método definido por IAtendible.
    /// </summary>
    public void Atender()
    {
        Console.WriteLine("Aplicando servicio de vacunación.");
    }

    /// <summary>
    /// Atiende una mascota específica.
    /// Se mantiene para conservar el comportamiento de S3.
    /// </summary>
    public override void Atender(Pet mascota)
    {
        Console.WriteLine(
            $"Aplicando vacunación a {mascota.Nombre} ({mascota.Especie})"
        );
    }
}
