using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace FinanceTracker
{
    internal class FinanceTransactions
    {

        public void AddTransaction(Transaction transaction, string filepath, string worksheetname)
        {

            using (var workbook = new XLWorkbook(filepath))
            {
                var worksheet = workbook.Worksheet(worksheetname);
                var lastrow = worksheet.LastRowUsed().RowNumber() + 1;
                worksheet.Cell(lastrow, 1).Value = transaction.date;
                worksheet.Cell(lastrow, 2).Value = transaction.name;
                worksheet.Cell(lastrow, 3).Value = transaction.category;
                worksheet.Cell(lastrow, 4).Value = transaction.amount;
                var range = worksheet.Range(2, 1, lastrow, worksheet.LastColumnUsed().ColumnNumber());
                range.Sort("A", XLSortOrder.Ascending);

                workbook.Save();

            }
        }
    }
}
