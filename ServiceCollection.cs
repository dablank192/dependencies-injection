using System;

namespace Dependencies_Injection;

public class ServiceCollection
{
    public readonly List<ServiceDescriptor> _serviceCollection = [];

    public void AddTransient<IService, IImplementation> ()
    {
        var serviceType = typeof(IService);

        var implementationType = typeof(IImplementation);

        _serviceCollection.Add(new ServiceDescriptor (serviceType, implementationType, ServiceLifetime.Transient));
    }
}
