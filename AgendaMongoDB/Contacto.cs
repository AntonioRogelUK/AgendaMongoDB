using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongoDB
{
    public class Contacto
    {
        //Name,DateBirth,Country,State,Address,Email,Phone

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("datebirth")]
        public DateTime DateBirth { get; set; } = DateTime.MinValue;

        [BsonElement("country")]
        public string Country { get; set; } = string.Empty;

        [BsonElement("state")]
        public string State { get; set; } = string.Empty;

        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        //Sobreescribira el ToString
        public override string ToString()
        {
            return $"El contacto {Name} tiene {CalcularEdad(DateBirth)} ({DateBirth}).";
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.Month < fechaNacimiento.Month || 
                (DateTime.Now.Month == fechaNacimiento.Month && DateTime.Now.Day < fechaNacimiento.Day)) 
            {
                edad--;
            }
            return edad;
        }
    }
}
