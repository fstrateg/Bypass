using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using Bypass.Models.Types;
using System.Collections.Generic;

namespace Bypass.Data.Models
{
    public class ArchiveModel : IArchiveModel
    {
        Connect _connect;
        public void SetConfiguration(Connect conect)
        {
            _connect = conect;
        }
        public ArchiveForm Filter { get; set; }
        public IEnumerable<Archive> Data { get; set; }

        public ArchiveModel()
        {
            Data = new List<Archive>();
        }
        public void Fetch()
        {
            ModelDb dbo = new ModelDb(_connect);
            Data=dbo.GetArchive(Filter);
        }
    }
}
