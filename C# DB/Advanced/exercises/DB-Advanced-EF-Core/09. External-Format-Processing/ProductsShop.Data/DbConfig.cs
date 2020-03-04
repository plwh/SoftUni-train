using System;

namespace ProductsShop.Data
{
    internal class DbConfig
    {
        internal static string ConnectionString => @"Server=(localdb)\v12.0;Database=ProductsShop;Integrated Security=True;";
    }
}
