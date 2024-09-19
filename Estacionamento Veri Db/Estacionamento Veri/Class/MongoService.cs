using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Estacionamento_Veri.Class
{
    public class MongoService
    {
        public IMongoCollection<Veiculo> _carrosCollection;

        public MongoService()
        {
            //Estabelecer conexao com mongoDb
            var client = new MongoClient("mongodb+srv://iruyds:SWoKyyPzeGZOnyr4@cluster0.tjlto.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var database = client.GetDatabase("Garagem");
            _carrosCollection = database.GetCollection<Veiculo>("Veiculos");
        }

        public List<Veiculo> ObterVeiculosEstacionados()
        {
            return _carrosCollection.Find(veiculo => true).ToList();
        }

        public void InserirCarro(Veiculo carro)
        {
            _carrosCollection.InsertOne(carro);
        }
    }
}
