using System;

namespace TesteLogicaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-Vindo por favor entre com os valores");
            string letters = Console.ReadLine();
            string result = searchLetterRepat(letters).ToString() == " " ? "Nulo" : searchLetterRepat(letters).ToString();
            Console.WriteLine("A primeira letra repetida é: " + result);
        }

        private static char searchLetterRepat(string letters)
        {
            char letter = ' ';
            string _lettersAux = "";

            foreach (char valor in letters)
            {
                if (_lettersAux.IndexOf(valor) == -1)
                {
                    _lettersAux += valor;
                }
                else
                {
                    letter = valor;
                    break;
                }
            }
            return letter;

        }
    }
}
