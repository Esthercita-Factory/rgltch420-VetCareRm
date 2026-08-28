using VetCareRm.Consola.Models;

namespace VetCareRm.Consola.Services;

public class PetService
{
    public void RegistrarPaciente(List<Pet> pacientes)
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

    public void ListarPacientes(List<Pet> pacientes)
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
            MostrarPaciente(paciente);
        }

        PausarPrograma();
    }

    public void BuscarPacientePorNombre(List<Pet> pacientes)
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

        string nombreBuscado = SolicitarTexto(
            "Ingrese nombre del paciente: "
        );

        Pet? paciente = pacientes.FirstOrDefault(
            p => p.Nombre.Equals(
                nombreBuscado,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (paciente is null)
        {
            Console.WriteLine();
            Console.WriteLine("Paciente no encontrado.");
            PausarPrograma();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Paciente encontrado:");
        MostrarPaciente(paciente);

        PausarPrograma();
    }

    public void ActualizarPaciente(List<Pet> pacientes)
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine(" ACTUALIZAR PACIENTE");
        Console.WriteLine("======================================");

        if (pacientes.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("No hay pacientes registrados.");
            PausarPrograma();
            return;
        }

        MostrarIds(pacientes);

        Console.WriteLine();
        Console.WriteLine("Escriba 0 para volver.");

        string entrada = SolicitarTexto("ID del paciente: ");

        if (entrada == "0")
        {
            return;
        }

        if (!Guid.TryParse(entrada, out Guid id))
        {
            Console.WriteLine();
            Console.WriteLine("Error: el ID no tiene un formato válido.");
            PausarPrograma();
            return;
        }

        Pet? paciente = pacientes.FirstOrDefault(
            p => p.Id == id
        );

        if (paciente is null)
        {
            Console.WriteLine();
            Console.WriteLine("No se encontró un paciente con ese ID.");
            PausarPrograma();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Paciente seleccionado:");
        MostrarPaciente(paciente);

        Console.WriteLine();
        Console.WriteLine("Ingrese los nuevos datos.");

        paciente.Nombre = SolicitarTexto(
            $"Nombre [{paciente.Nombre}]: "
        );

        paciente.Edad = SolicitarEdad(
            $"Edad [{paciente.Edad}]: "
        );

        paciente.Especie = SolicitarTexto(
            $"Especie [{paciente.Especie}]: "
        );

        paciente.Raza = SolicitarTexto(
            $"Raza [{paciente.Raza}]: "
        );

        paciente.Sintoma = SolicitarTexto(
            $"Síntoma [{paciente.Sintoma}]: "
        );

        Console.WriteLine();
        Console.WriteLine("Paciente actualizado correctamente.");

        PausarPrograma();
    }

    public void EliminarPaciente(List<Pet> pacientes)
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

        MostrarIds(pacientes);

        Console.WriteLine();
        Console.WriteLine("Escriba 0 para volver.");

        string entrada = SolicitarTexto("ID del paciente: ");

        if (entrada == "0")
        {
            return;
        }

        if (!Guid.TryParse(entrada, out Guid id))
        {
            Console.WriteLine();
            Console.WriteLine("Error: el ID no tiene un formato válido.");
            PausarPrograma();
            return;
        }

        Pet? paciente = pacientes.FirstOrDefault(
            p => p.Id == id
        );

        if (paciente is null)
        {
            Console.WriteLine();
            Console.WriteLine("No se encontró un paciente con ese ID.");
            PausarPrograma();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Paciente seleccionado:");
        MostrarPaciente(paciente);

        Console.WriteLine();
        Console.Write("¿Desea eliminar este paciente? (S/N): ");

        string? confirmacion = Console.ReadLine();

        if (!string.Equals(
                confirmacion?.Trim(),
                "S",
                StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine();
            Console.WriteLine("Operación cancelada.");
            PausarPrograma();
            return;
        }

        pacientes.Remove(paciente);

        Console.WriteLine();
        Console.WriteLine("Paciente eliminado correctamente.");
        Console.WriteLine($"Total de pacientes: {pacientes.Count}");

        PausarPrograma();
    }

    private static void MostrarIds(List<Pet> pacientes)
    {
        Console.WriteLine();
        Console.WriteLine("Pacientes disponibles:");

        foreach (Pet paciente in pacientes)
        {
            Console.WriteLine(
                $"{paciente.Id} - {paciente.Nombre}"
            );
        }
    }

    private static void MostrarPaciente(Pet paciente)
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
        Console.WriteLine($"Nombre: {paciente.Propietario.Nombre}");
        Console.WriteLine($"Teléfono: {paciente.Propietario.Telefono}");
        Console.WriteLine($"Correo: {paciente.Propietario.Correo}");
        Console.WriteLine("--------------------------------------");
    }

    private static string SolicitarTexto(string mensaje)
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

    private static int SolicitarEdad(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);

            if (int.TryParse(Console.ReadLine(), out int edad)
                && edad >= 0)
            {
                return edad;
            }

            Console.WriteLine(
                "Error: debe ingresar una edad válida."
            );
        }
    }

    private static void PausarPrograma()
    {
        Console.WriteLine();
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}
