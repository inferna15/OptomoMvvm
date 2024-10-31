using Microsoft.Extensions.DependencyInjection;
using OptomoMvvm.Group;
using OptomoMvvm.Implementation;
using OptomoMvvm.Interface;
using OptomoMvvm.Model;
using OptomoMvvm.ViewModel;

namespace OptomoMvvm.DependencyInjection
{
    internal static class ClassConfigurator
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

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

            services.AddSingleton<DicomModel>();
            services.AddSingleton<PropertyModel>();
            services.AddSingleton<VtkModel>();
            services.AddSingleton<VtkViewModel>();

            return services;
        }
    }
}
