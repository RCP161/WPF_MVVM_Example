using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Company.Core.App.Common;

namespace Company.UI.Views.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        // TODO : Catel IMessageService?
        public InputResult Ask(string question, string title, InputOption inputOption)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(question, title, InputOptionConverter(inputOption), MessageBoxImage.Question);
            return ResultConverter(messageBoxResult);
        }

        public InputResult Error(string errorText, string title, InputOption inputOption)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(errorText, title, InputOptionConverter(inputOption), MessageBoxImage.Error);
            return ResultConverter(messageBoxResult);
        }

        public InputResult Inform(string information, string title, InputOption inputOption)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(information, title, InputOptionConverter(inputOption), MessageBoxImage.Information);
            return ResultConverter(messageBoxResult);
        }

        public InputResult Warn(string information, string title, InputOption inputOption)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(information, title, InputOptionConverter(inputOption), MessageBoxImage.Warning);
            return ResultConverter(messageBoxResult);
        }

        private MessageBoxButton InputOptionConverter(InputOption inputOption)
        {
            switch(inputOption)
            {
                case InputOption.OK:
                    return MessageBoxButton.OK;
                case InputOption.OKCancel:
                    return MessageBoxButton.OKCancel;
                case InputOption.YesNoCancel:
                    return MessageBoxButton.YesNoCancel;
                case InputOption.YesNo:
                    return MessageBoxButton.YesNo;
                default:
                    throw new ArgumentException("No valid InputOption");
            }
        }

        private InputResult ResultConverter(MessageBoxResult messageBoxResult)
        {
            switch(messageBoxResult)
            {
                case MessageBoxResult.None:
                    return InputResult.None;
                case MessageBoxResult.OK:
                    return InputResult.OK;
                case MessageBoxResult.Cancel:
                    return InputResult.Cancel;
                case MessageBoxResult.Yes:
                    return InputResult.Yes;
                case MessageBoxResult.No:
                    return InputResult.No;
                default:
                    throw new ArgumentException("No valid MessageBoxResult");
            }
        }
    }
}
