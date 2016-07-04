using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwilioApplication.Models.EDMXModel;

namespace TwilioApplication.Models
{
    public class HNIModel
    {
        public List<sp_getparticipatingindividuals_Result> getParticipateIndividual { get; set; }
        public List<sp_getorderstatus_Result> getOrderStatusB { get; set; }
        public List<sp_getorderstatus_Result> getOrderStatusL { get; set; }

        public List<sp_getorderstatustotals_Result> getOrderStatusTotal { get; set; }

        public string OrderstatusType { get; set; }
        
        public List<sp_getorderstatusrecorddetails_Result> getOrderstatusdetail { get; set; }

        public List<sp_getorderstatusrecordlogdetails_Result> getOrderLogdetail { get; set; }

        public List<sp_getparticipatinglocations_Result> getPartLocation {get;set;}

        public List<sp_getfoodmenudetails_Result> getFoodDetail { get; set; }

        public List<sp_getuserlist_Result> getUserList { get; set; }

        public sp_getuserdetails_Result getUserDetail { get; set; }
    }
}