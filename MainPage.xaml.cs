using CommunityToolkit.Maui.Views;
using synchronizer.Models;

namespace synchronizer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new VideoContext();
        }

        public async Task<FileResult?> PickAndShow()
        {
            PickOptions options = new()
            {
                PickerTitle = "Please select a comic file",
                FileTypes = FilePickerFileType.Videos,
            };

            try
            {
                return await FilePicker.Default.PickAsync(options);
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }

        private async void Open_Clicked(object sender, EventArgs e)
        {
            FileResult? videoFile = await PickAndShow();

            if (videoFile is null)
                return;

            ((VideoContext)BindingContext).FileSource = MediaSource.FromFile(videoFile.FullPath);
        }
    }

}
