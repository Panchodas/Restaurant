﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user17Entities1 : DbContext
    {
        public user17Entities1()
            : base("name=user17Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Checks> Checks { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<DishTypes> DishTypes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
    }
}
