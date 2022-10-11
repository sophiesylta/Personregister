using Personregister.Application.Contracts;
using Personregister.Application.Contracts.Repository;
using Personregister.Domene;
using Personregister.DTO;
using Optional;

namespace Personregister.Application
{
    public class PersonService : IPersonService, IDtoPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IKallenavnService kallenavnService;
        private readonly INavnService navnService;


        public PersonService(IPersonRepository personRepository, IKallenavnService kallenavnService, INavnService navnservice)
        {
            this.personRepository = personRepository;
            this.kallenavnService = kallenavnService;
            this.navnService = navnservice;

        }
        public DTOAddPerson add(DTOAddPerson personDTO)
        {
            Person person = null;
            if (personDTO.fodselsnummer.ToString().Length == 6)
            {
                var d = personDTO.fodselsnummer.ToString();
                person = add(new Person(d, personDTO.fornavn, personDTO.etternavn));

            }
            else
            {
                person = add(new Person(personDTO.fodselsnummer) { Etternavn = personDTO.etternavn, Fornavn = personDTO.fornavn });
            }

            personDTO = new DTOAddPerson() { etternavn = person.Etternavn, fornavn = person.Fornavn, fodselsnummer = Int64.Parse(person._Fødselsnummer)};
            return personDTO;
        }

        public Person add(Person person)
        {
            //Sjekke om person eksisterer, i så fall returneres denne, ellers opprett ny
            // TODO: Kall getPersonOptional og bruk Option.Match
            if (personRepository.getPerson(Int64.Parse(person._Fødselsnummer)) != null)
            {
                return person;
            }

            person.Kallenavn = kallenavnService.getKallenavn(person.Fornavn, person.Etternavn);
            personRepository.add(person);
            return person;
        }

        public Person findOrCreate(long personnummer)
        {
            // TODO: Kall IPersonRepository.getPersonOptional og bruk Option.Match
            var person = personRepository.getPerson(personnummer);

            if (person == null)
            {
                person = new Person(personnummer);
                (person.Fornavn, person.Etternavn) = navnService.getNavn(personnummer);
                add(person);
            }

            return person;
        }



        public Option<Person> getPerson(long personnummer)
        {
            return personRepository.getPersonOptional(personnummer);
        }

        public Option<Person> getPersonByKallenavn(string kallenavn)
        {
            return personRepository.getPersonByKallenavn(kallenavn);
        }

        public DTOEditPerson edit(DTOEditPerson person)
        {
            if (person.fornavn == "" || person.fornavn == null) person.fornavn = "IkkeAngittFornavn";
            if (person.etternavn == "" || person.etternavn == null) person.etternavn = "IkkeAngittEtternavn";

            // TODO: Kall getPersonOptional og bruk Option.Match
            var p = personRepository.getPerson(person.personnummer);
            if (p == null)
            {
                throw new Exception($"Person med fødselsnummer {person.personnummer} finnes ikke");
            }
            p.Fornavn = person.fornavn;
            p.Etternavn = person.etternavn;

            p.Kallenavn = kallenavnService.getUniktKallenavn(person.kallenavn);
            p = personRepository.edit(p);
            return new DTOEditPerson() { personnummer = Int64.Parse(p._Fødselsnummer), fornavn = p.Fornavn, etternavn = p.Etternavn, kallenavn = p.Kallenavn };
        }
    }
}
