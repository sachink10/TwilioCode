﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwilioResponse.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TwilioEntities : DbContext
    {
        public TwilioEntities()
            : base("name=TwilioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<foodmenu> foodmenus { get; set; }
        public DbSet<participatingindividual> participatingindividuals { get; set; }
        public DbSet<participatinglocation> participatinglocations { get; set; }
        public DbSet<receivedtransaction> receivedtransactions { get; set; }
        public DbSet<senttransaction> senttransactions { get; set; }
        public DbSet<tbl_user> tbl_user { get; set; }
        public DbSet<transactionstatu> transactionstatus { get; set; }
    
        public virtual ObjectResult<string> bkp_sp_receivedmessages(string phone, string choice, string returnmessage)
        {
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var choiceParameter = choice != null ?
                new ObjectParameter("choice", choice) :
                new ObjectParameter("choice", typeof(string));
    
            var returnmessageParameter = returnmessage != null ?
                new ObjectParameter("returnmessage", returnmessage) :
                new ObjectParameter("returnmessage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("bkp_sp_receivedmessages", phoneParameter, choiceParameter, returnmessageParameter);
        }
    
        public virtual ObjectResult<sp_breakfastmessagessend_Result> sp_breakfastmessagessend(ObjectParameter phone, string sentmessage)
        {
            var sentmessageParameter = sentmessage != null ?
                new ObjectParameter("sentmessage", sentmessage) :
                new ObjectParameter("sentmessage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_breakfastmessagessend_Result>("sp_breakfastmessagessend", phone, sentmessageParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Sp_CheckUser(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Sp_CheckUser", userNameParameter, passwordParameter);
        }
    
        public virtual int sp_logsenttransactions(string phone, string msgsentfor, string msgsent)
        {
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var msgsentforParameter = msgsentfor != null ?
                new ObjectParameter("msgsentfor", msgsentfor) :
                new ObjectParameter("msgsentfor", typeof(string));
    
            var msgsentParameter = msgsent != null ?
                new ObjectParameter("msgsent", msgsent) :
                new ObjectParameter("msgsent", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_logsenttransactions", phoneParameter, msgsentforParameter, msgsentParameter);
        }
    
        public virtual ObjectResult<sp_lunchmessagessend_Result> sp_lunchmessagessend(ObjectParameter phone, string sentmessage)
        {
            var sentmessageParameter = sentmessage != null ?
                new ObjectParameter("sentmessage", sentmessage) :
                new ObjectParameter("sentmessage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_lunchmessagessend_Result>("sp_lunchmessagessend", phone, sentmessageParameter);
        }
    
        public virtual ObjectResult<sp_messagessend_Result> sp_messagessend(string type, ObjectParameter phone, string sentmessage)
        {
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var sentmessageParameter = sentmessage != null ?
                new ObjectParameter("sentmessage", sentmessage) :
                new ObjectParameter("sentmessage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_messagessend_Result>("sp_messagessend", typeParameter, phone, sentmessageParameter);
        }
    
        public virtual ObjectResult<string> sp_receivedmessages(string phone, string choice, string returnmessage)
        {
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var choiceParameter = choice != null ?
                new ObjectParameter("choice", choice) :
                new ObjectParameter("choice", typeof(string));
    
            var returnmessageParameter = returnmessage != null ?
                new ObjectParameter("returnmessage", returnmessage) :
                new ObjectParameter("returnmessage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_receivedmessages", phoneParameter, choiceParameter, returnmessageParameter);
        }
    }
}
