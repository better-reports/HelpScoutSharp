using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class FolderPage : IPage<Folder>
    {
        public class Embedded
        {
            public Folder[] folders { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }

        public Folder[] entities => _embedded.folders;
    }
}
