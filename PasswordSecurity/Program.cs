using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSecurity
{
    class Program
    {
        static Random rand;

        static List<char> inputChars = new List<char> {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static List<char> cypher;

        static List<char> charSelection;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Title = "Password Security";

                //Collects Seed To Generate Random Assignment
                Console.Write("Key: ");
                int seed = int.Parse(Console.ReadLine());
                rand = new Random(seed);
                charSelection = outputChars();
                cypher = new List<char>();

                //Generates Random Asignment Of Characters
                for (int i = 0; i < inputChars.Count + 1; i++)
                {
                    int c = rand.Next(0, charSelection.Count - 1);
                    cypher.Add(charSelection[c]);
                    charSelection.RemoveAt(c);
                }
                Console.Write("Password: ");
                char[] disAssembledPassword = Console.ReadLine().ToCharArray();
                for (int a = 0; a < disAssembledPassword.Length; a++)
                    disAssembledPassword[a] = cypher[(inputChars.IndexOf(disAssembledPassword[a]) + a) % inputChars.Count];
                string encryptedPass = new string(disAssembledPassword);
                Console.WriteLine("Encrypted: " + encryptedPass);
            }
        }

        static List<Char> outputChars()
        {
            return new List<char> {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '~', '_', '@', '#', '$',
            '+', '-', '*', '/','%', '=',
            '&', '|', '!', '?', ':',
            '(', ')', '{', '}', '[', ']',
            ';', ',', '.', '"', '\''};
        }
    }
}
