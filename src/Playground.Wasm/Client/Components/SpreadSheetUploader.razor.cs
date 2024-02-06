using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Playground.Wasm.Client.Services;
using System.Text;
using Microsoft.JSInterop;

namespace Playground.Wasm.Client.Components
{
    public partial class SpreadSheetUploader
    {
        [Inject]
        ISpreadsheetService spreadsheetService { get; set; }
        [Inject]
        IJSRuntime jSRuntime { get; set; }

        string Message = "No file(s) selected";
        IReadOnlyList<IBrowserFile> selectedFiles;

        private async void OnSubmit()
        {
            try
            {
                foreach (var file in selectedFiles)
                {
                    Stream stream = file.OpenReadStream();

                    MemoryStream ms = new MemoryStream();
                    await stream.CopyToAsync(ms);
                    var result = spreadsheetService.ConvertToJArray(ms);

                    var serializedObject = result.ToString();
                    byte[] bytes = Encoding.UTF8.GetBytes(serializedObject);

                    await jSRuntime.InvokeAsync<object>(
                        "saveAsFile",
                        "data.json",
                        Convert.ToBase64String(bytes));


                    stream.Close();
                }
                Message = $"{selectedFiles.Count} file(s) uploaded on server";
                this.StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();
            Message = $"{selectedFiles.Count} file(s) selected";
            this.StateHasChanged();
        }
    }

}
