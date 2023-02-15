using Microsoft.AspNetCore.Mvc;
using PacientesApi.Data;
using PacientesApi.Models;

namespace PacientesApi.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PacienteController : ControllerBase
    {
        [HttpPost]
        public async Task InsertarPaciente([FromBody] PacienteModel paciente)
        {
            var function = new PacienteData();
            await function.InsertarPaciente(paciente);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> EditarPaciente(int id,[FromBody] PacienteModel paciente)
        {
            var function = new PacienteData();
            paciente.id= id;
            await function.EditarPacientes(paciente);

            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> EliminarPaciente(int id)
        {
            var paciente = new PacienteModel();
            paciente.id= id;
            var function = new PacienteData();
            await function.EliminarPacientes(paciente);

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<List<PacienteModel>>> MostrarPacientes()
        {
            var function = new PacienteData();
            var lista = await function.MostrarPaciente();
            return lista;
           
            
        }
     
    }
}
