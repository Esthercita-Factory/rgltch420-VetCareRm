using System.Collections.Generic;
using System.Threading.Tasks;
using VetCareRm.Consola.Models;
using VetCareRm.Consola.Services;
using Xunit;

namespace VetCareRm.Tests
{
    public class AsyncDemoServiceTests
    {
        [Fact]
        public async Task RegistrarPacienteAsync_AddsPetToList()
        {
            var service = new AsyncDemoService();
            var pacientes = new List<Pet>();
            await service.RegistrarPacienteAsync(pacientes);
            Assert.Single(pacientes);
            Assert.Equal("PacienteAsync", pacientes[0].Nombre);
        }

        [Fact]
        public async Task DemoWhenAllAsync_CompletesWithoutException()
        {
            var service = new AsyncDemoService();
            await service.DemoWhenAllAsync();
            Assert.True(true);
        }

        [Fact]
        public async Task DemoWhenAnyAsync_Completes()
        {
            var service = new AsyncDemoService();
            await service.DemoWhenAnyAsync();
            Assert.True(true);
        }
    }
}
