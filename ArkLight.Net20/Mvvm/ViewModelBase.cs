using System;
using System.Collections.Generic;
using System.Text;

using ArkLight.Model;

namespace ArkLight.Mvvm
{
    public class BaseViewModel : ObservableObject
    {

        bool isInitialize = false;
        public bool IsInitialize
        {
            get { return isInitialize; }
            set { SetProperty(ref isInitialize, value); }
        }

        bool isBusy = false;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
