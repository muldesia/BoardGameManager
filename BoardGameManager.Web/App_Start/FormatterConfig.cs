using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace BoardGameManager.Web.App_Start
{
    public static class FormatterConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}