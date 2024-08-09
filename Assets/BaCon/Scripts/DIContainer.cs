using System;
using System.Collections.Generic;

namespace BaCon
{
    public class DIContainer : IDisposable
    {
        private readonly DIContainer _parentContainer;
        private readonly Dictionary<(string, Type), DIEntry> _entriesMap = new();
        private readonly HashSet<(string, Type)> _resolutionsCache = new();

        public DIContainer(DIContainer parentContainer = null)
        {
            _parentContainer = parentContainer;
        }

        public DIEntry RegisterFactory<T>(Func<DIContainer, T> factory)
        {
            return RegisterFactory(null, factory);
        }

        public DIEntry RegisterFactory<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            
            if (_entriesMap.ContainsKey(key))
            {
                throw new Exception(
                    $"DI: Factory with tag {key.Item1} and type {key.Item2.FullName} has already registered");
            }

            var diEntry = new DIEntry<T>(this, factory);

            _entriesMap[key] = diEntry;

            return diEntry;
        }

        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(null, instance);
        }

        public void RegisterInstance<T>(string tag, T instance)
        {
            var key = (tag, typeof(T));
            
            if (_entriesMap.ContainsKey(key))
            {
                throw new Exception(
                    $"DI: Instance with tag {key.Item1} and type {key.Item2.FullName} has already registered");
            }

            var diEntry = new DIEntry<T>(instance);

            _entriesMap[key] = diEntry;
        }

        public T Resolve<T>(string tag = null)
        {
            var key = (tag, typeof(T));

            if (_resolutionsCache.Contains(key))
            {
                throw new Exception($"DI: Cyclic dependency for tag {key.tag} and type {key.Item2.FullName}");
            }

            _resolutionsCache.Add(key);

            try
            {
                if (_entriesMap.TryGetValue(key, out var diEntry))
                {
                    return diEntry.Resolve<T>();
                }

                if (_parentContainer != null)
                {
                    return _parentContainer.Resolve<T>(tag);
                }
            }
            finally
            {
                _resolutionsCache.Remove(key);
            } 
            
            throw new Exception($"Couldn't find dependency for tag {tag} and type {key.Item2.FullName}");
        }

        public void Dispose()
        {
            var entries = _entriesMap.Values;
            
            foreach (var entry in entries)
            {
                entry.Dispose();
            }
        }
    }
}