using System.ComponentModel.DataAnnotations;

namespace api.models
{
    // defines columns
    /*  Id
        name
        price
        ?special
    */
    public class Pizza
    {
        [Key]
        public int Id {get; set;}
        
        public string? Name {get; set;}
        public float Price {get; set;}
        public bool isSpecial {get; set;}
    }
}