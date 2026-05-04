using ChampionLeague.utils.PDF.Interfaces;
using ChampionsLeague.Domain.EntitiesDB;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionLeague.utils.PDF
{
    public class CreatePDF : ICreatePDF
    {
        public byte[] CreatePDFDocument(List<Ticket> tickets)
        {
            using var ms = new MemoryStream();

           

            foreach (var ticket in tickets)
            {
                var doc = new Document(PageSize.A6, 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, ms);

                doc.Open();

                var header = new Paragraph("Ticket Match")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(header);

                doc.Add(new Paragraph(ticket.Match.HomeClubNavigation.Name + " VS " + ticket.Match.AwayClubNavigation.Name)
                {
                    Alignment = Element.ALIGN_CENTER
                });
                doc.Add(new Paragraph("Match held in: " + ticket.Match.Stadium.Name)
                {
                    Alignment = Element.ALIGN_LEFT
                });
                doc.Add(new Paragraph("At address: " + ticket.Match.Stadium.Address)
                {
                    Alignment = Element.ALIGN_LEFT
                });
                doc.Add(new Paragraph("On: " + ticket.Match.DateTime)
                {
                    Alignment = Element.ALIGN_LEFT
                });

                doc.Close();
            }

           

            return ms.ToArray();
        }

        private static byte[] BitmapToBytes(System.Drawing.Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
