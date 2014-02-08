using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using Adapters.Interfaces.Commons;

namespace Shared.Commons
{
    public class MemoryBag
    {
        private static IMemoryBag _current;

        public static IMemoryBag Current
        {
            get
            {
                if (_current == null)
                    _current = ObjectFactory.GetInstance<IMemoryBag>();

                return _current;
            }
        }
    }
}
