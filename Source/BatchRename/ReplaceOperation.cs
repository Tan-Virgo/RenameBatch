using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BatchRename;

namespace BatchRename
{
    public class ReplaceOperation : Operation
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        public override string Name => "Replace";
        public override string Image => "Images/Replace.png";

        public override string Description => getDescription();

        public string getDescription()
        {
            var args = Args as ReplaceOperationArguments;
            return $"Replace \"{args.From}\" to \"{args.To}\" in \"{args.StringChange}\"";
        }
        public bool check = true;
        public override bool Check
        {
            get => check;
            set
            {
                check = value;
                Notify("Check");
            }
        }

        public void Notify(String Check)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Check));
        }

        public string StringChange { get; set; }

        public override string GetStringName()
        {
            return StringChange;
        }

        public override string Operate(string name, string extension, ref string Error)
        {
            var args = Args as ReplaceOperationArguments;
            var from = args.From;
            var to = args.To;
            var stringchange = args.StringChange;
            bool flag = true;
            if (stringchange == "Name")
            {
                this.StringChange = "Name";
                //không chứa from trong name
                if (!name.Contains(from))
                    flag = false;

                if (!flag)
                {
                    Error += this.Description + "\n";
                    return name;
                }

                return name.Replace(from, to);
            }
            else
            {
                this.StringChange = "Extension";
                //không chứa from trong extension
                if (!extension.Contains(from))
                    flag = false;

                if (!flag)
                {
                    Error += this.Description + "\n";
                    return extension;
                }
                return extension.Replace(from, to);
            }
        }
    }
}
