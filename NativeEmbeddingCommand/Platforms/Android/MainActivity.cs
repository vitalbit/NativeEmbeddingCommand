using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using NativeEmbeddingCommand.ViewModels;

namespace NativeEmbeddingCommand
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : AppCompatActivity
    {
        MauiContext _mauiContext;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Perform your normal Android registration

            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

            MauiApp mauiApp = builder.Build();
            _mauiContext = new MauiContext(mauiApp.Services, this);

            MainPage? mainPage = _mauiContext.Services.GetService<MainPage>();
            if (mainPage != null)
            {
                Android.Views.View view = mainPage.ToPlatform(_mauiContext);
                SetContentView(view);
            }
        }
    }
}
