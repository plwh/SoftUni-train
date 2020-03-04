namespace CarDealer.Web.Models.Suppliers
{
    using Services.Models.Suppliers;
    using Services.Models;
    using System.Collections.Generic;

    public class SuppliersModel
    {
        public string Type { get; set; }

        public IEnumerable<SupplierListingModel> Suppliers { get; set; }
    }
}
