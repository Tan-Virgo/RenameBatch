using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BatchRename
{
    public abstract class Operation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public abstract string Operate(string Name, string extension, ref string Error);
        
        public abstract string GetStringName();
        public StringArguments Args { get; set; }

        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract bool Check { get; set; }
        public abstract string Image { get;  }
    }
}
