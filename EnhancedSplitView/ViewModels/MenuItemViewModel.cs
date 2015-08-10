using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekyTheory.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace EnhancedSplitView.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        private string glyph;
        private string text;
        private ICommand command;
        private Type navigationDestination;

        public string Glyph
        {
            get { return glyph; }
            set
            {
                if (glyph != value)
                {
                    glyph = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand Command
        {
            get { return command; }
            set
            {
                if (command != value)
                {
                    command = value;
                    OnPropertyChanged();
                }
            }
        }

        public Type NavigationDestination
        {
            get { return navigationDestination; }
            set
            {
                if (navigationDestination != value)
                {
                    navigationDestination = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsNavigation { get { return navigationDestination != null; } }

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
