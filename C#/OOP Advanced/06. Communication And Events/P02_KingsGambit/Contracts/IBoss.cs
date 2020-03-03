using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Contracts
{
    using System.Collections.Generic;

    public interface IBoss
    {
        IReadOnlyCollection<ISubordinate> Subordinates { get; }

        void AddSubordinate(ISubordinate subordinate);
    }
}
