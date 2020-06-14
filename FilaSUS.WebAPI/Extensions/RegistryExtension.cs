using System.Linq;
using FilaSUS.WebAPI.POCO;

namespace FilaSUS.WebAPI.Extensions
{
    public static class RegistryExtension
    {
        public static void SetReferencesNull(this Registry registry)
        {
            var props = registry.GetType().GetProperties().Where(p => p.GetGetMethod()!.IsVirtual).ToList();
            foreach (var prop in props)
            {
                prop.SetValue(registry, null);
            }
        }
    }
}