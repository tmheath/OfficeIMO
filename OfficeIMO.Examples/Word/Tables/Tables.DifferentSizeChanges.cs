using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeIMO.Word;

namespace OfficeIMO.Examples.Word {
    internal static partial class Tables {
        internal static void Example_DifferentTableSizes(string folderPath, bool openWord) {
            Console.WriteLine("[*] Creating standard document with tables of different sizes");
            string filePath = System.IO.Path.Combine(folderPath, "Document with Tables of different sizes.docx");
            using (WordDocument document = WordDocument.Create(filePath)) {
                document.AddParagraph("Table 1");
                WordTable wordTable = document.AddTable(3, 4, WordTableStyle.PlainTable1);
                wordTable.Rows[0].Cells[0].Paragraphs[0].Text = "Test 1";

                document.AddParagraph();
                document.AddParagraph();
                document.AddParagraph("Table 2 - Sized for 2000 width / Centered");
                WordTable wordTable1 = document.AddTable(2, 6, WordTableStyle.PlainTable1);
                wordTable1.Rows[0].Cells[0].Paragraphs[0].Text = "Test 1";
                wordTable1.Rows[1].Cells[0].Paragraphs[0].Text = "Test 1 - ok longer text, no autosize right?";
                wordTable1.WidthType = TableWidthUnitValues.Pct;
                wordTable1.Width = 2000;
                wordTable1.Alignment = TableRowAlignmentValues.Center;

                document.AddParagraph();
                document.AddParagraph();
                document.AddParagraph("Table 3 - By default the table is autosized for full width");
                WordTable wordTable2 = document.AddTable(3, 4, WordTableStyle.PlainTable1);
                wordTable2.Rows[0].Cells[0].Paragraphs[0].Text = "Test 1";

                document.AddParagraph();
                document.AddParagraph();
                document.AddParagraph("Table 4 - Magic number 5000 (full width)");
                WordTable wordTable3 = document.AddTable(3, 4, WordTableStyle.PlainTable1);
                wordTable3.WidthType = TableWidthUnitValues.Pct;
                wordTable3.Width = 5000;
                wordTable3.Rows[0].Cells[0].Paragraphs[0].Text = "Test 1";

                document.AddParagraph();
                document.AddParagraph();
                document.AddParagraph("Table 5 - 50% by using 2500 width (pct)");
                WordTable wordTable4 = document.AddTable(3, 4, WordTableStyle.PlainTable1);
                wordTable4.WidthType = TableWidthUnitValues.Pct;
                wordTable4.Width = 2500;
                wordTable4.Rows[0].Cells[0].Paragraphs[0].Text = "Test 1";

                document.AddParagraph();
                document.AddParagraph();
                document.AddParagraph("Table 6 - 50% by using 2500 width (pct), that we fix to full width");
                WordTable wordTable5 = document.AddTable(3, 4, WordTableStyle.PlainTable1);
                // this data is temporary just to prove things work
                wordTable5.WidthType = TableWidthUnitValues.Pct;
                wordTable5.Width = 2500;
                // lets fix it for full width
                wordTable5.DistributeColumnsEvenly();

                document.AddParagraph();
                document.AddParagraph();
                document.AddParagraph("Table 6 - 50%");
                WordTable wordTable6 = document.AddTable(3, 4, WordTableStyle.PlainTable1);
                wordTable6.SetWidthPercentage(50);

                document.AddParagraph();
                document.AddParagraph();
                document.AddParagraph("Table 6 - 75%");
                WordTable wordTable7 = document.AddTable(3, 4, WordTableStyle.PlainTable1);
                wordTable7.SetWidthPercentage(75);

                document.Save(openWord);
            }
        }
    }
}