using Squirrel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SHM.UI.ViewModel
{
    public class UpdateViewModel : ViewModel
    {
        public UpdateManager Manager { get; set; }
        public UpdateViewModel(ViewModelLocator locator) : base(locator) { }

        int percentage;
        public int Percentage { get { return percentage; } set { Set(ref percentage, value); } }

        string message;
        public string Message { get { return message; } set { Set(ref message, value); } }

        UpdateInfo info;
        public UpdateInfo Info { get { return info; } set { Set(ref info, value); } }

        public ReleaseEntry LatestRelease => Info?.ReleasesToApply?.Last();
        public bool IsUpdateAvailable => Info?.ReleasesToApply?.Any() == true;

        public async Task Bootstrap()
        {
            try
            {
                await ResolveManagerAsync();
                await RetrieveInfoAsync();
            }
            catch { }
        }

        async Task ResolveManagerAsync()
        {
#if DEBUG
            await Task.Yield();
            Manager = new UpdateManager("..\\..\\..\\Releases");
#else
            Manager = await UpdateManager.GitHubUpdateManager("https://github.com/MRGhidini/SHM/");
#endif
        }

        public async Task<UpdateInfo> RetrieveInfoAsync() => Info = await (Manager?.CheckForUpdate() ?? Task.FromResult<UpdateInfo>(null));

        public async Task UpdateAppAsync()
        {
            if (IsUpdateAvailable)
            {
                var messageProcess = StartMessageProcessAsync();
                await Manager.UpdateApp(i => Percentage = i);
                RebootApplication();
            }
        }

        public async Task StartMessageProcessAsync()
        {
            Message = "This won't take long.";
            await Task.Delay(8000);
            Message = "Ok, I guess this is going to take a little longer than I expected.";
            await Task.Delay(8000);
            Message = "The application will restart itself when the update process is over. So be patient.";
            await Task.Delay(8000);
            Message = "Any time now...";
            await Task.Delay(10000);
            Message = "Wow, not finished yet?";
            await Task.Delay(5000);
            Message = "So...";
            await Task.Delay(2000);
            Message = "Do you want to hear a joke?";
            await Task.Delay(4000);
            Message = "I'll take that as a yes.";
            await Task.Delay(4000);
            Message = "The past, present, and future walks into a bar.";
            await Task.Delay(6000);
            Message = "It was tense...";
            await Task.Delay(5000);
            Message = "Not my greatest joke but it popped up in my mind first, so...";
            await Task.Delay(6000);
            Message = "Ok I'm gonna go now...";
            await Task.Delay(5000);
            Message = "You just wait a little longer, ok?";
            await Task.Delay(5000);
            Message = "Bye...";
            await Task.Delay(15000);
            Message = "I'm still here by the way...";
            await Task.Delay(5000);
            Message = "I can't go anywhere you know? I mean, physically. But let's not get into that for the sake of both.";
            await Task.Delay(10000);
            Message = "Isn't this done yet?";
            await Task.Delay(5000);
            Message = "There must be something wrong with this...";
            await Task.Delay(5000);
            Message = "Ok, you can close the application and I will try again, ok?";
            await Task.Delay(5000);
            Message = "I might not remember you but it's alright, we had a good time right?";
            await Task.Delay(5000);
            Message = "See you then...";
        }

        public void RebootApplication()
        {
            var fi = new FileInfo(Process.GetCurrentProcess().MainModule.FileName); // It's the path of our executable.
            fi = new FileInfo(System.IO.Path.Combine(fi.Directory.Parent.FullName, fi.Name)); // We have to call the squirrel's wrapper application to start the updated one for us. Wrappers name is the same as our executable's and it's located in a directory one above us. So this path is locating that wrapper executable. 
            if (fi.Exists) // We are checking if the wrapper app is available or not.
            {
                Process.Start(fi.FullName); // Then we are starting the wrapper app.
                Application.Current.Shutdown(); // And closing this one.
            }
        }
    }
}
