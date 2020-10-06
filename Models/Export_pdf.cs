using System;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html;

namespace Cremeria.Models
{
    public class Export_pdf
	{
        public void genera_reporte(DataTable dtblTable, DataTable dtblTable2, DataTable dtblTable3, DataTable dtblTable4, DataTable dtblTable5, String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

            Font times = new Font(bfTimes, 12, Font.ITALIC, iTextSharp.text.BaseColor.RED);


            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.BLACK);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);



            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));



            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            PdfPTable table2 = new PdfPTable(dtblTable2.Columns.Count);
            PdfPTable table3 = new PdfPTable(dtblTable3.Columns.Count);
            PdfPTable table4 = new PdfPTable(dtblTable4.Columns.Count);
            PdfPTable table5 = new PdfPTable(dtblTable5.Columns.Count);
            //Table header

            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 9, 1, iTextSharp.text.BaseColor.BLACK);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                cell.BackgroundColor = WebColors.GetRGBColor("#c5d9ea");
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            for(int  i = 0; i < dtblTable2.Columns.Count; i++)
			{
                PdfPCell cell = new PdfPCell();
                cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                cell.BackgroundColor = WebColors.GetRGBColor("#c5d9ea");
                cell.AddElement(new Chunk(dtblTable2.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table2.AddCell(cell);
            }
            for (int i = 0; i < dtblTable3.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                cell.BackgroundColor = WebColors.GetRGBColor("#c5d9ea");
                cell.AddElement(new Chunk(dtblTable3.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table3.AddCell(cell);
            }
            for (int i = 0; i < dtblTable4.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                cell.BackgroundColor = WebColors.GetRGBColor("#c5d9ea");
                cell.AddElement(new Chunk(dtblTable4.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table4.AddCell(cell);
            }
            for (int i = 0; i < dtblTable5.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                cell.BackgroundColor = WebColors.GetRGBColor("#c5d9ea");
                cell.AddElement(new Chunk(dtblTable5.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table5.AddCell(cell);
            }
            //table Data

            BaseFont btnColumnData = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnData = new Font(btnColumnData, 9, 2, iTextSharp.text.BaseColor.BLACK);

            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.AddElement(new Chunk(dtblTable.Rows[i][j].ToString(), fntColumnData));
                    table.AddCell(cell);
                    //  table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            for (int i = 0; i < dtblTable2.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable2.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.AddElement(new Chunk(dtblTable2.Rows[i][j].ToString(), fntColumnData));
                    table2.AddCell(cell);
                    //  table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            for (int i = 0; i < dtblTable3.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable3.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.AddElement(new Chunk(dtblTable3.Rows[i][j].ToString(), fntColumnData));
                    table3.AddCell(cell);
                    //  table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            for (int i = 0; i < dtblTable4.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable4.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.AddElement(new Chunk(dtblTable4.Rows[i][j].ToString(), fntColumnData));
                    table4.AddCell(cell);
                    //  table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            for (int i = 0; i < dtblTable5.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable5.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.AddElement(new Chunk(dtblTable5.Rows[i][j].ToString(), fntColumnData));
                    table5.AddCell(cell);
                    //  table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Add(new Chunk("\n", fntHead));
            document.Add(new Chunk("\n", fntHead));


            //Add a line seperation
            p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));
            document.Add(table2);

            //Add a line seperation
            p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));
            document.Add(table3);
            //Add a line seperation
            p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));
            document.Add(table4);

            //Add a line seperation
            p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));
            document.Add(table5);
            document.Close();
            writer.Close();
            fs.Close();
        }
		public void ExportDatatablePdf(DataTable dtblTable, String strPdfPath, string strHeader) {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

            Font times = new Font(bfTimes, 12, Font.ITALIC, iTextSharp.text.BaseColor.RED);


            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.BLACK);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

          

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            
            //Table header
            
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 9, 1, iTextSharp.text.BaseColor.BLACK);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BorderColor =  WebColors.GetRGBColor("#c4e4ff");
                cell.BackgroundColor = WebColors.GetRGBColor("#c5d9ea");
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data

            BaseFont btnColumnData = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnData = new Font(btnColumnData, 9, 2, iTextSharp.text.BaseColor.BLACK);

            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.AddElement(new Chunk(dtblTable.Rows[i][j].ToString(), fntColumnData));
                    table.AddCell(cell);
                    //  table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }
	}
}
