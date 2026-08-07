using VetCareRm.Consola.Models;

List<Pet> pacientes = new List<Pet>();

bool continuar = true;

while (continuar)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine(" Clínica Veterinaria VetCare RM");
    Console.WriteLine("======================================");
    Console.WriteLine();
    Console.WriteLine("1. Registrar paciente");
    Console.WriteLine("2. Listar pacientes");
    Console.WriteLine("3. Buscar paciente por nombre");
    Console.WriteLine("4. Salir");
    Console.WriteLine();

    int opcion = SolicitarOpcion("Seleccione una opción: ");

    switch (opcion)
    {
        case 1:
            RegistrarPaciente(pacientes);
            break;

        case 2:
            ListarPacientes(pacientes);
            break;

        case 3:
          BuscarPacientePorNombre(pacientes);
          break;

        case 4:
          continuar = false;
          Console.WriteLine();
          Console.WriteLine("Gracias por utilizar VetCare RM.");
          break;
        default:
            Console.WriteLine();
            Console.WriteLine("Error: la opción seleccionada no existe.");
            PausarPrograma();
            break;
    }
}

static void RegistrarPaciente(List<Pet> pacientes)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine(" REGISTRO DEL PROPIETARIO");
    Console.WriteLine("======================================");

    Usuario propietario = new Usuario
    {
        Id = Guid.NewGuid(),
        Nombre = SolicitarTexto("Nombre del propietario: "),
        Telefono = SolicitarTexto("Teléfono del propietario: "),
        Correo = SolicitarTexto("Correo del propietario: ")
    };

    Console.WriteLine();
    Console.WriteLine("======================================");
    Console.WriteLine(" REGISTRO DEL PACIENTE");
    Console.WriteLine("======================================");

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
    Console.WriteLine("Paciente registrado correctamente.");
    Console.WriteLine($"ID asignado: {paciente.Id}");
    Console.WriteLine($"Total de pacientes: {pacientes.Count}");

    PausarPrograma();
}

static void ListarPacientes(List<Pet> pacientes)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine(" LISTADO DE PACIENTES");
    Console.WriteLine("======================================");

    if (pacientes.Count == 0)
    {
        Console.WriteLine();
        Console.WriteLine("No hay pacientes registrados.");
        PausarPrograma();
        return;
    }

    foreach (Pet paciente in pacientes)
    {
        Console.WriteLine();
        Console.WriteLine("--------------------------------------");
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
    }

    Console.WriteLine();
    Console.WriteLine($"Total de pacientes: {pacientes.Count}");

    PausarPrograma();
}

static int SolicitarOpcion(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();

        try
        {
            return int.Parse(entrada ?? string.Empty);
        }
        catch (FormatException)
        {
            Console.WriteLine(
                "Error: debe ingresar el número de una opción."
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

        Console.WriteLine(
            "Error: este campo no puede estar vacío."
        );
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

static void BuscarPacientePorNombre(List<Pet> pacientes)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine(" BÚSQUEDA DE PACIENTE");
    Console.WriteLine("======================================");

    if (pacientes.Count == 0)
    {
        Console.WriteLine();
        Console.WriteLine("No hay pacientes registrados.");
        PausarPrograma();
        return;
    }

    Console.WriteLine();

    string nombreBuscado = SolicitarTexto(
        "Ingrese el nombre de la mascota: "
    );

    Pet? pacienteEncontrado = pacientes.FirstOrDefault(
        paciente => paciente.Nombre.Equals(
            nombreBuscado,
            StringComparison.OrdinalIgnoreCase
        )
    );

    if (pacienteEncontrado is null)
    {
        Console.WriteLine();
        Console.WriteLine(
            $"No se encontró un paciente llamado {nombreBuscado}."
        );

        PausarPrograma();
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Paciente encontrado correctamente.");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine($"ID: {pacienteEncontrado.Id}");
    Console.WriteLine($"Nombre: {pacienteEncontrado.Nombre}");
    Console.WriteLine($"Edad: {pacienteEncontrado.Edad}");
    Console.WriteLine($"Especie: {pacienteEncontrado.Especie}");
    Console.WriteLine($"Raza: {pacienteEncontrado.Raza}");
    Console.WriteLine($"Síntoma: {pacienteEncontrado.Sintoma}");

    Console.WriteLine();
    Console.WriteLine("PROPIETARIO");
    Console.WriteLine(
        $"Nombre: {pacienteEncontrado.Propietario.Nombre}"
    );
    Console.WriteLine(
        $"Teléfono: {pacienteEncontrado.Propietario.Telefono}"
    );
    Console.WriteLine(
        $"Correo: {pacienteEncontrado.Propietario.Correo}"
    );

    PausarPrograma();
}

static void PausarPrograma()
{
    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar...");
    Console.ReadLine();
}
