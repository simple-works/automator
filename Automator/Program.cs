using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace Automator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Automator";

            string gitRepoDirPath = "automator-git-repository";
            FileGenerator fileGen = new FileGenerator(gitRepoDirPath);
            TextGenerator txtGen = new TextGenerator();
            NumberGenerator numGen = new NumberGenerator();
            DateTimeGenerator dateGen = new DateTimeGenerator("2018-01-01 00:00:00", DateTime.Now.ToString());

            if (!Directory.Exists(gitRepoDirPath)) Directory.CreateDirectory(gitRepoDirPath);

            Git git = new Git(gitRepoDirPath);
            git.Clear();

            git.Init();
            git.BranchMove("main");
            git.RemoteAdd("origin", "https://github.com/Ambratolm/test");

            Console.WriteLine();

            int cleanupPoint = 50;
            int counter = 0;
            List<string> createdFilesPaths = new List<string>();

            while (true)
            {
                string filePath = fileGen.CreateFile();
                Console.WriteLine("New file created: {0}", Path.GetFileName(filePath));
                createdFilesPaths.Add(filePath);

                git.Add(".");
                string commitMsg = string.Format("Work in Progress #{0}", numGen.GetNumber());
                git.Commit(commitMsg, dateGen.GetDateTimeString());

                int waitingTime = numGen.GetNumber(100, 1000);
                Console.WriteLine("Waiting for {0} miliseconds...", waitingTime);
                Thread.Sleep(waitingTime);

                Console.WriteLine("__________________________________________________");

                counter++;
                if (counter >= cleanupPoint)
                {
                    counter = 0;
                    Console.WriteLine("Cleanup: Deleting previously created files...");
                    try
                    {
                        foreach (string createdFilePath in createdFilesPaths)
                        {
                            File.Delete(createdFilePath);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                    git.Push("origin", "main");
                }
            }
        }
    }
}
