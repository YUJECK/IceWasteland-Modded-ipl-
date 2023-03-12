using System;
using System.Collections.Generic;

namespace IceWasteland.ResourcesCore
{
    public sealed class ResourcesHandler
    {
        private Dictionary<Type, Resource> resources;

        public ResourcesHandler(Dictionary<Type, Resource> resources)
            => this.resources = resources;

        public Resource Get<T>()
            => resources[typeof(T)];
    }
}