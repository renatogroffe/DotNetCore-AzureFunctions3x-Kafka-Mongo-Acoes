using MongoDB.Bson;

namespace FunctionAppAcoes.Models
{
    public class AcaoDocument
    {
        public ObjectId _id { get; set; }
        public string HistLancamento { get; set; }
        public string Codigo { get; set; }
        public string Data { get; set; }
        public double Valor { get; set; }
    }
}