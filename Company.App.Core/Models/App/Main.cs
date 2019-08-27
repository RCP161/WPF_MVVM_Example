using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Models.App
{
    public class Main : ModelBase1
    {
        private Main()
        { }

        private static Main _instance;
        public static Main Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Main();

                return _instance;
            }
        }
    }
}
