using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNight.EntityLayer.Concrete
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }

        // Bir özellik birden fazla kitaba sahip olabilir (Many-to-Many ilişki)
        public List<Product> Products { get; set; }
    }
}
