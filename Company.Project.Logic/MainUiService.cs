using System;
using Company.App.Core.Logic.Project;
using Company.App.Core.Models;

namespace Company.Project.Logic
{
    public class MainUiService : IMainUiService
    {
        public void SetMainContent(ModelBase1 model)
        {
            App.Core.Models.Project.Main.Instance.ActivContent = model;
        }
    }
}
