using System;
using MongoDB.Driver;
using FunctionAppAcoes.Models;

namespace FunctionAppAcoes.Data
{
    public static class AcoesRepository
    {
        public  static void Save(Acao acao)
        {
            var client = new MongoClient(
                Environment.GetEnvironmentVariable("DBAcoesMongoDB"));
            IMongoDatabase db = client.GetDatabase("DBAcoesMongoDB");

            var historico =
                db.GetCollection<AcaoDocument>("HistoricoAcoes");

            var horario = DateTime.Now;
            var document = new AcaoDocument();
            document.HistLancamento = acao.Codigo + horario.ToString("yyyyMMdd-HHmmss");
            document.Codigo = acao.Codigo;
            document.Valor = acao.Valor.Value;
            document.Data = horario.ToString("yyyy-MM-dd HH:mm:ss");

            historico.InsertOne(document);
        }
    }
}