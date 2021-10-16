using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BatchRename
{
    public class Folder : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string newname { get; set; }
        public string Newname
        {
            get => newname; set
            {
                newname = value;
                Notify("Newname");
            }
        }
        public string Path { get; set; }
        public string status;
        public string Status
        {
            get => status;
            set
            {
                status = value;
                Notify("Error");
            }
        }

        public string StatusDetail;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notify(string NewName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Newname));
        }
    }
}
