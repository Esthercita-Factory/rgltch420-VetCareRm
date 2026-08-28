using VetCareRm.Consola.Models;

namespace VetCareRm.Consola.Services;

public class LinqService
{
    public List<Pet> FiltrarPorEdad(List<Pet> pacientes, int edad)
    {
        return pacientes
            .Where(paciente => paciente.Edad == edad)
            .ToList();
    }

    public List<Pet> FiltrarPorEspecie(List<Pet> pacientes, string especie)
    {
        return pacientes
            .Where(paciente =>
                paciente.Especie.Equals(
                    especie,
                    StringComparison.OrdinalIgnoreCase
                ))
            .ToList();
    }

    public List<Pet> OrdenarPorNombre(List<Pet> pacientes)
    {
        return pacientes
            .OrderBy(paciente => paciente.Nombre)
            .ToList();
    }

    public List<Pet> OrdenarPorEdad(List<Pet> pacientes)
    {
        return pacientes
            .OrderBy(paciente => paciente.Edad)
            .ToList();
    }

    public Dictionary<string, List<Pet>> AgruparPorEspecie(
        List<Pet> pacientes
    )
    {
        return pacientes
            .GroupBy(paciente => paciente.Especie)
            .ToDictionary(
                grupo => grupo.Key,
                grupo => grupo.ToList()
            );
    }

    public Pet? ObtenerPacienteMasJoven(List<Pet> pacientes)
    {
        return pacientes
            .OrderBy(paciente => paciente.Edad)
            .FirstOrDefault();
    }

    public Pet? ObtenerPacienteMayor(List<Pet> pacientes)
    {
        return pacientes
            .OrderByDescending(paciente => paciente.Edad)
            .FirstOrDefault();
    }

    public Dictionary<string, int> ContarPorEspecie(
        List<Pet> pacientes
    )
    {
        return pacientes
            .GroupBy(paciente => paciente.Especie)
            .ToDictionary(
                grupo => grupo.Key,
                grupo => grupo.Count()
            );
    }

    public bool ExistePacientePorNombre(
        List<Pet> pacientes,
        string nombre
    )
    {
        return pacientes.Any(
            paciente => paciente.Nombre.Equals(
                nombre,
                StringComparison.OrdinalIgnoreCase
            )
        );
    }

    public bool TodosTienenPropietario(List<Pet> pacientes)
    {
        return pacientes.All(
            paciente => paciente.Propietario is not null
        );
    }

    public List<Pet> ConsultaCombinada(
        List<Pet> pacientes,
        string especie,
        int edadMinima
    )
    {
        return pacientes
            .Where(paciente =>
                paciente.Especie.Equals(
                    especie,
                    StringComparison.OrdinalIgnoreCase
                )
                && paciente.Edad >= edadMinima
            )
            .OrderBy(paciente => paciente.Nombre)
            .ToList();
    }
}
