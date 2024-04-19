using System.Text.Json.Serialization;
using System.Text.Json;

namespace API.configurations
{
    public static class JsonSerializerOptionsConfig
    {
        public static JsonSerializerOptions GetJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                // Aquí puedes configurar cualquier opción de serialización que necesites
                // Por ejemplo, para evitar los ciclos de objetos:
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return options;
        }
    }
}
