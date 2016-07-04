using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwilioApplication.Models;
using TwilioApplication.BusinessLogic;
using System.Web.Security;

namespace TwilioApplication.Controllers
{
    public class HNIController : Controller
    {
        #region Private Variable
        ClsBusiness business = null;
        HNIModel model = null;
        #endregion

        //
        // GET: /HNI/

        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                business = new ClsBusiness();

                if (business.validateUser(model))
                {
                    FormsAuthentication.SetAuthCookie(model.username, true);
                    Session["LoggedInUserEmail"] = model.username;
                    return RedirectToAction("OrderStatus");
                }
            }

            return View();
        }

        public ActionResult ParticipatingLocation()
        {
            business = new ClsBusiness();
            model = new HNIModel();
            model.getPartLocation = business.getPartLocation();

            return View(model);
        }

        [HttpPost]
        public JsonResult insertParticipatingLocation(string locaitonid, string locationadd, string order, string choice, string active, string type)
        {
            business = new ClsBusiness();
            int id, orderid, choiceid = 0;
            Int32.TryParse(locaitonid, out id);
            Int32.TryParse(choice, out choiceid);
            Int32.TryParse(order, out orderid);


            bool retval = business.insertParticipatingLocation(id, locationadd, orderid, choiceid, active, type);
            return Json(retval, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OrderStatus(string type)
        {
            business = new ClsBusiness();
            model = new HNIModel();
            if (string.IsNullOrEmpty(type))
                type = "B";
            Session["type"] = type;
            model.OrderstatusType = type;
            model.getOrderStatusB = business.getOrderStatus(type);
            model.getOrderStatusTotal = business.getOrderStatusTotal(type);
            return View(model);
        }

        [HttpPost]
        public JsonResult getOrderselectdetail(string phonenumber, string type)
        {
            business = new ClsBusiness();
            model = new HNIModel();
            model.getOrderstatusdetail = business.getOrderstatusdetail(phonenumber, type);
            return Json(model.getOrderstatusdetail, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult getOrderlogdetail(string phonenumber, string type)
        {
            if (string.IsNullOrEmpty(type))
                type = "B";
            business = new ClsBusiness();
            model = new HNIModel();
            model.getOrderLogdetail = business.getOrderlogdetail(phonenumber, type);
            return Json(model.getOrderLogdetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult insertORderStatus(string phonenumber, string type)
        {
            if (string.IsNullOrEmpty(type))
                type = "B";
            business = new ClsBusiness();
            model = new HNIModel();
            bool retval = business.insertOrderstatus(phonenumber, type, Session["LoggedInUserEmail"].ToString());
            return Json(retval, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SendMessage()
        {
            business = new ClsBusiness();
            model = new HNIModel();
            model.getParticipateIndividual = business.GetParticipateIndividual();

            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateSendMessage(List<string> recordid)
        {
            business = new ClsBusiness();
            bool retval = business.UpdateSendMessage(recordid);
            return Json(retval, JsonRequestBehavior.AllowGet);
        }


        public ActionResult FoodMenu()
        {
            business = new ClsBusiness();
            model = new HNIModel();
            model.getFoodDetail = business.getFoodDetail();

            return View(model);
        }

        [HttpPost]
        public JsonResult insertupdateFoodMenu(string foodmenuid, string choiceofmenu, string choice, string active, string type)
        {
            business = new ClsBusiness();
            int id, choiceid = 0;
            Int32.TryParse(foodmenuid, out id);
            Int32.TryParse(choice, out choiceid);
            bool retval = business.insertupdateFoodMenu(id, choiceofmenu, choiceid, active, type);
            return Json(retval, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Participants()
        {

            return View();
        }


        public ActionResult UserManagement()
        {
            model = new HNIModel();
            business = new ClsBusiness();

            model.getUserList = business.getUserList();


            return View(model);
        }

        [HttpPost]
        public JsonResult getUserDetail(string userid)
        {
            business = new ClsBusiness();
            model = new HNIModel();
            int id = 0;
            Int32.TryParse(userid, out id);
            model.getUserDetail = business.getUserDetail(id);
            return Json(model.getUserDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult insertupdateuserlist(string userid, string username, string password, string email, string fname, string lname, string status)
        {
            business = new ClsBusiness();
            int id = 0;
            Int32.TryParse(userid, out id);
            bool retval = business.insertupdateuserlist(id, username, password, email, fname, lname,status);
            return Json(retval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsetNewResistrationModel(string phonenumber)
        {
            business = new ClsBusiness();
            bool retval = business.InsertNewRegistrationNumber(phonenumber);
            return Json(retval, JsonRequestBehavior.AllowGet);
        }

    }
}
