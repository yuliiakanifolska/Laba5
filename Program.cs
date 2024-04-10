using System;
using System.Reflection.Metadata;

namespace laba_5
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть речення:");
            string input = Console.ReadLine();

            Sentence sentence = new Sentence(input);
            sentence.GetTextInformation();
            Console.WriteLine($"Кількість слів у реченні: {sentence.CountWords()}");
            Console.WriteLine($"Алфавіт: {sentence.IdentifyAlphabet()}");

            Console.WriteLine("\nВведіть ієрогліф:");
            string hieroglyphInput = Console.ReadLine();

            Hieroglyph hieroglyph = new Hieroglyph(hieroglyphInput);
            hieroglyph.GetTextInformation();
            
            Console.WriteLine($"Походження ієрогліфа:");
            hieroglyph.FindCJKCharacters();
            Console.ReadKey();
        }
    }
}