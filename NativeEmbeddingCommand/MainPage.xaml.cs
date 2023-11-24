using NativeEmbeddingCommand.ViewModels;

namespace NativeEmbeddingCommand
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            viewModel.ImageSource = "dotnet_bot.png";

            BindingContext = viewModel;
        }
    }

}
