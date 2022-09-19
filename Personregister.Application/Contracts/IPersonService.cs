﻿using Personregister.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application.Contracts
{
    public interface IPersonService
    {
        public Person add(Person person);
        public List<Person> getAll();

    }
}