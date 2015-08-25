using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnhancedSplitView.Views;
using GeekyTool.Models;
using GeekyTool.Services.SplitterMenuService;
using GeekyTool.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace EnhancedSplitView.ViewModels
{
    public class SplitterModifierViewModel : ViewModelBase, ISplitterMenuControlAware
    {
        private ISplitterMenuService menuService;

        public ISplitterMenuService MenuService
        {
            get
            {
                if (menuService == null)
                {
                    menuService = new SplitterMenuService();
                    menuService.RegisterCollection(SplitterViewModelBase.menuItems);
                }
                return menuService;
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            MenuService.RemoveItem(SplitterViewModelBase.menuItems.Last());

            return Task.FromResult(true);
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            MenuService.AddItem(new MenuItem()
            {
                Icon = "",
                Title = "Another page",
                View = typeof(HomePage)
            });

            return Task.FromResult(true);
        }
    }
}
