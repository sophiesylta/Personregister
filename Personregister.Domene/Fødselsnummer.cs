using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Personregister.Domene
{
    public class Fødselsnummer
    {
        //Enables implicit conversion from Fodselsnummer to string (you can use Fødselsnummer objects as you would use a string object)
        public static implicit operator string(Fødselsnummer fn) => fn.Fødselsdato+fn.Personnummer.ToString();

        //Enables implicit conversion to Fødselsnummer object from string and long
        public static implicit operator Fødselsnummer(string fnAsString) => new Fødselsnummer(fnAsString);
        public static implicit operator Fødselsnummer(long fnAsLong) => new Fødselsnummer(fnAsLong);

        public string Fødselsdato { get; set; }
        public int Personnummer { get; set; }


        public Fødselsnummer(long fødselsnummer)
        {
            Fødselsdato = fødselsnummer.ToString().Substring(0,6);
            Personnummer = Int32.Parse(fødselsnummer.ToString().Substring(6));
        }

        public Fødselsnummer(string fødselsdato)
        {
            string normalized = Regex.Replace(fødselsdato, @"[/:.-]", "");

            // genererer tre tilfeldige tall mellom 0 og 9
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                int r = random.Next(10);
                normalized += r;
            }

            string fødselsnummer = leggTilKontrollsifre(normalized);

            Fødselsdato = fødselsnummer.Substring(0, 6); 
            Personnummer = Int32.Parse(fødselsnummer.Substring(6));

        }
        private string leggTilKontrollsifre(string fødselsdato)
        {
            int mod10 = kontrollsiffer1(fødselsdato);

            int mod11 = kontrollsiffer2(fødselsdato + mod10);
            return fødselsdato + mod10 + mod11;

        }

        private int kontrollsiffer1(string fødselsdato)
        {
            string fødselsdatoReversed = reverseString(fødselsdato);

            int[] vekttall = { 2, 5, 4, 9, 8, 1, 6, 7, 3 };

            int sum = 0;
            for (int i = 0; i < vekttall.Length; i++)
            {
                int produkt = Int32.Parse(fødselsdatoReversed.ElementAt(i).ToString()) * vekttall[i];

                sum = sum + produkt;
            }

            if (sum % 11 == 0) return 0;
            else return 11 - sum % 11;


        }

        private int kontrollsiffer2(string fødselsdato)
        {
            string fødselsdatoReversed = reverseString(fødselsdato);

            int[] vekttall = { 2, 3, 4, 5, 6, 7, 2, 3, 4, 5 };
            int sum = 0;
            for (int i = 0; i < vekttall.Length; i++)
            {
                sum += Int32.Parse(fødselsdatoReversed.ElementAt(i).ToString()) * vekttall[i];
            }
            if (sum % 11 == 0) return 0;
            return 11 - sum % 11;
        }

        private string reverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            string reversedS = new string(charArray);

            return reversedS;
        }
    }

}
       

