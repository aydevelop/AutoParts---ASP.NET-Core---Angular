using Database;
using System;
using System.Linq;
using System.Reflection;

namespace AvtoZapchasti.Extension
{
    public static class DbContextExt
    {
        public static IQueryable Set(this AppDbContext context, Type T)
        {
            MethodInfo method = typeof(AppDbContext).GetMethod(nameof(AppDbContext.Set), BindingFlags.Public | BindingFlags.Instance);
            method = method.MakeGenericMethod(T);
            return method.Invoke(context, null) as IQueryable;
        }
    }
}
