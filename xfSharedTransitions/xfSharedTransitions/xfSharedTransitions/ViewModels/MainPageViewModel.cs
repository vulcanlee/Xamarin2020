using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfSharedTransitions.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Vulcan.ServiceSample;
    using xfSharedTransitions.Views;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string Title { get; set; }
        public ObservableCollection<Monkey> AllMonkey { get; set; } = new ObservableCollection<Monkey>();
        public DelegateCommand<Monkey> MonkeyCommand { get; set; }
        public int SelectedMonkeyId { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Title = MonkeyData.Monkeys.Count.ToString();
            MonkeyCommand = new DelegateCommand<Monkey>(async x =>
            {
                SelectedMonkeyId = x.Id;

                NavigationParameters para = new NavigationParameters();
                para.Add(nameof(Monkey), x);
                await Task.Delay(100);
                await navigationService.NavigateAsync(nameof(DetailPage), para);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            int idx = 1;
            foreach (var item in MonkeyData.Monkeys)
            {
                //item.ImageUrl = "what_the_dog.jpg";
                //if (idx % 3 == 0)
                //{
                //    item.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Gelada-Pavian.jpg/320px-Gelada-Pavian.jpg";

                //}
                AllMonkey.Add(item);
                idx++;
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
