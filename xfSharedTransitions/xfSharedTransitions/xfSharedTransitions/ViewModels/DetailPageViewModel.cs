using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xfSharedTransitions.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Vulcan.ServiceSample;
    using Prism.AppModel;

    public class DetailPageViewModel : INotifyPropertyChanged, INavigationAware, IAutoInitialize
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string SelectedMonkeyId { get; set; }
        public Monkey Monkey { get; set; }
        public DetailPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //Monkey = parameters.GetValue<Monkey>(nameof(Monkey));
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }

}
