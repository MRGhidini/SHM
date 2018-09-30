using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Models
{
    public class Brew : ObservableObject
    {
        BrewKind kind;
        string id, name, iconUri, version, author, description, longDescription, sourceUri, releasePageUri, downloadUri;
        DateTimeOffset? date;
        ObservableCollection<string> screenshotUris;

        public bool HasDetails => HasDescription || HasLongDescription || HasScreenshot;
        public BrewKind Kind { get { return kind; } set { Set(ref kind, value); } }
        public string Id { get { return id; } set { Set(ref id, value); } }
        public string Name { get { return name; } set { Set(ref name, value); } }
        public bool HasIconUri => !string.IsNullOrEmpty(IconUri);
        public string IconUri { get { return iconUri; } set { Set(ref iconUri, value); RaisePropertyChanged(nameof(HasIconUri)); } }
        public string Version { get { return version; } set { Set(ref version, value); } }
        public string Author { get { return author; } set { Set(ref author, value); } }
        public DateTimeOffset? Date { get { return date; } set { Set(ref date, value); } }
        public bool HasScreenshot => ScreenshotUris?.Any() == true;
        public ObservableCollection<string> ScreenshotUris { get { return screenshotUris; } set { Set(ref screenshotUris, value); RaisePropertyChanged(nameof(HasScreenshot)); } }
        public bool HasDescription => !string.IsNullOrEmpty(Description);
        public string Description { get { return description; } set { Set(ref description, value); RaisePropertyChanged(nameof(HasDescription)); } }
        public bool HasLongDescription => !string.IsNullOrEmpty(LongDescription);
        public string LongDescription { get { return longDescription; } set { Set(ref longDescription, value); RaisePropertyChanged(nameof(HasLongDescription)); } }
        public bool HasSourceUri => !string.IsNullOrEmpty(SourceUri);
        public string SourceUri { get { return sourceUri; } set { Set(ref sourceUri, value); } }
        public bool HasReleasePageUri => !string.IsNullOrEmpty(ReleasePageUri);
        public string ReleasePageUri { get { return releasePageUri; } set { Set(ref releasePageUri, value); RaisePropertyChanged(nameof(HasReleasePageUri)); } }
        public bool HasDownloadUri => !string.IsNullOrEmpty(DownloadUri);
        public string DownloadUri { get { return downloadUri; } set { Set(ref downloadUri, value); RaisePropertyChanged(nameof(HasDownloadUri)); } }
    }
}
