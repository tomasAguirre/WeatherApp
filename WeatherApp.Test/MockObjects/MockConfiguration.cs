using Castle.Core.Configuration;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using System;

namespace WeatherApp.Test.MockObjects
{
    public class MockConfiguration : Microsoft.Extensions.Configuration.IConfiguration
    {
        private readonly Dictionary<string, string> _inMemorySettings;

        public MockConfiguration(Dictionary<string, string> settings)
        {
            _inMemorySettings = settings;
        }

        public string this[string key]
        {
            get => _inMemorySettings.TryGetValue(key, out var value) ? value : null;
            set => _inMemorySettings[key] = value;
        }
        public IEnumerable<IConfigurationSection> GetChildren() => new List<IConfigurationSection>();
        public IChangeToken GetReloadToken() => null;
        public IConfigurationSection GetSection(string key) => null;
    }
}
