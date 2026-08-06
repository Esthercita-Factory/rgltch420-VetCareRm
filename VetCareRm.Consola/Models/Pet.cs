namespace VetCareRm.Consola.Models;

public class Pet
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public int Edad { get; set; }

    public string Especie { get; set; } = string.Empty;

    public string Raza { get; set; } = string.Empty;

    public string Sintoma { get; set; } = string.Empty;

    public Usuario Propietario { get; set; } = new Usuario();
}
