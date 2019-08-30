using System;
using Company.Project.Core.Logic.Project;
using Company.Project.Core.Models;

namespace Company.Project.Logic
{
    public class MainWindowService : IMainWindowService
    {
        public void SetMainContent(ModelBase1 model)
        {
            Project.Core.Models.Project.Main.Instance.ActivContent = model;
        }
    }
}
