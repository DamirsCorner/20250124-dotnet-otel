using System.Diagnostics;

namespace OtelCollection;

public static class AppActivitySource
{
    public static readonly ActivitySource Instance = new("OtelCollection");
}
