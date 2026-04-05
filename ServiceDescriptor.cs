using System;

namespace Dependencies_Injection;

public class ServiceDescriptor
{
    public Type ServiceType {get;} //-> Interface class
    public Type ImplementationType {get;} // -> Class that inherit from that Interface class
    public ServiceLifetime Lifetime {get;} // -> Type of Dependencies they need

    public ServiceDescriptor (Type serviceType, Type implementationType, ServiceLifetime lifeTime)
    {
        ServiceType = serviceType;
        ImplementationType = implementationType;
        Lifetime = lifeTime;
    }
}
