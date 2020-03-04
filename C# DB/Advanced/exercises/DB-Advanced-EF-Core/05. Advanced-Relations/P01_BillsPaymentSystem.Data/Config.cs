using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data
{
    public class Config
    {
        internal static string ConnectionString => @"Server=(localdb)\v12.0;Database=BillsPaymentSystem;Integrated Security=True;";
    }
}
