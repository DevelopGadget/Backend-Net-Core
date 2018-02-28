using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Web.Models
{
    public class EstudianteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string sNombre { get; set; }
        public int iEdad { get; set; }
        public double dEstatura { get; set; }
        public int iGrado { get; set; }


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
