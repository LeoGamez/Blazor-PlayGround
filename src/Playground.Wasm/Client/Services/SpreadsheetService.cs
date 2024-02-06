using MudBlazor;
using Newtonsoft.Json.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetRow = DocumentFormat.OpenXml.Spreadsheet.Row;

namespace Playground.Wasm.Client.Services
{
    public class SpreadsheetService : ISpreadsheetService
    {
        public JArray ConvertToJArray(Stream stream)
        {
            SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false);
            WorkbookPart workbookPart = doc.WorkbookPart;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            var rows = sheetData.Elements<SpreadsheetRow>();
            var headers = rows.First();
            rows = rows.Skip(1);

            var result = new JArray();

            foreach (SpreadsheetRow row in rows)
            {
                var currentObj = new JObject();
                try
                {
                    List<Cell> cells = getRowCells(headers.Count(), row);

                    foreach (var header in headers.Select((h, i) => new { Header = (Cell)h, Index = i }).ToList())
                    {
                        var cell = cells[header.Index];
                        if (cell != null)
                        {
                            var value = GetCellValue(doc, cell) ?? string.Empty;
                            currentObj.Add(GetCellValue(doc, header.Header), value);
                        }
                    }

                    result.Add(currentObj);
                }
                catch (Exception ex)
                {
                    var meessage = ex.Message;
                }
            }

            return result;
        }

        private string GetText(Cell cell, WorkbookPart part)
        {
            var cellValue = "";
            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
            {
                int id = -1;

                if (int.TryParse(cell.InnerText, out id))
                {
                    SharedStringItem item = GetSharedStringItemById(part, id);

                    if (item.Text != null)
                    {
                        cellValue = item.Text.Text;
                    }
                    else if (item.InnerText != null)
                    {
                        cellValue = item.InnerText;
                    }
                    else if (item.InnerXml != null)
                    {
                        cellValue = item.InnerXml;
                    }
                }
            }

            return cellValue;
        }

        private static SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
        {
            return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }

        private static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        private static int CellReferenceToIndex(Cell cell)
        {
            int index = 0;
            string reference = cell.CellReference.ToString().ToUpper();
            foreach (char ch in reference)
            {
                if (char.IsLetter(ch))
                {
                    int value = ch - 'A';
                    index = index == 0 ? value : (index + 1) * 26 + value;
                }
                else
                {
                    return index;
                }
            }
            return index;
        }

        private static List<Cell> getRowCells(int columnCount, SpreadsheetRow row)
        {
            const string COLUMN_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (columnCount > COLUMN_LETTERS.Length)
            {
                throw new ArgumentException(string.Format("Invalid columnCount ({0}).  Cannot be greater than {1}",
                         columnCount, COLUMN_LETTERS.Length));
            }

            List<Cell> cells = row.Descendants<Cell>().ToList();

            for (int i = 0; i < columnCount; i++)
            {
                if (i < cells.Count)
                {
                    string cellColumnReference = cells.ElementAt(i).CellReference.ToString();
                    if (cellColumnReference[0] != COLUMN_LETTERS[i])
                    {
                        cells.Insert(i, new Cell() { CellValue = new CellValue("") });
                    }
                }
                else
                {
                    cells.Insert(i, new Cell() { CellValue = new CellValue("") });
                }
            }

            return cells;
        }
    }
}
