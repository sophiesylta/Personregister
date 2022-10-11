﻿using Optional;
using Personregister.Domene;

namespace Personregister.Application.Contracts.Repository
{
    public interface IDødsfallRepository
    {
        List<Dødsfall> GetAll();
        Dødsfall add(Dødsfall dødsfall);
        Option<Dødsfall> getDødsfall(long personnummer);
    }
}
