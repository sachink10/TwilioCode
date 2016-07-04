using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using TwilioApplication.Models;
using TwilioApplication.Models.EDMXModel;

namespace TwilioApplication.BusinessLogic
{
    public class ClsBusiness
    {
        public bool validateUser(LoginModel model)
        {
           
            twilioEntities entities = new twilioEntities();


            var login = (from log in entities.Sp_CheckUser(model.username, model.password.Trim()) select log).ToList();

            return Convert.ToBoolean(Convert.ToInt16(login[0]));

        }

        public List<sp_getparticipatingindividuals_Result> GetParticipateIndividual()
        {
            twilioEntities entities = new twilioEntities();
            List<sp_getparticipatingindividuals_Result> retval = (from ret in entities.sp_getparticipatingindividuals() select ret).ToList();
            return retval;

        }

        public bool UpdateSendMessage(List<string> recordid)
        {
            twilioEntities entities = new twilioEntities();
            try
            {

                foreach (var item in recordid)
                {
                    string[] val = item.Split(',');
                    entities.sp_insertblast(int.Parse(val[0]), val[2], val[1]);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<sp_getorderstatus_Result> getOrderStatus(string type)
        {
            List<sp_getorderstatus_Result> obj = new List<sp_getorderstatus_Result>();
            twilioEntities entities = new twilioEntities();
            obj = (from status in entities.sp_getorderstatus(type) select status).ToList();
            return obj;
        }

        public List<sp_getorderstatustotals_Result> getOrderStatusTotal(string type)
        {
            List<sp_getorderstatustotals_Result> obj = new List<sp_getorderstatustotals_Result>();
            twilioEntities entities = new twilioEntities();
            obj = (from status in entities.sp_getorderstatustotals(type) select status).ToList();
            return obj;
        }

        public List<sp_getorderstatusrecorddetails_Result> getOrderstatusdetail(string phonenumber,string type)
        {
            twilioEntities entities = new twilioEntities();
            List<sp_getorderstatusrecorddetails_Result> obj = new List<sp_getorderstatusrecorddetails_Result>();

            obj = (from order in entities.sp_getorderstatusrecorddetails(phonenumber,type) select order).ToList();

            return obj;
        }

        public List<sp_getorderstatusrecordlogdetails_Result> getOrderlogdetail(string phonenumber,string type)
        {
            twilioEntities entities = new twilioEntities();
            List<sp_getorderstatusrecordlogdetails_Result> obj = new List<sp_getorderstatusrecordlogdetails_Result>();

            obj = (from order in entities.sp_getorderstatusrecordlogdetails(phonenumber,type) select order).ToList();

            return obj;
        }

        public bool insertOrderstatus(string phonenumber, string type,string username)
        {
            try
            {
                twilioEntities entities = new twilioEntities();
                entities.sp_getorderstatusinsertrecord(phonenumber, type, username);          
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<sp_getparticipatinglocations_Result> getPartLocation()
        {
            twilioEntities entities = new twilioEntities();
            var retval = (from part in entities.sp_getparticipatinglocations() select part).ToList();
            return retval;
        }

        public bool insertParticipatingLocation(int? locaitonid, string locationadd, int? order, int? choice, string active, string type)
        {
            try
            {
                twilioEntities entities = new twilioEntities();

                entities.sp_insertupdatepartipatinglocations((locaitonid == 0 ? null:locaitonid), locationadd, type, order, choice, active);


                return true;
            }
            catch 
            {

                return false;
            }

            
        }

        public List<sp_getfoodmenudetails_Result> getFoodDetail()
        {
            twilioEntities entities = new twilioEntities();
            var retval = (from part in entities.sp_getfoodmenudetails() select part).ToList();
            return retval;
        }

        public bool insertupdateFoodMenu(int? foodmenuid, string menuofchoice,  int? choice, string active, string type)
        {
            try
            {
                twilioEntities entities = new twilioEntities();

                entities.sp_insertupdatefoodmenudetails(foodmenuid, type, menuofchoice, active, choice);

                return true;
            }
            catch
            {

                return false;
            }


        }

        public List<sp_getuserlist_Result> getUserList()
        {
            twilioEntities entities = new twilioEntities();
            var retval = (from usr in entities.sp_getuserlist() select usr).ToList();
            return retval;
        }
        public sp_getuserdetails_Result getUserDetail(int? userid)
        {
            twilioEntities entities = new twilioEntities();
            var retval = (from usr in entities.sp_getuserdetails(userid) select usr).FirstOrDefault();

            return retval;
        }

        public bool insertupdateuserlist(int? userid, string username,string password, string email, string fname, string lname, string status)
        {
            try
            {
                twilioEntities entities = new twilioEntities();

                entities.sp_insertupdateuserlist(userid, username, password, fname, lname, email, status);

                return true;
            }
            catch
            {

                return false;
            }


        }

        public bool InsertNewRegistrationNumber(string phonenumber)
        {
            
            try
            {
                twilioEntities entities = new twilioEntities();

                entities.sp_insnewregnphone(phonenumber);

                return true;
            }
            catch
            {

                return false;
            }

        }
    }
}