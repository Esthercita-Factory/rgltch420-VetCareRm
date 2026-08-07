using VetCareRm.Consola.Models;
List<Pet> pacientes = new List<Pet>();
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
pacientes.Add(paciente);
Console.WriteLine();
Console.WriteLine(
    $"Pacientes registrados: {pacientes.Count}"
);
Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine(" RESUMEN DEL REGISTRO");
Console.WriteLine("======================================");

foreach (Pet pacienteRegistrado in pacientes)
{
    Console.WriteLine();
    Console.WriteLine("PACIENTE");
    Console.WriteLine($"ID: {pacienteRegistrado.Id}");
    Console.WriteLine($"Nombre: {pacienteRegistrado.Nombre}");
    Console.WriteLine($"Edad: {pacienteRegistrado.Edad}");
    Console.WriteLine($"Especie: {pacienteRegistrado.Especie}");
    Console.WriteLine($"Raza: {pacienteRegistrado.Raza}");
    Console.WriteLine($"Síntoma: {pacienteRegistrado.Sintoma}");

    Console.WriteLine();
    Console.WriteLine("PROPIETARIO");
    Console.WriteLine(
        $"ID: {pacienteRegistrado.Propietario.Id}"
    );
    Console.WriteLine(
        $"Nombre: {pacienteRegistrado.Propietario.Nombre}"
    );
    Console.WriteLine(
        $"Teléfono: {pacienteRegistrado.Propietario.Telefono}"
    );
    Console.WriteLine(
        $"Correo: {pacienteRegistrado.Propietario.Correo}"
    );
}

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
