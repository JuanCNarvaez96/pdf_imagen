// See https://aka.ms/new-console-template for more information
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.XObjects;

Console.WriteLine("Hello, World!");
string origen = @"C:\Lorena.pdf";
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
}
catch (Exception)
{

    throw;
}


Console.ReadKey(true);