using System;
using System.Collections.Generic;
using System.Text;

namespace BatchRename
{
    public class File : Folder  
    {
        public string extension { get; set; }
        public string Extension
        {
            get => extension; set
            {
                extension = value;
                Notify("Extension");
            }
        }
    }
}
