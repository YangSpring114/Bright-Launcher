using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Bright_Launcher.Services.Launch;
using Bright_Launcher.Services.Setting;
using Bright_Launcher.Services.UI;
using Bright_Launcher.ViewModels.DialogContents;
using Bright_Launcher.ViewModels.Pages;
using Bright_Launcher.ViewModels.Pages.Setting;
using Bright_Launcher.ViewModels.Windows;
using Bright_Launcher.Views.DialogContent;
using Bright_Launcher.Views.Pages;
using Bright_Launcher.Views.Pages.Setting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Bright_Launcher.Services;

namespace Bright_Launcher {
    public partial class App : Application {
        private static IHost _host;

        public static IServiceProvider ServiceProvider => _host.Services;

        public override async void Initialize() {
            base.Initialize();
            _host = GetHost().Build();
            await _host.RunAsync();
        }

        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                ServiceProvider.GetService<SettingService>();
                desktop.MainWindow = new MainWindow {
                    DataContext = ServiceProvider.GetService<MainWindowViewModel>()
                };

                desktop.Exit += OnExit;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private async void OnExit(object sender, ControlledApplicationLifetimeExitEventArgs e) {
            ServiceProvider.GetService<SettingService>()
                .Save();
        }

        public IHostBuilder GetHost() {
            return Host.CreateDefaultBuilder().ConfigureServices((_, services) => {
                ConfigureServices(services);
            }).ConfigureServices((_, services) => {
                ConfigureViews(services);
            });
        }

        private static void ConfigureViews(IServiceCollection services) {
            //Views
            services.AddSingleton<MainWindow>();//����MainWindowֻ����ֻ����һ��ʵ������˲��õ�������˲̬
            services.AddTransient<LaunchPage>();
            services.AddTransient<ExpandPage>();
            services.AddSingleton<SettingPage>();
            services.AddTransient<DownloadPage>();
            services.AddTransient<LaunchSettingPage>();
            services.AddTransient<AccountSettingPage>();
            services.AddTransient<AuthenticateContent>();

            //ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<LaunchPageViewModel>();
            services.AddTransient<SettingPageViewModel>();
            services.AddTransient<LaunchSettingPageViewModel>();
            services.AddTransient<AccountSettingPageViewModel>();
            services.AddTransient<AuthenticateContentViewModel>();
        }
        
        private static void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<JavaService>();
            services.AddSingleton<GameService>();
            services.AddSingleton<DialogService>();
            services.AddSingleton<LaunchService>();
            services.AddSingleton<SettingService>();
            services.AddSingleton<InstallService>();
            services.AddSingleton<NavigationService>();
        }
    }
}