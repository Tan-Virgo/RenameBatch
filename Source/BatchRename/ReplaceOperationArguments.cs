using System;
using System.Collections.Generic;
using System.Text;

namespace BatchRename
{
    public class ReplaceOperationArguments : StringArguments
    {
        public string From { get; set; }
        public string To { get; set; }
        public string StringChange { get; set; }
    }
}
