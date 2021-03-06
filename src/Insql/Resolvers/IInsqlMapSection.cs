﻿using System;
using System.Collections.Generic;

namespace Insql.Resolvers
{
    public interface IInsqlMapSection
    {
        Type Type { get; }

        Dictionary<string, IInsqlMapSectionElement> Elements { get; }
    }
}
