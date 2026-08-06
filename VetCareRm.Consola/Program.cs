using VetCareRm.Consola.Models;

Console.WriteLine("=== Clínica Veterinaria VetCare RM ===");

Usuario propietario = new Usuario
{
    Id = Guid.NewGuid(),
    Nombre = "Roberto Meléndez",
    Telefono = "3001234567",
    Correo = "roberto" + "@email.com"
};

Pet paciente = new Pet
{
    Id = Guid.NewGuid(),
    Nombre = "Max",
    Edad = 5,
    Especie = "Perro",
    Raza = "Labrador",
    Sintoma = "Falta de apetito",
    Propietario = propietario
};

Console.WriteLine();
Console.WriteLine("Información del paciente:");
Console.WriteLine($"ID: {paciente.Id}");
Console.WriteLine($"Nombre: {paciente.Nombre}");
Console.WriteLine($"Edad: {paciente.Edad}");
Console.WriteLine($"Especie: {paciente.Especie}");
Console.WriteLine($"Raza: {paciente.Raza}");
Console.WriteLine($"Síntoma: {paciente.Sintoma}");

Console.WriteLine();
Console.WriteLine("Información del propietario:");
Console.WriteLine($"ID: {paciente.Propietario.Id}");
Console.WriteLine($"Nombre: {paciente.Propietario.Nombre}");
Console.WriteLine($"Teléfono: {paciente.Propietario.Telefono}");
Console.WriteLine($"Correo: {paciente.Propietario.Correo}");
