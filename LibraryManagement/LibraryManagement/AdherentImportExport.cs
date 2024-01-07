using ClosedXML.Excel;
using LibraryManagement.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class AdherentImportExport
    {
        public List<Adherent> ImportFromExcel()
        {
            List<Adherent> adherents = new List<Adherent>();

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*",
                    Title = "Select Excel File"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheet(1); // Assuming data is in the first worksheet

                        for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                        {
                            Adherent adherent = new Adherent
                            {
                                FirstName = worksheet.Cell(row, 2).Value.ToString(),
                                LastName = worksheet.Cell(row, 3).Value.ToString(),
                                Email = worksheet.Cell(row, 4).Value.ToString(),
                                Telephone = worksheet.Cell(row, 5).Value.ToString()
                                // Add other property assignments as needed
                            };

                            adherents.Add(adherent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log, show error message)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return adherents;
        }

        public void ExportToExcel(List<Adherent> adherents, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Adherents");

                    // Write header
                    worksheet.Cell(1, 1).Value = "AdherentID";
                    worksheet.Cell(1, 2).Value = "FirstName";
                    worksheet.Cell(1, 3).Value = "LastName";
                    worksheet.Cell(1, 4).Value = "Email";
                    worksheet.Cell(1, 5).Value = "PhoneNumber";

                    // Write data
                    for (int i = 0; i < adherents.Count; i++)
                    {
                        var adherent = adherents[i];

                        worksheet.Cell(i + 2, 1).Value = adherent.AdherentID;
                        worksheet.Cell(i + 2, 2).Value = adherent.FirstName;
                        worksheet.Cell(i + 2, 3).Value = adherent.LastName;
                        worksheet.Cell(i + 2, 4).Value = adherent.Email;
                        worksheet.Cell(i + 2, 5).Value = adherent.Telephone;
                        // Add other property assignments as needed
                    }

                    workbook.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log, show error message)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
