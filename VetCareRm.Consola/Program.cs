using VetCareRm.Consola.Models;

Console.WriteLine("======================================");
Console.WriteLine(" Clínica Veterinaria VetCare RM");
Console.WriteLine("======================================");

Console.WriteLine();
Console.WriteLine("REGISTRO DEL PROPIETARIO");

Usuario propietario = new Usuario
{
    Id = Guid.NewGuid(),
    Nombre = SolicitarTexto("Nombre del propietario: "),
    Telefono = SolicitarTexto("Teléfono del propietario: "),
    Correo = SolicitarTexto("Correo del propietario: ")
};

Console.WriteLine();
Console.WriteLine("REGISTRO DEL PACIENTE");

Pet paciente = new Pet
{
    Id = Guid.NewGuid(),
    Nombre = SolicitarTexto("Nombre de la mascota: "),
    Edad = SolicitarEdad("Edad de la mascota: "),
    Especie = SolicitarTexto("Especie: "),
    Raza = SolicitarTexto("Raza: "),
    Sintoma = SolicitarTexto("Síntoma: "),
    Propietario = propietario
};

Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine(" RESUMEN DEL REGISTRO");
Console.WriteLine("======================================");

Console.WriteLine();
Console.WriteLine("PACIENTE");
Console.WriteLine($"ID: {paciente.Id}");
Console.WriteLine($"Nombre: {paciente.Nombre}");
Console.WriteLine($"Edad: {paciente.Edad}");
Console.WriteLine($"Especie: {paciente.Especie}");
Console.WriteLine($"Raza: {paciente.Raza}");
Console.WriteLine($"Síntoma: {paciente.Sintoma}");

Console.WriteLine();
Console.WriteLine("PROPIETARIO");
Console.WriteLine($"ID: {paciente.Propietario.Id}");
Console.WriteLine($"Nombre: {paciente.Propietario.Nombre}");
Console.WriteLine($"Teléfono: {paciente.Propietario.Telefono}");
Console.WriteLine($"Correo: {paciente.Propietario.Correo}");

static string SolicitarTexto(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(entrada))
        {
            return entrada.Trim();
        }

        Console.WriteLine("Error: este campo no puede estar vacío.");
    }
}

static int SolicitarEdad(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();

        try
        {
            int edad = int.Parse(entrada ?? string.Empty);

            if (edad < 0)
            {
                Console.WriteLine(
                    "Error: la edad no puede ser negativa."
                );

                continue;
            }

            return edad;
        }
        catch (FormatException)
        {
            Console.WriteLine(
                "Error: debe ingresar un número entero."
            );
        }
        catch (OverflowException)
        {
            Console.WriteLine(
                "Error: el número ingresado es demasiado grande."
            );
        }
    }
}
