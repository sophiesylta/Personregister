using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application
{
    public class KallenavnService : IKallenavnService
    {
        private readonly IKallenavnRepository kallenavnRepository;
        public KallenavnService(IKallenavnRepository kallenavnRepository)
        {
            this.kallenavnRepository = kallenavnRepository;
        }

        public string getKallenavn(string fornavn, string etternavn)
        {
            // finn på noe annet her
            if (fornavn == null ) fornavn = "aa";
            if (etternavn == null) etternavn = "aa";

            var kallenavn = fornavn.Substring(0, Math.Min(fornavn.Length,2)) + etternavn.Substring(0, Math.Min(etternavn.Length, 2));
            kallenavn = kallenavn.ToLower();

            return getUniktKallenavn(kallenavn);
        }

        public string getUniktKallenavn(string kallenavn)
        {
            if (kallenavn == "" || kallenavn == null) kallenavn = "aaaa";

            List<string> kallenavnListe = kallenavnRepository.getKallenavnListe(kallenavn);

            if (kallenavnListe.Count()==0) return kallenavn + "1";

            string sisteKallenavn = kallenavnListe[0];
            string nummerString = sisteKallenavn.Replace(kallenavn, "");
       
            kallenavn = kallenavn + AddIncreasedNumber(nummerString);
            return kallenavn;
        }


        public  int AddIncreasedNumber(string nummerString)
        {
            int nummer = Int32.Parse(nummerString);
            nummer += 1;
            return nummer;
        }
    }
}
