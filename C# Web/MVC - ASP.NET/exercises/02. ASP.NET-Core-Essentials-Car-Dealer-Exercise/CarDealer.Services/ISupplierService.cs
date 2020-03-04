namespace CarDealer.Services
{
    using System.Collections.Generic;
    using Models.Suppliers;
    using Models;

    public interface ISupplierService
    {
        IEnumerable<SupplierListingModel> AllListings(bool isImporter);

        IEnumerable<SupplierModel> All();
    }
}
