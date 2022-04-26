﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Shawn.Utils.Interface;
using Stylet;

namespace PRM.Utils
{
    public static class MessageBoxHelper
    {
        public static bool Confirm(string content, string title = "")
        {
            if (string.IsNullOrEmpty(title))
                title = IoC.Get<ILanguageService>().Translate("messagebox_title_warning");
            var ret = IoC.Get<IWindowManager>().ShowMessageBox(content, title, buttons: MessageBoxButton.YesNo,
                buttonLabels: new Dictionary<MessageBoxResult, string>()
                {
                    { MessageBoxResult.Yes, IoC.Get<ILanguageService>().Translate("OK") },
                    { MessageBoxResult.No, IoC.Get<ILanguageService>().Translate("Cancel") },
                }, icon: MessageBoxImage.Question);
            return ret == MessageBoxResult.Yes;
        }

        public static void Info(string content, string title = "")
        {
            if (string.IsNullOrEmpty(title))
                title = IoC.Get<ILanguageService>().Translate("messagebox_title_info");
            Alert(title, content, MessageBoxImage.Information);
        }

        public static void Warning(string content, string title = "")
        {
            if (string.IsNullOrEmpty(title))
                title = IoC.Get<ILanguageService>().Translate("messagebox_title_warning");
            Alert(title, content, MessageBoxImage.Warning);
        }


        public static void ErrorAlert(string content, string title = "")
        {
            if (string.IsNullOrEmpty(title))
                title = IoC.Get<ILanguageService>().Translate("messagebox_title_error");
            Alert(title, content, MessageBoxImage.Error);
        }

        private static void Alert(string title, string content, MessageBoxImage icon)
        {
            IoC.Get<IWindowManager>().ShowMessageBox(content, title,
                buttonLabels: new Dictionary<MessageBoxResult, string>()
                {
                    { MessageBoxResult.None, IoC.Get<ILanguageService>().Translate("OK") },
                    { MessageBoxResult.Yes, IoC.Get<ILanguageService>().Translate("OK") },
                    { MessageBoxResult.OK, IoC.Get<ILanguageService>().Translate("OK") },
                }, icon: icon);
        }
    }
}