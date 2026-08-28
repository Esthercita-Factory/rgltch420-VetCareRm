using VetCareRm.Consola.Models;
using VetCareRm.Consola.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

List<Pet> pacientes = new List<Pet>();
PetService petService = new PetService();

bool continuar = true;

while (continuar)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine(" Clínica Veterinaria VetCare RM");
    Console.WriteLine("======================================");
    Console.WriteLine();
    Console.WriteLine("GESTIÓN DE PACIENTES");
    Console.WriteLine();
    Console.WriteLine("1. Registrar paciente");
    Console.WriteLine("2. Listar pacientes");
    Console.WriteLine("3. Buscar paciente por nombre");
    Console.WriteLine("4. Actualizar paciente");
    Console.WriteLine("5. Eliminar paciente");
    Console.WriteLine();
    Console.WriteLine("CONSULTAS");
    Console.WriteLine();
    Console.WriteLine("6. Consultar pacientes");
    Console.WriteLine("7. Operaciones de atención");
    Console.WriteLine();
    Console.WriteLine("8. Salir");
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
            petService.BuscarPacientePorNombre(pacientes);
            break;

        case 4:
            ActualizarPaciente(pacientes);
            break;

        case 5:
            EliminarPaciente(pacientes);
            break;

        case 6:
            MenuConsultasLinq(pacientes);
            break;

        case 7:
            await DemoAsyncMenu(pacientes);
            break;

        case 8:
            continuar = false;
            Console.WriteLine();
            Console.WriteLine("Gracias por utilizar VetCare RM.");
            break;
        default:
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: la opción seleccionada no existe.");
            Console.ResetColor();
            PausarPrograma();
            break;
    }
}

// ---------------------------------------------------
// Demonstración de herencia, polimorfismo, relaciones y servicios
// ---------------------------------------------------
static async Task DemoAsyncMenu(List<Pet> pacientes)
{
    var service = new AsyncDemoService();
    bool volver = false;
    while (!volver)
    {
        Console.Clear();
        Console.WriteLine("=== DEMOSTRACIÓN PROGRAMACIÓN ASÍNCRONA ===");
        Console.WriteLine("1. Registrar paciente de forma asíncrona");
        Console.WriteLine("2. Ejecutar tareas con WhenAll");
        Console.WriteLine("3. Ejecutar tareas con WhenAny");
        Console.WriteLine("4. Simular atención de varios pacientes");
        Console.WriteLine("0. Volver al menú principal");
        Console.WriteLine();
        int opt = SolicitarOpcion("Seleccione una opción: ");
        switch (opt)
        {
            case 1:
                await service.RegistrarPacienteAsync(pacientes);
                break;
            case 2:
                await service.DemoWhenAllAsync();
                break;
            case 3:
                await service.DemoWhenAnyAsync();
                break;
            case 4:
                await service.SimularAtencionVariosPacientesAsync(pacientes);
                break;
            case 0:
                volver = true;
                continue;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción no válida.");
                Console.ResetColor();
                break;
        }
        PausarPrograma();
    }
}

static void DemoHerenciaPolimorfismo(List<Pet> pacientes)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("=== DEMOSTRACIÓN DE HERENCIA Y POLIMORFISMO ===");
    Console.ResetColor();

    // crear propietario y mascota
    var propietario = new Usuario
    {
        Id = Guid.NewGuid(),
        Nombre = "Ana Gómez",
        Telefono = "555-1234",
        Correo = "ana@example.com"
    };

    var mascota = new Pet
    {
        Id = Guid.NewGuid(),
        Nombre = "Firulais",
        Edad = 3,
        Especie = "Perro",
        Raza = "Labrador",
        Sintoma = "Saludable",
        Propietario = propietario
    };

    // registrar
    mascota.Registrar();
    propietario.Registrar();

    // añadir a la lista del propietario
    propietario.Mascotas.Add(mascota);
    pacientes.Add(mascota);

    // Polimorfismo: sonido según especie
    Console.WriteLine($"El sonido de {mascota.Nombre} ({mascota.Especie}) es: {mascota.EmitirSonido()}");

    // Servicios veterinarios
    ServicioVeterinario consulta = new ConsultaGeneral();
    ServicioVeterinario vacunacion = new Vacunacion();
    consulta.Atender(mascota);
    vacunacion.Atender(mascota);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Demostración completada exitosamente.");
    Console.ResetColor();
    PausarPrograma();
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

static void ActualizarPaciente(List<Pet> pacientes)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine(" ACTUALIZACIÓN DE PACIENTE");
    Console.WriteLine("======================================");

    if (pacientes.Count == 0)
    {
        Console.WriteLine();
        Console.WriteLine("No hay pacientes registrados.");
        PausarPrograma();
        return;
    }

    Console.WriteLine();
    Console.WriteLine(
        "Consulte primero el listado para conocer el ID del paciente."
    );

    Console.WriteLine();

    Guid idBuscado = SolicitarGuid(
        "Ingrese el ID del paciente: "
    );

    Pet? pacienteEncontrado = pacientes.FirstOrDefault(
        paciente => paciente.Id == idBuscado
    );

    if (pacienteEncontrado is null)
    {
        Console.WriteLine();
        Console.WriteLine(
            "No se encontró un paciente con ese ID."
        );

        PausarPrograma();
        return;
    }

    Console.WriteLine();
    Console.WriteLine("DATOS ACTUALES DEL PACIENTE");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine($"Nombre: {pacienteEncontrado.Nombre}");
    Console.WriteLine($"Edad: {pacienteEncontrado.Edad}");
    Console.WriteLine($"Especie: {pacienteEncontrado.Especie}");
    Console.WriteLine($"Raza: {pacienteEncontrado.Raza}");
    Console.WriteLine($"Síntoma: {pacienteEncontrado.Sintoma}");

    Console.WriteLine();
    Console.WriteLine("DATOS ACTUALES DEL PROPIETARIO");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine(
        $"Nombre: {pacienteEncontrado.Propietario.Nombre}"
    );
    Console.WriteLine(
        $"Teléfono: {pacienteEncontrado.Propietario.Telefono}"
    );
    Console.WriteLine(
        $"Correo: {pacienteEncontrado.Propietario.Correo}"
    );

    Console.WriteLine();
    Console.WriteLine("INGRESE LOS NUEVOS DATOS DEL PACIENTE");
    Console.WriteLine("--------------------------------------");

    pacienteEncontrado.Nombre = SolicitarTexto(
        "Nuevo nombre de la mascota: "
    );

    pacienteEncontrado.Edad = SolicitarEdad(
        "Nueva edad de la mascota: "
    );

    pacienteEncontrado.Especie = SolicitarTexto(
        "Nueva especie: "
    );

    pacienteEncontrado.Raza = SolicitarTexto(
        "Nueva raza: "
    );

    pacienteEncontrado.Sintoma = SolicitarTexto(
        "Nuevo síntoma: "
    );

    Console.WriteLine();
    Console.WriteLine("INGRESE LOS NUEVOS DATOS DEL PROPIETARIO");
    Console.WriteLine("--------------------------------------");

    pacienteEncontrado.Propietario.Nombre = SolicitarTexto(
        "Nuevo nombre del propietario: "
    );

    pacienteEncontrado.Propietario.Telefono = SolicitarTexto(
        "Nuevo teléfono del propietario: "
    );

    pacienteEncontrado.Propietario.Correo = SolicitarTexto(
        "Nuevo correo del propietario: "
    );

    Console.WriteLine();
    Console.WriteLine("Paciente actualizado correctamente.");
    Console.WriteLine($"ID conservado: {pacienteEncontrado.Id}");

    PausarPrograma();
}

static Guid SolicitarGuid(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();

        bool esValido = Guid.TryParse(
            entrada,
            out Guid id
        );

        if (esValido)
        {
            return id;
        }

        Console.WriteLine(
            "Error: debe ingresar un ID válido."
        );
    }
}

static void EliminarPaciente(List<Pet> pacientes)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine(" ELIMINAR PACIENTE");
    Console.WriteLine("======================================");

    if (pacientes.Count == 0)
    {
        Console.WriteLine();
        Console.WriteLine("No hay pacientes registrados.");
        PausarPrograma();
        return;
    }

    Guid idBuscado = SolicitarGuid(
        "Ingrese el ID del paciente: "
    );

    Pet? pacienteEncontrado = pacientes.FirstOrDefault(
        paciente => paciente.Id == idBuscado
    );


    if (pacienteEncontrado is null)
    {
        Console.WriteLine();
        Console.WriteLine(
            "No existe un paciente con ese ID."
        );

        PausarPrograma();
        return;
    }


    Console.WriteLine();
    Console.WriteLine("Paciente encontrado:");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine(
        $"Nombre: {pacienteEncontrado.Nombre}"
    );
    Console.WriteLine(
        $"Propietario: {pacienteEncontrado.Propietario.Nombre}"
    );


    Console.WriteLine();
    Console.Write(
        "¿Desea eliminar este paciente? (S/N): "
    );

    string? respuesta = Console.ReadLine();


    if (
        respuesta != null &&
        respuesta.Equals(
            "S",
            StringComparison.OrdinalIgnoreCase
        )
    )
    {
        pacientes.Remove(pacienteEncontrado);

        Console.WriteLine();
        Console.WriteLine(
            "Paciente eliminado correctamente."
        );
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine(
            "Operación cancelada."
        );
    }


    PausarPrograma();
}

static void PausarPrograma()
{
    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar...");
    Console.ReadLine();
}


static void MenuConsultasLinq(List<Pet> pacientes)
{
    LinqService linqService = new LinqService();

    bool volver = false;

    while (!volver)
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("          CONSULTAS LINQ");
        Console.WriteLine("======================================");
        Console.WriteLine();
        Console.WriteLine("1. Buscar pacientes por edad");
        Console.WriteLine("2. Buscar mascotas por especie");
        Console.WriteLine("3. Ordenar pacientes por nombre");
        Console.WriteLine("4. Ordenar pacientes por edad");
        Console.WriteLine("5. Agrupar mascotas por especie");
        Console.WriteLine("6. Mostrar paciente más joven");
        Console.WriteLine("7. Mostrar paciente de mayor edad");
        Console.WriteLine("8. Contar mascotas por especie");
        Console.WriteLine("9. Verificar existencia de paciente");
        Console.WriteLine("10. Verificar propietarios");
        Console.WriteLine("11. Consulta combinada");
        Console.WriteLine("0. Volver");
        Console.WriteLine();

        int opcion = SolicitarOpcion("Seleccione una opción: ");

        switch (opcion)
        {
            case 1:
                int edad = SolicitarEdad(
                    "Ingrese la edad que desea buscar: "
                );

                MostrarPacientes(
                    linqService.FiltrarPorEdad(pacientes, edad)
                );

                PausarPrograma();
                break;

            case 2:
                string especie = SolicitarTexto(
                    "Ingrese la especie que desea buscar: "
                );

                MostrarPacientes(
                    linqService.FiltrarPorEspecie(
                        pacientes,
                        especie
                    )
                );

                PausarPrograma();
                break;

            case 3:
                MostrarPacientes(
                    linqService.OrdenarPorNombre(pacientes)
                );

                PausarPrograma();
                break;

            case 4:
                MostrarPacientes(
                    linqService.OrdenarPorEdad(pacientes)
                );

                PausarPrograma();
                break;

            case 5:
                MostrarAgrupacionPorEspecie(
                    linqService.AgruparPorEspecie(pacientes)
                );

                PausarPrograma();
                break;

            case 6:
                MostrarPaciente(
                    linqService.ObtenerPacienteMasJoven(pacientes),
                    "PACIENTE MÁS JOVEN"
                );

                PausarPrograma();
                break;

            case 7:
                MostrarPaciente(
                    linqService.ObtenerPacienteMayor(pacientes),
                    "PACIENTE DE MAYOR EDAD"
                );

                PausarPrograma();
                break;

            case 8:
                MostrarConteoPorEspecie(
                    linqService.ContarPorEspecie(pacientes)
                );

                PausarPrograma();
                break;

            case 9:
                string nombre = SolicitarTexto(
                    "Ingrese el nombre del paciente: "
                );

                bool existe = linqService.ExistePacientePorNombre(
                    pacientes,
                    nombre
                );

                Console.WriteLine();

                if (existe)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        "El paciente existe."
                    );
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "El paciente no existe."
                    );
                }

                Console.ResetColor();
                PausarPrograma();
                break;

            case 10:
                bool todosTienenPropietario =
                    linqService.TodosTienenPropietario(pacientes);

                Console.WriteLine();

                if (todosTienenPropietario)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        "Todos los pacientes tienen propietario."
                    );
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "Existe un paciente sin propietario."
                    );
                }

                Console.ResetColor();
                PausarPrograma();
                break;

            case 11:
                string especieConsulta = SolicitarTexto(
                    "Ingrese la especie: "
                );

                int edadMinima = SolicitarEdad(
                    "Ingrese la edad mínima: "
                );

                MostrarPacientes(
                    linqService.ConsultaCombinada(
                        pacientes,
                        especieConsulta,
                        edadMinima
                    )
                );

                PausarPrograma();
                break;

            case 0:
                volver = true;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "Opción no válida."
                );
                Console.ResetColor();
                PausarPrograma();
                break;
        }
    }
}

static void MostrarPacientes(List<Pet> pacientes)
{
    Console.WriteLine();

    if (pacientes.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(
            "No se encontraron pacientes."
        );
        Console.ResetColor();
        return;
    }

    Console.WriteLine("--------------------------------------");

    foreach (Pet paciente in pacientes)
    {
        Console.WriteLine(
            $"{paciente.Nombre} | " +
            $"{paciente.Especie} | " +
            $"{paciente.Edad} años"
        );
    }

    Console.WriteLine("--------------------------------------");
    Console.WriteLine(
        $"Total encontrados: {pacientes.Count}"
    );
}

static void MostrarPaciente(Pet? paciente, string titulo)
{
    Console.WriteLine();
    Console.WriteLine(titulo);
    Console.WriteLine("--------------------------------------");

    if (paciente is null)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("No hay pacientes registrados.");
        Console.ResetColor();
        return;
    }

    Console.WriteLine($"Nombre: {paciente.Nombre}");
    Console.WriteLine($"Edad: {paciente.Edad}");
    Console.WriteLine($"Especie: {paciente.Especie}");
    Console.WriteLine($"Raza: {paciente.Raza}");
}

static void MostrarAgrupacionPorEspecie(
    Dictionary<string, List<Pet>> grupos
)
{
    Console.WriteLine();
    Console.WriteLine("MASCOTAS AGRUPADAS POR ESPECIE");
    Console.WriteLine("--------------------------------------");

    if (grupos.Count == 0)
    {
        Console.WriteLine("No hay pacientes registrados.");
        return;
    }

    foreach (var grupo in grupos)
    {
        Console.WriteLine();
        Console.WriteLine(
            $"{grupo.Key}: {grupo.Value.Count} mascota(s)"
        );

        foreach (Pet paciente in grupo.Value)
        {
            Console.WriteLine($"  - {paciente.Nombre}");
        }
    }
}

static void MostrarConteoPorEspecie(
    Dictionary<string, int> conteos
)
{
    Console.WriteLine();
    Console.WriteLine("CANTIDAD DE MASCOTAS POR ESPECIE");
    Console.WriteLine("--------------------------------------");

    if (conteos.Count == 0)
    {
        Console.WriteLine("No hay pacientes registrados.");
        return;
    }

    foreach (var conteo in conteos)
    {
        Console.WriteLine(
            $"{conteo.Key}: {conteo.Value}"
        );
    }
}
