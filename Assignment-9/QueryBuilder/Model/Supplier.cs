namespace LINQ.Model
{
    internal class Supplier
    {
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public string SupplierName { get; set; }
        public Supplier(int supplierID, string supplierName, int productID)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            ProductID = productID;
        }
    }
}
