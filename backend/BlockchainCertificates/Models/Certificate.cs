using System;
using System.Drawing.Imaging;
using System.IO;
using SelectPdf;

namespace BlockchainCertificates.Models
{
    public class Certificate
    {
        private static readonly HtmlToImage Converter = new HtmlToImage();

        private string Name { get; }
        private string Program { get; }
        private int Grade { get; }
        private string Date { get; }

        public Certificate(string name, string program, int grade, string date)
        {
            Name = name;
            Program = program;
            Grade = grade;
            Date = date;
        }

        public MemoryStream GenerateCert()
        {
            var image = Converter.ConvertHtmlString(GenerateHtmlTemplate());
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            return ms;
        }

        private string GenerateHtmlTemplate()
        {
            return $@"
                <div style=""width:1047px; height:715px; padding:20px; text-align:center; border: 10px solid #787878"">
                <div style=""width:997px; height:665px; padding:20px; text-align:center; border: 5px solid #787878"">
                    <br><br>
                    <span style=""font-size:50px; font-weight:bold"">Mantle University</span>
                    <br><br><br><br>
                    <span style=""font-size:25px""><i> This is to certify that </i></span>
                    <br><br>
                    <span style=""font-size:30px""><b>{Name}</b></span>
                    <br><br><br><br>
                    <span style=""font-size:25px""><i> has completed the program </i></span>
                    <br><br>
                    <span style=""font-size:30px"">{Program}</span> <br/><br/>
                    <span style=""font-size:20px""> with an average score of <b>{Grade}%</b></span>
                    <br><br><br><br><br><br><br><br>
                    <img style=""position:absolute; left:100px; top:450px; width:250px; height:250px"" 
                        src=""{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)}/logo.png""/>
                    <span style=""font-size:25px""><i> dated </i></span><br>
                    <span style=""font-size:30px"">{Date}</span>
                </div>
                </div>";
        }
    }
}
