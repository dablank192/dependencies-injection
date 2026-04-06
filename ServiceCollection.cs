using System;

namespace Dependencies_Injection;

public class ServiceCollection
{
    public readonly List<ServiceDescriptor> _serviceCollection = [];

    private void AddDescriptor<TService, TImplementation> (ServiceLifetime lifetime)
    {
        _serviceCollection.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime));
    }

    public void AddTransient<TService, TImplementation> ()
    {
        AddDescriptor<TService, TImplementation>(ServiceLifetime.Transient);
    }

    public void AddScoped<TService, TImplementation> ()
    {
        AddDescriptor<TService, TImplementation>(ServiceLifetime.Scoped);
    }

    public void AddSingleton<TService, TImplementation> ()
    {
        AddDescriptor<TService, TImplementation>(ServiceLifetime.Singleton);
    }
}
