using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    public class Volume : IVolume
    {
        private vtkVolume volume;

        public void Create() => volume = new vtkVolume();

        public vtkVolume GetVolume() => volume;

        public void SetMapper(vtkSmartVolumeMapper Mapper) => volume.SetMapper(Mapper);

        public void SetProperty(vtkVolumeProperty Property) => volume.SetProperty(Property);
    }
}
