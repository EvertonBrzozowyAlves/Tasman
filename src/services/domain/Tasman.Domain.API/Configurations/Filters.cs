using Microsoft.AspNetCore.Mvc.Filters;
using Tasman.Domain.API.Filters;

namespace Tasman.Domain.API.Configurations;

public static class Filters
{
    public static void ConfigureFilters(this FilterCollection filterCollection)
    {
        filterCollection.Add(new ModelStateFilter());
        filterCollection.Add(new ExceptionFilter());
    }
}