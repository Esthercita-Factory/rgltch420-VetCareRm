using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetCareRm.Consola.Models;

namespace VetCareRm.Consola.Services
{
    /// <summary>
    /// Servicio de demostración de programación asíncrona.
    /// Contiene operaciones sencillas que simulan I/O y procesamiento.
    /// </summary>
    public class AsyncDemoService
    {
        /// <summary>
        /// Simula el registro de un paciente de forma asíncrona.
        /// Muestra inicio, proceso y finalización.
        /// </summary>
        public async Task RegistrarPacienteAsync(List<Pet> pacientes)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Registro de paciente (async) ===");
            Console.ResetColor();
            Console.WriteLine("Inicio del registro async...");

            // Simular tiempo de preparación (p.ej. validaciones, acceso a recursos externos)
            await Task.Delay(800);

            // Crear un paciente ficticio para la demo
            var nuevo = new Pet
            {
                Id = Guid.NewGuid(),
                Nombre = "PacienteAsync",
                Edad = 2,
                Especie = "Perro",
                Raza = "Chihuahua",
                Sintoma = "Ninguno",
                Propietario = new Usuario { Id = Guid.NewGuid(), Nombre = "PropAsync" }
            };
            pacientes.Add(nuevo);

            Console.WriteLine("Procesando registro (simulado)...");
            await Task.Delay(800);
            Console.WriteLine($"Paciente registrado: {nuevo.Nombre} (ID: {nuevo.Id})");
            Console.WriteLine("Finalización del registro async.");
        }

        /// <summary>
        /// Simula la carga de un historial clínico.
        /// </summary>
        public async Task ObtenerHistorialAsync()
        {
            Console.WriteLine("Cargando historial clínico...");
            await Task.Delay(1000);
            Console.WriteLine("Historial cargado.");
        }

        /// <summary>
        /// Simula la agenda de una cita.
        /// </summary>
        public async Task AgendarCitaAsync()
        {
            Console.WriteLine("Agendando cita...");
            await Task.Delay(1200);
            Console.WriteLine("Cita agendada.");
        }

        /// <summary>
        /// Simula el envío de una notificación.
        /// </summary>
        public async Task EnviarNotificacionAsync()
        {
            Console.WriteLine("Enviando notificación...");
            await Task.Delay(700);
            Console.WriteLine("Notificación enviada.");
        }

        /// <summary>
        /// Ejecuta varias tareas en paralelo y espera a que todas terminen.
        /// </summary>
        public async Task DemoWhenAllAsync()
        {
            Console.WriteLine("Ejecutando demo WhenAll...");
            var tHistorial = ObtenerHistorialAsync();
            var tCita = AgendarCitaAsync();
            var tNoti = EnviarNotificacionAsync();
            await Task.WhenAll(tHistorial, tCita, tNoti);
            Console.WriteLine("Todas las tareas terminaron.");
        }

        /// <summary>
        /// Ejecuta varias tareas y muestra cuál termina primero.
        /// Después espera a que todas finalicen.
        /// </summary>
        public async Task DemoWhenAnyAsync()
        {
            Console.WriteLine("Ejecutando demo WhenAny...");
            var tHistorial = Task.Run(async () =>
            {
                await Task.Delay(1500);
                return "Historial";
            });
            var tCita = Task.Run(async () =>
            {
                await Task.Delay(1000);
                return "Cita";
            });
            var tNoti = Task.Run(async () =>
            {
                await Task.Delay(2000);
                return "Notificación";
            });

            var primera = await Task.WhenAny(tHistorial, tCita, tNoti);
            var nombrePrimera = await primera; // obtiene el string resultante
            Console.WriteLine($"Primera tarea completada: {nombrePrimera}");

            // Esperamos a que terminen las restantes (si no lo han hecho ya)
            await Task.WhenAll(tHistorial, tCita, tNoti);
            Console.WriteLine("Todas las tareas completadas.");
        }

        /// <summary>
        /// Simula la atención de varios pacientes de forma asíncrona.
        /// Cada paciente se atiende en una tarea separada usando Task.Run.
        /// </summary>
        public async Task SimularAtencionVariosPacientesAsync(List<Pet> pacientes)
        {
            if (pacientes == null || pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes para atender.");
                return;
            }

            var tareas = new List<Task>();
            foreach (var p in pacientes)
            {
                var t = Task.Run(async () =>
                {
                    Console.WriteLine($"Atendiendo a {p.Nombre} ({p.Especie})...");
                    await Task.Delay(800); // simula tiempo de atención
                    Console.WriteLine($"Atención a {p.Nombre} finalizada.");
                });
                tareas.Add(t);
            }
            await Task.WhenAll(tareas);
            Console.WriteLine("Simulación de atención a varios pacientes completada.");
        }
    }
}
