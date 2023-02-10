using System;
using System.Collections.Generic;

namespace IceWasteland
{
    public static class GlobalServiceLocator
    {
        private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public static void RegisterService<T>(T newService) where T : class => services.Add(typeof(T), newService);
        public static void UnregisterService<T>() where T : class
        {
            if (services.ContainsKey(typeof(T)))
                services.Remove(typeof(T));

            throw new NullReferenceException("Service is not registered");
        }
        public static T GetService<T>() where T : class
        {
            if (services.TryGetValue(typeof(T), out var service))
                return service as T;

            throw new NullReferenceException("Service is not registered");
        }
    }
}