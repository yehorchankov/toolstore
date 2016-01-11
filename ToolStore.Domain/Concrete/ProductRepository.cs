using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStore.Domain.Abstract;
using ToolStore.Domain.Entities;

namespace ToolStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IEnumerable<Product> _products = new List<Product> //Sorry :(
        {
            new Product
            {
                Id = 1,
                Name = "Bosch HDB180-02 18V Compact 3/8 Cordless Hammer Drill/Driver",
                Description = "Bosch super mega concrete breaking double rotor drill. 360 In. Lbs of Max torque - has enough torque to drive most common fasteners and drill bits" + 
                            "8 In. Head length and 3.2 Lbs. - most compact and lightweight design available provides least amount of user fatigue" + 
                            "Drives 160 3 In. screws per charge - strong run time keeps user on the job 2-Speed drill (0-500/1, 450 RPM) - high speed for small diameter",
                Price = 1500M
            },
            new Product
            {
                Id = 2,
                Name = "FatMax Xtreme Hi Velocity Rip Claw Framing Hammer",
                Description = "1,5 kilogramms of clear steel and comfortable grip. A brand-new, unused, unopened, undamaged item in its original packaging (where packaging is applicable). " +
                              "Packaging should be the same as what is found in a retail store, unless the item is handmade or was packaged by the manufacturer in non-retail packaging, such " +
                              "as an unprinted box or plastic bag. See the seller's listing for full details.",
                Price = 100M
            },
            new Product
            {
                Id = 3,
                Name = "Hand back saw",
                Description = "Almost half as powerful as its electric analogue. A brand-new, unused, unopened, undamaged item (including handmade items). See the seller's listing for full details.",
                Price = 210M
            }
        };

        public IEnumerable<Product> Products { get { return _products; } }
    }
}
