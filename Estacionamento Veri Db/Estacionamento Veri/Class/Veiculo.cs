using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento_Veri.Class
{
    public class Veiculo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Placa { get; set; }
        public string DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public double? Duracao { get; set; }
        public double? TempoCobrado { get; set; }
        public decimal? ValorPorHora { get; set; }
        public decimal? ValorAPagar { get; set; }
    }
}
