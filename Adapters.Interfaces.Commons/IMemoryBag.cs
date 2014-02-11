using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapters.Interfaces.Commons
{
    public interface IMemoryBag
    {
        object this[string key] { get; set; }
        bool Contains(string key);
        void Remove(string key);
        void Clear();
    }
}
