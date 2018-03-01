using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.IRepositorio;
using Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Web.Controllers
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
            if(await estudiante.Get() == null){
                return "No hay documentos";
            }else{
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
            if(id.Length < 24){
                return "Verifique el id";
            }
            if(await estudiante.Get(id) == null){
                return "No hay documentos";
            }
            return JsonConvert.SerializeObject(await estudiante.Get(id));
        }
        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync([FromBody]EstudianteModel value)
        {
            if(ModelState.IsValid){
                await estudiante.Add(value);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }else{
               return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> Put(string id, [FromBody] EstudianteModel value)
        {
            if (string.IsNullOrEmpty(id) || id.Length < 24)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }           
            if(await estudiante.Get(id) == null){
               return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if(ModelState.IsValid){
               value.Id = id;
                var h = await estudiante.Update(id, value);
                if(h.MatchedCount > 0){
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }else{
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }else{
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length < 24)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if(await estudiante.Get(id) == null){
               return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var h =  await estudiante.Remove(id);
            if(h.DeletedCount > 0){
                return new HttpResponseMessage(HttpStatusCode.OK);
            }else{
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }    
       }
    }
}
