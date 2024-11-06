﻿using OptomoMvvm.Interface;

namespace OptomoMvvm.Group
{
    public class FrontalGroup
    {
        public IImageReslice Slice { get; }
        public IImageMapper Mapper { get; }
        public IActor2D Actor { get; }
        public IRenderer Renderer { get; }

        public FrontalGroup(IImageReslice slice, IImageMapper mapper, IActor2D actor, IRenderer renderer)
        {
            Slice = slice;
            Mapper = mapper;
            Actor = actor;
            Renderer = renderer;
        }
    }
}
