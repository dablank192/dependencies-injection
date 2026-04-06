using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
namespace Dependencies_Injection;

public class ServiceProvider
{
    private readonly Dictionary<Type, object> _singleton = [];
    private readonly IEnumerable<ServiceDescriptor> _services;

    public ServiceProvider (ServiceCollection collection)
    {
        _services = collection._serviceCollection;
    }

    public object GetService (Type serviceType)
    {
        var serv = _services.FirstOrDefault(t => t.ServiceType == serviceType);

        if (serv == null)
        {
            throw new Exception("Service not registered");
        }

        else if ((serv.Lifetime == ServiceLifetime.Singleton) && _singleton.ContainsValue(serv.ImplementationType))
        {
            return _singleton[serviceType];
        }

        var implementationType = serv.ImplementationType;

        var constructor = implementationType.GetConstructors().First();

        var parameters = constructor.GetParameters();

        var parametersImplementation = new object[parameters.Length];


        for (int i= 0; i < parameters.Length; i ++)
        {
            parametersImplementation[i] = GetService(parameters[i].ParameterType);
        }

        var instance = Activator.CreateInstance(implementationType, parametersImplementation);

        if (serv.Lifetime == ServiceLifetime.Singleton)
        {
            _singleton.Add(serviceType, instance);

            return instance;
        }

        return instance;

    }
}
