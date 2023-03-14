using System;
using System.Collections.Generic;
using UnityEngine;

namespace IceWasteland.ResourcesCore
{
    public sealed class ResourcesHandler
    {
        private Dictionary<Type, Resource> resources;

        public ResourcesHandler(Dictionary<Type, Resource> resources)
            => this.resources = resources;

        public Resource Get<TItem>()
            => CloneItem<TItem>();

        private Resource CloneItem<TItem>()
        {
            Resource item = resources[typeof(TItem)];
            return GameObject.Instantiate(item);
        }
    }
}