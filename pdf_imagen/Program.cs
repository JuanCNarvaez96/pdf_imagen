using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.XObjects;


string origen = @"C:\laura.pdf";
string destino = @"C:\ext";


try
{
    using (PdfDocument pdfDocument = PdfDocument.Open(origen))
    {
        int imageCount = 1;

        foreach (Page page in pdfDocument.GetPages())
        {
            List<XObjectImage> images = page.GetImages().Cast<XObjectImage>().ToList();
            foreach (XObjectImage image in images)
            {
                byte[] imageRawBytes = image.RawBytes.ToArray();

                using (FileStream stream = new FileStream($"{destino}\\{imageCount}.png", FileMode.Create, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(imageRawBytes);
                    writer.Flush();
                }

                imageCount++;
            }
        }
    }
    Console.WriteLine("Imagenes generadas");
}
catch (Exception)
{

    throw;
}


Console.ReadKey(true);
