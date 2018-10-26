using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.App.Common
{
    public interface IMessageBoxService
    {
        InputResult Ask(string question, string title, InputOption inputOption);
        InputResult Warn(string information, string title, InputOption inputOption);
        InputResult Inform(string information, string title, InputOption inputOption);
        InputResult Error(string errorText, string title, InputOption inputOption);
    }
}
