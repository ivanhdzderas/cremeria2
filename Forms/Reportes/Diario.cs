using System;
using System.Collections.Generic;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html;
using System.Linq;

namespace Cremeria.Forms.Reportes
{
	public partial class Diario : Form
	{
		public Diario()
		{
			InitializeComponent();
		}

		private void Diario_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
		}

		private void button1_Click(object sender, EventArgs e)
		{

			System.IO.FileStream fs = new FileStream("Test.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
			Document document = new Document();
			document.SetPageSize(iTextSharp.text.PageSize.LETTER);
			PdfWriter writer = PdfWriter.GetInstance(document, fs);
			document.Open();

			//Report Header
			BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			Font fntHead = new Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.BLACK);
			Paragraph prgHeading = new Paragraph();
			prgHeading.Alignment = Element.ALIGN_CENTER;
			prgHeading.Add(new Chunk("Reporte diario".ToUpper(), fntHead));
			document.Add(prgHeading);
			Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
			document.Add(p);
			document.Add(new Chunk("\n", fntHead));


			string [] arreglo= { "Fecha", "Folio", "Cliente", "ESTS.", "Cond. Pago", "Total" };


			//Write the table
			PdfPTable table = new PdfPTable(new float[] { 2,2,4,2,2,2 });
			BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			Font fntColumnHeader = new Font(btnColumnHeader, 9, 1, iTextSharp.text.BaseColor.BLACK);
			for (int i = 0; i < arreglo.Count(); i++)
			{
				PdfPCell cell = new PdfPCell();
				
				cell.HorizontalAlignment = Element.ALIGN_CENTER;
				cell.BorderColor = WebColors.GetRGBColor("#c4e4ff");
				cell.BackgroundColor = WebColors.GetRGBColor("#c5d9ea");
				cell.AddElement(new Chunk(arreglo[i], fntColumnHeader));
				table.AddCell(cell);
			}


			//table Data

			BaseFont btnColumnData = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

			Font fntColumnData = new Font(btnColumnData, 9, 2, iTextSharp.text.BaseColor.BLACK);


			Models.Reports.Tickets diario = new Models.Reports.Tickets();
			using (diario)
			{
				List<Models.Reports.Tickets> dia = diario.get_tickets(dtFecha.Text, dtFecha.Text);
				if (dia.Count > 0)
				{
					foreach(Models.Reports.Tickets item in dia)
					{
						table.AddCell(new PdfPCell(new Phrase(dtFecha.Text, fntColumnData)));
						table.AddCell(new PdfPCell(new Phrase(item.Folio.ToString(), fntColumnData)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
						table.AddCell(new PdfPCell(new Phrase(item.Cliente.ToString(), fntColumnData)));
						table.AddCell(new PdfPCell(new Phrase(item.Status.ToString(), fntColumnData)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
						table.AddCell("");
						table.AddCell(new PdfPCell(new Phrase(item.Total.ToString(), fntColumnData)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
					}
				}
			}
			document.Add(table);
			document.Close();
			writer.Close();
			fs.Close();
			
		}
	}
}
