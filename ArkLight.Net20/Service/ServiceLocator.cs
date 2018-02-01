using System;
using System.Collections.Generic;
using System.Text;

namespace ArkLight.Service
{
    /// <summary>
    ///     Simple ServiceLocator implementation.
    /// </summary>
    public sealed class ServiceLocator
    {
        static ServiceLocator instance;
        Dictionary<Type, object> registeredServices = new Dictionary<Type, object>();

        /// <summary>
        ///     Singleton instance for default service locator
        /// </summary>
        public static ServiceLocator Instance =>
            instance ?? (instance = new ServiceLocator());

        /// <summary>
        ///     Add a new contract + service implementation
        /// </summary>
        /// <typeparam name="TContract">Contract type</typeparam>
        /// <typeparam name="TService">Service type</typeparam>
        public void Register<TContract, TService>() where TService : new()
        {
            registeredServices[typeof(TContract)] =
                Activator.CreateInstance(typeof(TService));
        }

        /// <summary>
        ///     This resolves a service type and returns the implementation. Note that this
        ///     assumes the key used to register the object is of the appropriate type or
        ///     this method will throw an InvalidCastException!
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Implementation</returns>
        public T Get<T>() where T : class
        {
            if (registeredServices.TryGetValue(typeof(T), out object service))
            {
                return (T)service;
            }
            return null;
        }
    }
}
