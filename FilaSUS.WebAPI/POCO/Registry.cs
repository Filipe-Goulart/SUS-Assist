using System.ComponentModel.DataAnnotations;

namespace FilaSUS.WebAPI.POCO
{
    public class Registry
    {
        [Key] public long Id { get; set; }
    }
}