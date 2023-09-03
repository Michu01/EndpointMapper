namespace EndpointMapper;

public static class IEndpointRouteBuilderExtensions
{
    public static void MapEndpointsFromAssemblyContaining<T>(this IEndpointRouteBuilder routeBuilder)
    {
        var types = typeof(T)
            .Assembly
            .DefinedTypes
            .Where(e => e.ImplementedInterfaces.Contains(typeof(IEndpointMapper)));

        foreach (var type in types)
        {
            var instance = (IEndpointMapper)Activator.CreateInstance(type)!;

            instance.MapEndpoints(routeBuilder);
        }
    }
}
