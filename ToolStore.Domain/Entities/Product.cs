using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStore.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public string PicturePath
        {
            get
            {
                return String.Format("Content/Photos/product_{0}.jpg", Id);
            }
        }
    }
}
