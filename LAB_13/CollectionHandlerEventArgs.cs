using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_13
{
    public class CollectionHandlerEventArgs: System.EventArgs
    {
        public string changeType = "";
        public string ChangeType
        {
            get => changeType;
            set => changeType = value;
        }

        public object changeObject;
        public object ChangeObject
        {
            get => changeObject;
            set => changeObject = value;
        }

        public CollectionHandlerEventArgs(string changeType, object changeObject)
        {
            ChangeType = changeType;
            ChangeObject = changeObject;
        }
    }
}
