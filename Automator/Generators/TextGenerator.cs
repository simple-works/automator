using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automator
{
    class TextGenerator
    {
        private readonly Random _random;

        public string[] Words { get; set; }

        #region Constructors
        public TextGenerator()
        {
            _random = new Random();
            Words = new string[] 
            { 
                "lbanan", "tfa7", "tout", "zbda", "zit", "tikchbila", "tiwliwla", "orrrorroy"
            };
        }

        public TextGenerator(string[] words)
        {
            this.Words = words;
        }
        #endregion

        public string GetWord()
        {
            int i = _random.Next(0, Words.Length);
            return Words[i];
        }

        public string GetSentence(int minWordsCount = 5, int maxWordsCount = 20)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int wordsCount = _random.Next(minWordsCount, maxWordsCount + 1);
            for (int i = 0; i < wordsCount; i++)
            {
                stringBuilder.Append(GetWord());
                if (i < wordsCount - 1)
                {
                    stringBuilder.Append(" ");
                }
                else
                {
                    stringBuilder.Append(".");
                }
            }
            return stringBuilder.ToString();
        }

        public string GetParagraph(int minSentencesCount = 1, int maxSentencesCount = 5)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int sentencesCount = _random.Next(minSentencesCount, maxSentencesCount + 1);
            for (int i = 0; i < sentencesCount; i++)
            {
                stringBuilder.Append(GetSentence());
                if (i < sentencesCount - 1)
                {
                    stringBuilder.Append(" ");
                }
            }
            return stringBuilder.ToString();
        }

        public string GetArticle(int minParagraphsCount, int maxParagraphsCount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int ParagraphsCount = _random.Next(minParagraphsCount, maxParagraphsCount + 1);
            for (int i = 0; i < ParagraphsCount; i++)
            {
                stringBuilder.Append(GetParagraph());
                if (i < ParagraphsCount - 1)
                {
                    stringBuilder.Append(Environment.NewLine);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
