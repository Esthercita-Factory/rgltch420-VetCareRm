using System;
using System.Collections.Generic;
using VetCareRm.Consola.Models;
using Xunit;

namespace VetCareRm.Tests;

public class HerenciaPolimorfismoTests
{
    [Fact]
    public void Mascota_Deberia_Heredar_De_Animal()
    {
        var mascota = new Pet { Nombre = "Luna", Especie = "Gato", Edad = 2 };
        Assert.IsAssignableFrom<Animal>(mascota);
    }

    [Theory]
    [InlineData("Perro", "Guau")]
    [InlineData("Gato", "Miau")]
    [InlineData("Hamster", "Sonido genérico")]
    public void EmitirSonido_Debe_Devolver_Sonido_Correcto(string especie, string sonidoEsperado)
    {
        var mascota = new Pet { Nombre = "Test", Especie = especie };
        Assert.Equal(sonidoEsperado, mascota.EmitirSonido());
    }

    [Fact]
    public void Usuario_Deberia_Implementar_IRegistrable_Y_Tener_Mascotas()
    {
        var usuario = new Usuario { Nombre = "Juan" };
        Assert.IsAssignableFrom<IRegistrable>(usuario);
        Assert.NotNull(usuario.Mascotas);
        Assert.Empty(usuario.Mascotas);
        var mascota = new Pet { Nombre = "Rex", Especie = "Perro" };
        usuario.Mascotas.Add(mascota);
        Assert.Single(usuario.Mascotas);
    }

    [Fact]
    public void Servicios_Veterinarios_Deberian_Ejecutarse()
    {
        var mascota = new Pet { Nombre = "Bella", Especie = "Gato" };
        ServicioVeterinario consulta = new ConsultaGeneral();
        ServicioVeterinario vacunacion = new Vacunacion();
        // Ensure no exceptions are thrown
        consulta.Atender(mascota);
        vacunacion.Atender(mascota);
    }
}
