using System.Text.Json.Serialization;

namespace WebApiTodoBRQ.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TarefaStatusEnum
    {
        Nova,
        Aprovada,
        Ajustes,
        Devolvida,
        Finalizada
    }
}
