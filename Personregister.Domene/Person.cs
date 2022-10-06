namespace Personregister.Domene
{
    public class Person
    {
        public int PersonId { get; set; }
        public string _Fødselsnummer { get; private set; }
        public Fødselsnummer Fødselsnummer { get; private set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Kallenavn { get; set; } = "";

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public Person() { }
        public Person(long fødselsnummer)
        {
            Fødselsnummer = new Fødselsnummer(fødselsnummer);
            _Fødselsnummer = Fødselsnummer.Fødselsdato + Fødselsnummer.Personnummer;
        }
        public Person(string fødselsdato, string fornavn = "", string etternavn = "", string kallenavn = "")
        {
            Fødselsnummer = new Fødselsnummer(fødselsdato);
            _Fødselsnummer = Fødselsnummer.Fødselsdato + Fødselsnummer.Personnummer;
            Fornavn = fornavn;
            Etternavn = etternavn;
            Kallenavn = kallenavn;
        }

        public Boolean erSamme(Person person)
        {
            if (this.Fornavn != person.Fornavn) return false;
            if (this.Etternavn != person.Etternavn) return false;
            return true;
        }
    }
}
