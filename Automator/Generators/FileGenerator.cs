using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Automator
{
    class FileGenerator
    {
        private readonly Random _random;

        public string ParentDirectoryPath { get; set; }

        public FileGenerator(string parentDirPath = null)
        {
            _random = new Random();
            ParentDirectoryPath = parentDirPath;
        }

        public string CreateFile()
        {
            NumberGenerator numGen = new NumberGenerator();
            DateTimeGenerator dateGen = new DateTimeGenerator();
            TextGenerator textGen = new TextGenerator();

            string fileName = string.Format("{0}_{1}_{2}.md",
                textGen.GetWord(), numGen.GetNumber(), dateGen.GetDateTimeSafeString());
            string fileContent = textGen.GetArticle(1, 10);

            if (!string.IsNullOrWhiteSpace(ParentDirectoryPath))
            {
                fileName = Path.Combine(ParentDirectoryPath, fileName);
            }
            File.WriteAllText(fileName, fileContent);

            return fileName;
        }
    }
}
