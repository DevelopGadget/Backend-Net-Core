using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
   public class EstudianteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string sNombre { get; set; }
        [Required]
        public int? iEdad { get; set; }
        [Required]
        public double? dEstatura { get; set; }
        [Required]
        public int? iGrado { get; set; }
        public EstudianteModel(string sNombre, int iEdad, double dEstatura, int iGrado)
        {
            this.sNombre = sNombre;
            this.iEdad = iEdad;
            this.dEstatura = dEstatura;
            this.iGrado = iGrado;     
        }
        public EstudianteModel()
        {
        }
    }
}
