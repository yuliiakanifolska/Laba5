using System;
using System.Text.RegularExpressions;


namespace laba_5
{
    public abstract class Text 
    {
        public int symbolCount;
        public string content;

        public Text(string content)
        {
            this.content = content;
            this.symbolCount = content.Length;
        }

        public virtual void GetTextInformation()
        {
            Console.WriteLine($"Кількість символів: {symbolCount}");
        }

        public string IdentifyAlphabet()
        {
            bool isCyrillic = false;
            bool isLatin = false;

            foreach (char c in content)
            {
                if ((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я'))
                {
                    isCyrillic = true;
                }
                else if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    isLatin = true;
                }
            }

            if (isCyrillic)
            {
                return "Кирилиця";
            }
            if (isLatin)
            {
                return "Латиниця";
            }
            return
                "Інший алфавіт";
        }
    }

    public class Sentence : Text
    {
        public Sentence(string content) : base(content)
        {
        }

        public int CountWords()
        {
            return content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
        }

        public override void GetTextInformation()
        {
            Console.WriteLine($"Речення: {content}");
            base.GetTextInformation();
        }


    }

    public class Word : Text
    {
        public Word(string content) : base(content)
        {
        }
    }


    public class Hieroglyph : Text
    {
        public Hieroglyph(string content) : base(content)
        {
        }


        public void FindCJKCharacters()
        {
            
            string[] unicodeRanges = { @"\p{IsCJKUnifiedIdeographs}", @"\p{IsHiragana}", @"\p{IsKatakana}", @"\p{IsHangulSyllables}" };
            string[] languages = { "Китайський", "Японський (Хірагана)", "Японський (Катакана)", "Корейський" };

            for (int i = 0; i < unicodeRanges.Length; i++)
            {
                MatchCollection matches = Regex.Matches(content, unicodeRanges[i]);
                foreach (Match match in matches)
                {
                    Console.WriteLine($"Ієрогліф: {match.Value}, Мова: {languages[i]}");
                }
            }
        }
    }

    public class Picture 
    {
        public Picture(string content) 
        {
        }
    }

}

