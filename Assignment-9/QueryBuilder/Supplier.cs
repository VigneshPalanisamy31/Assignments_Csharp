using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    internal class Supplier
    {
        private int _supplierID;
        public int SupplierID { get => _supplierID; set => _supplierID = value; }

        private int _productID;
        public int ProductID { get => _productID; set => _productID = value; }

        private string _suppliername;
        public string SupplierName { get => _suppliername; set => _suppliername = value; }

        public Supplier(int supplierID, string supplierName,int productID) 
        { 
            SupplierID = supplierID;
            SupplierName = supplierName;
            ProductID = productID;
        }


    }
}
