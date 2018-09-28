using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls.Dialogs;
using SHM.UI.Extensions;
using SHM.UI.Pages;
using SHM.Utilities;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;

namespace SHM.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModel
    {
        public IDialogCoordinator Dialog { get; set; }
        public MainViewModel(ViewModelLocator locator) : base(locator)
        {
            Dialog = DialogCoordinator.Instance;
            LaunchCommand = new RelayCommand<string>(Launch);

            SimpleIoc.Default.Reregister<Home>();
            SimpleIoc.Default.Reregister<Settings>();
            SimpleIoc.Default.Reregister<Homebrews>();

            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
            GoToCommand = new RelayCommand<string>(GoTo);
            GoTo<Home>();
        }

        public RelayCommand<string> LaunchCommand { get; protected set; }
        void Launch(string item) => Process.Start(item);

        Page currentPage;
        public Page CurrentPage { get { return currentPage; } set { Set(ref currentPage, value); } }

        Stack<Page> pageStack = new Stack<Page>();
        public RelayCommand<string> GoToCommand { get; set; }
        public void GoTo<TPage>() where TPage : Page
        {
            if (CurrentPage != null) pageStack.Push(CurrentPage);
            CurrentPage = SimpleIoc.Default.GetInstance<TPage>();
            GoBackCommand.RaiseCanExecuteChanged();
        }
        public void GoTo(string page)
        {
            switch (page)
            {
                case nameof(Home): GoTo<Home>(); break;
                case nameof(Settings): GoTo<Settings>(); break;
                case nameof(Homebrews): GoTo<Homebrews>(); break;
                default:
                    break;
            }
        }
        public RelayCommand GoBackCommand { get; protected set; }
        bool CanGoBack() => pageStack.Any();
        void GoBack()
        {
            CurrentPage = pageStack.Pop();
            GoBackCommand.RaiseCanExecuteChanged();
        }
    }
}