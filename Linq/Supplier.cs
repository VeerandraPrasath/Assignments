using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Supplier
    {
        public string SupplierName { get; set; }    
        public int SupplierId { get; set; }
        public int ProductId { get; set; }

        public Supplier(string name,int supplierId,int productId)
        {
            SupplierName = name;    
            SupplierId = supplierId;    
            ProductId = productId;  
        }
    }
}
