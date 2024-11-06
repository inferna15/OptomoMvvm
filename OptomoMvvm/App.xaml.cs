using Microsoft.Extensions.DependencyInjection;
using OptomoMvvm.Group;
using OptomoMvvm.Implementation;
using OptomoMvvm.Interface;
using OptomoMvvm.Model;
using OptomoMvvm.ViewModel;
using OptomoMvvm.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace OptomoMvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<VtkModel>();
            services.AddSingleton<VtkViewModel>();
            services.AddSingleton(typeof(ImagingView));
            services.AddSingleton(typeof(ControlView));

            services.AddSingleton<IDicomReader, DicomReader>();
            services.AddTransient<IImageReslice, ImageReslice>();
            services.AddTransient<IImageMapper, ImageMapper>();
            services.AddTransient<IActor2D, Actor2D>();
            services.AddTransient<IRenderer, Renderer>();
            services.AddSingleton<IVolumeMapper, VolumeMapper>();
            services.AddSingleton<IVolumeColor, VolumeColor>();
            services.AddSingleton<IVolumeOpacity, VolumeOpacity>();
            services.AddSingleton<IVolumeProperty, VolumeProperty>();
            services.AddSingleton<IVolume, Volume>();
            services.AddSingleton<IAspectText, AspectText>();
            services.AddSingleton<ILines2D, Lines2D>();
            services.AddSingleton<ILines3D, Lines3D>();

            services.AddSingleton<AxialGroup>(provider =>
            {
                return new AxialGroup(
                    provider.GetRequiredService<IImageReslice>(),
                    provider.GetRequiredService<IImageMapper>(),
                    provider.GetRequiredService<IActor2D>(),
                    provider.GetRequiredService<IRenderer>()
                    );
            });

            services.AddSingleton<SagittalGroup>(provider =>
            {
                return new SagittalGroup(
                    provider.GetRequiredService<IImageReslice>(),
                    provider.GetRequiredService<IImageMapper>(),
                    provider.GetRequiredService<IActor2D>(),
                    provider.GetRequiredService<IRenderer>()
                    );
            });

            services.AddSingleton<FrontalGroup>(provider =>
            {
                return new FrontalGroup(
                    provider.GetRequiredService<IImageReslice>(),
                    provider.GetRequiredService<IImageMapper>(),
                    provider.GetRequiredService<IActor2D>(),
                    provider.GetRequiredService<IRenderer>()
                    );
            });

            services.AddSingleton<View3DGroup>(provider =>
            {
                return new View3DGroup(
                    provider.GetRequiredService<IVolumeMapper>(),
                    provider.GetRequiredService<IVolumeColor>(),
                    provider.GetRequiredService<IVolumeOpacity>(),
                    provider.GetRequiredService<IVolumeProperty>(),
                    provider.GetRequiredService<IVolume>(),
                    provider.GetRequiredService<IRenderer>()
                    );
            });
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var imagingView = ServiceProvider.GetRequiredService<ImagingView>();
            imagingView.Loaded += (s, args) =>
            {
                if (imagingView.DataContext is VtkViewModel viewModel)
                {
                    imagingView.ImagingPanel.Child = viewModel.RenderControl;
                    viewModel.StartCommand.Execute(this);
                }
            };
            imagingView.Show();
            var controlView = ServiceProvider.GetRequiredService<ControlView>();
            controlView.Show();
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            ServiceProvider?.Dispose();
        }
    }

}
