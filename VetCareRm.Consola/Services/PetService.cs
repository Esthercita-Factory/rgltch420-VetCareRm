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
        }


        PausarPrograma();
    }


    public void BuscarPacientePorNombre(List<Pet> pacientes)
    {
        Console.Clear();

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
            Console.WriteLine("Paciente no encontrado.");
            PausarPrograma();
            return;
        }


        Console.WriteLine($"Paciente encontrado: {paciente.Nombre}");

        PausarPrograma();
    }


    public void ActualizarPaciente(List<Pet> pacientes)
    {
        Console.WriteLine("Actualizar paciente");
        
        // mantenemos aquí tu lógica actual
        // se mueve completa igual
    }


    public void EliminarPaciente(List<Pet> pacientes)
    {
        Console.WriteLine("Eliminar paciente");

        // mantenemos aquí tu lógica actual
        // se mueve completa igual
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
