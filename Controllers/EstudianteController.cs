using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiante.IRepositorio;
using ApiEstudiante.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api_Estudiante.Controllers
{
    [Route("api/[controller]")]
    
    public class EstudianteController : Controller
    {
        private readonly IEstudiante estudiante;

        public EstudianteController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }

        // GET api/values
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetEstudiante();
        }

        private async Task<string> GetEstudiante()
        {
            var h = await estudiante.Get();
            if(h.Equals("")){
                return "No Hay Documentos";
            } else{
                return JsonConvert.SerializeObject(await estudiante.Get());
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GetEstudianteID(id);
        }

        private async Task<string> GetEstudianteID(string id)
        {
            return JsonConvert.SerializeObject(await estudiante.Get(id) ?? new EstudianteModel());
        }

        // POST api/values
        [HttpPost]
        public async Task<string> PostAsync([FromBody]EstudianteModel value)
        {
            if(value == null){
                return "verifique los datos";
            }else{
                await estudiante.Add(value);
                return "Registrado";
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] EstudianteModel value)
        {
            if (string.IsNullOrEmpty(id))
            {
                return "ID Invalido";
            }
            value.Id = id;
            await estudiante.Update(id, value);
            return "Edición Correcta";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return "ID Invalido";
            }
            await estudiante.Remove(id);
            return "Eliminación Correcta";
        }
    }
}
