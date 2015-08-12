using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EnhancedSplitView.Views;
using GeekyTheory.Commands;
using GeekyTheory.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace EnhancedSplitView.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private bool isPaneOpen;
        private ObservableCollection<MenuItemViewModel> menu = new ObservableCollection<MenuItemViewModel>();

        public ShellViewModel()
        {
            OpenPaneCommand = new DelegateCommand(() => { if (IsPaneOpen) IsPaneOpen = false; else IsPaneOpen = true; });
            PaneClosedCommand = new DelegateCommand(() => IsPaneOpen = false);
            PerformNavigationCommand = new DelegateCommand<MenuItemViewModel>(PerformNavigationCommandDelegate, null);
        }

        public bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set
            {
                if (isPaneOpen != value)
                {
                    isPaneOpen = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return menu; }
        }
        

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            Menu.Add(new MenuItemViewModel()
            {
                Glyph = "",
                Text = "Home page",
                NavigationDestination = typeof(HomePage)
            });
            Menu.Add(new MenuItemViewModel()
            {
                Glyph = "",
                Text = "First page",
                NavigationDestination = typeof(FirstPage)
            });
            Menu.Add(new MenuItemViewModel()
            {
                Glyph = "",
                Text = "Second page",
                NavigationDestination = typeof(SecondPage)
            });

            PerformNavigationCommandDelegate(Menu.First());

            return Task.FromResult(true);
        }


        public ICommand OpenPaneCommand { get; private set; }

        public ICommand PaneClosedCommand { get; private set; }

        public ICommand PerformNavigationCommand { get; private set; }


        private void PerformNavigationCommandDelegate(MenuItemViewModel item)
        {
            if (item.NavigationDestination == typeof(HomePage))
            {
                while (SplitViewFrame.CanGoBack)
                {
                    SplitViewFrame.GoBack();
                }
            }
            SplitViewFrame.Navigate(item.NavigationDestination);
        }
    }
}
