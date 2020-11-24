using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Telefonszamok_DAL_Konzol;

namespace Telefonszamok_DAL
{
    public class SzemelyContext : DbContext
    {
       
        public SzemelyContext() : base("name=cnTelefonszamok")
        {

        }

        public DbSet<enSzemely> Szemely { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }


    public class WebService
        {

        private SzemelyContext _szemely = new SzemelyContext();

        private cnTelefonszamok cnTelefonszamok;
    
        public List<enSzemely> GetALLData()
        {
            cnTelefonszamok = new cnTelefonszamok();
            //cnTelefonszamok.enHelysegek.ToList();

            return cnTelefonszamok.enSzemelyek.ToList();
        }

    }
}
