using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using NLog;
using NLog.Targets;
using DocumentFormat.OpenXml;

namespace WordListener
{
    [Target("Word")]
    internal class WordTarget : TargetWithLayout
    {
        const string LOG_FILE = "Logs\\logfile.docx";
        string _pathToLogFile = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).Parent.FullName, LOG_FILE);
        string _logMessage;

        protected override void Write(LogEventInfo logEvent)
        {
            _logMessage = Layout.Render(logEvent);

            WriteToDocx();
        }

        private void WriteToDocx()
        {
            WordprocessingDocument wordDocument;
            MainDocumentPart mainPart;
            Body body;

            if (File.Exists(_pathToLogFile))
            {
                wordDocument = WordprocessingDocument.Open(_pathToLogFile, true);

                body = wordDocument.MainDocumentPart.Document.Body;
            }
            else
            {
                wordDocument = WordprocessingDocument.Create(_pathToLogFile, WordprocessingDocumentType.Document);

                mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();

                body = mainPart.Document.AppendChild(new Body());
            }

            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(_logMessage));

            wordDocument.Close();
        }
    }
}
