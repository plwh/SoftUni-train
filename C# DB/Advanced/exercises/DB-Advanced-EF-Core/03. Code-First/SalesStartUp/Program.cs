using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using P03_SalesDatabase.Data;
using System;

namespace SalesStartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SalesContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
