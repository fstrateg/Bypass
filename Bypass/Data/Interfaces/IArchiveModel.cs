using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Interfaces
{
    public interface IArchiveModel
    {
        void SetConfiguration(Connect conect);
        IEnumerable<Archive> Data { get; set; }

        void Fetch();

        ArchiveForm Filter { get; set; }

    }
}
