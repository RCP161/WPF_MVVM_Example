using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.BusinessLogic.App;
using Company.App.Core.Models;

namespace Company.App.Logic
{
    public class MainWindowService : IMainWindowService
    {
        public void SetMainContent(ModelBase1 model)
        {
            Core.Models.App.Main.Instance.ActivContent = model;
        }
    }
}
