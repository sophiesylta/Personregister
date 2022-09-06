namespace Personregister.WebAPI.Models
{
    public class FødselRepository : IFødselRepository
    {
        private Personregistercontext personregistercontext;

        public FødselRepository(Personregistercontext Personregistercontext)
        {
            this.personregistercontext = Personregistercontext;

            if (personregistercontext.Fødsler.Count() == 0) {
                personregistercontext.Fødsler.Add(new Fødsel() { mor = new Person() { Fornavn = "Sophie", Etternavn = "Sylta", Personnummer = 12312312312 }, far = new Person() { Fornavn = "Trond", Etternavn = "Århus", Personnummer = 12312312312 }, fødselTid = new DateTime(2022, 12, 24, 7, 0, 0), barn = new Person() { Fornavn = "Eva", Etternavn = "Århus", Personnummer = 56756756756 } });
                personregistercontext.SaveChanges();
            }
        }

        public Fødsel add(Fødsel fødsel)
        {
            personregistercontext.Fødsler.Add(fødsel);
            personregistercontext.SaveChanges();
            return fødsel;
        }

        public List<Fødsel> getAll()
        {
            return personregistercontext.Fødsler.ToList();
        }
    }
}
