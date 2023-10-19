using Newtonsoft.Json.Linq;

namespace Playground.Wasm.Client.Services
{
    public interface ISpreadsheetService
    {
        JArray ConvertToJArray(Stream stream);
    }
}