using IceWasteland.ResourcesCore;
using System;
using System.Collections.Generic;
using Zenject;

namespace IceWasteland.Installers
{
    public sealed class ResourcesInstaller : MonoInstaller
    {
        public Resource[] resources;

        public override void InstallBindings()
        {
            ResourcesHandler resourcesHandler = new(CreateResourcesDictionary());
            BindResourceHandler(resourcesHandler);
        }

        private void BindResourceHandler(ResourcesHandler resourcesHandler)
        {
            Container
                .Bind<ResourcesHandler>()
                .FromInstance(resourcesHandler)
                .AsSingle();
        }

        private Dictionary<Type, Resource> CreateResourcesDictionary()
        {
            Dictionary<Type, Resource> resourcesDictionary = new();

            foreach (var resource in resources)
                resourcesDictionary.Add(resource.GetType(), resource);

            return resourcesDictionary;
        }
    }
}