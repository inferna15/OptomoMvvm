using OptomoMvvm.Interface;

namespace OptomoMvvm.Group
{
    internal class View3DGroup
    {
        public IVolumeMapper Mapper { get; }
        public IVolumeColor Color { get; }
        public IVolumeOpacity Opacity { get; }
        public IVolumeProperty Property { get; }
        public IVolume Volume { get; }
        public IRenderer Renderer { get; }

        public View3DGroup(IVolumeMapper mapper, IVolumeColor color, IVolumeOpacity opacity, IVolumeProperty property, IVolume volume, IRenderer renderer)
        {
            Mapper = mapper;
            Color = color;
            Opacity = opacity;
            Property = property;
            Volume = volume;
            Renderer = renderer;
        }
    }
}
