
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiEstudiante.IRepositorio;
using ApiEstudiante.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiEstudiante.Repositorio
{
    public class Estudiante_Repositorio : IEstudiante
    {
        private readonly ObjectContext context = null; 

        public Estudiante_Repositorio(IOptions<Settings> settings)
        {
            context = new ObjectContext(settings);
        }

        public async Task Add(EstudianteModel estudiante)
        {
            await context.Estudiantes.InsertOneAsync(estudiante);
        }

        public async Task<IEnumerable<EstudianteModel>> Get()
        {
            return await context.Estudiantes.Find(x => true).ToListAsync();
        }

        public async Task<EstudianteModel> Get(string _id)
        {
            return await context.Estudiantes.Find(Builders<EstudianteModel>.Filter.Eq("Id", _id)).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string _id)
        {
            return await context.Estudiantes.DeleteOneAsync(Builders<EstudianteModel>.Filter.Eq("Id", _id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await context.Estudiantes.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string _id, EstudianteModel estudiante)
        {
            await context.Estudiantes.ReplaceOneAsync(o => o.Id.Equals(_id), estudiante);
            return "";
        }
    }
}
