using System;
using LesegaisParser.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LesegaisParser.Common.DataBase
{
    public class LesegaisContext : DbContext
    {
        public DbSet<Deal> Deals { get; set; }

        public string DataBasePath { get; private set; }

        public LesegaisContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DataBasePath = $"{path}{System.IO.Path.DirectorySeparatorChar}lesegais.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DataBasePath}");
    }
}