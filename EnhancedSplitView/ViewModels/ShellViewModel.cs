using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using EnhancedSplitView.Views;
using GeekyTool.Commands;
using GeekyTool.Models;
using GeekyTool.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace EnhancedSplitView.ViewModels
{
    public class ShellViewModel : SplitterViewModelBase
    {
        public ShellViewModel()
        {
            OpenPaneCommand = new DelegateCommand(() => { if (IsPaneOpen) IsPaneOpen = false; else IsPaneOpen = true; });
            PaneClosedCommand = new DelegateCommand(() => IsPaneOpen = false);
        }
        

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            var items = new List<MenuItem>()
            {
                new MenuItem()
                {
                    Icon = "",
                    Title = "Home page",
                    View = typeof(HomePage)
                },
                new MenuItem()
                {
                    Icon = "",
                    Title = "First page",
                    View = typeof(FirstPage)
                },
                new MenuItem()
                {
                    Icon = "",
                    Title = "Second page",
                    View = typeof(SecondPage)
                }
            };
            //MenuService.AddItems(items);
            SplitterMenuService.AddItems(items);

            MenuItem = MenuItems.FirstOrDefault(x => x.View == typeof(HomePage));

            return Task.FromResult(true);
        }


        public ICommand OpenPaneCommand { get; private set; }

        public ICommand PaneClosedCommand { get; private set; }

        protected override void PerformNavigationCommandDelegate(MenuItem item)
        {
            if (item.View == typeof(HomePage))
            {
                while (SplitViewFrame.CanGoBack)
                {
                    SplitViewFrame.GoBack();
                }
            }
            SplitViewFrame.Navigate(item.View);
        }
    }
}
