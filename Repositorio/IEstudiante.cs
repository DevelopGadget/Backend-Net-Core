
using Web.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.IRepositorio
{
    public interface IEstudiante
    {
        Task<IEnumerable<EstudianteModel>> Get();
        Task<EstudianteModel> Get(string _id);
        Task Add(EstudianteModel estudiante);
        Task<ReplaceOneResult> Update(string _id, EstudianteModel estudiante);
        Task<DeleteResult> Remove(string _id);
        Task<DeleteResult> RemoveAll();
    }
}
