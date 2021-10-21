﻿using PropertyMaster.DAL;
using PropertyMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyMaster.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly DbAccess context;
        public AdminController()
        {
            context = new DbAccess();
        }
        // GET: Admin
        public ActionResult Index()
        {
            //ViewBag.Members = context.Accounts.Where(m => m.UserType == UserType.Member && m.isActive == true).Count();
            //ViewBag.Trainers = context.Accounts.Where(m => m.UserType == UserType.Trainer && m.isActive == true).Count();
            ViewBag.Projects = context.Projects.Count();
            return View();
        }


        #region Users
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
       
        public JsonResult NewUser(User obj)
        {
            obj.datetime = DateTime.Now;
            //account.CreatedBy = Global.UserID;
            //obj.deleted = true;
            context.Users.Add(obj);
            context.SaveChanges();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditUser()
        {
            return View();
        }
        public JsonResult UsersList(int type)
        {
            var users = context.Users.Where(p => p.usertype == (UserType)type).ToList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyIDUser(int ID)
        {
            var obj = context.Users.Where(m => m.id == ID).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateUser(User obj)
        {
            var org = context.Users.Where(m => m.id == obj.id).FirstOrDefault();
            if (org != null)
            {
                obj.datetime = org.datetime;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();

            //return RedirectToAction("Projects", "Admin");
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUser(int ID)
        {
            var org = context.Users.Where(m => m.id == ID).FirstOrDefault();
            if (org != null)
            {
                var obj = org;
                obj.deleted = true;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();
            return Json(org, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateLandAcqAccount(LandAcquisitionAccount obj)
        {
            obj.datetime = DateTime.Now;
            obj.updatedAt = DateTime.Now;
            //account.CreatedBy = Global.UserID;
            //obj.deleted = true;
            context.LandAcquisitionsAccount.Add(obj);
            context.SaveChanges();

            return Json(obj, JsonRequestBehavior.AllowGet);
            //return View(obj);
            //return RedirectToAction("LandAcquisition", "Admin",new { id=obj.projId});
        }
        #endregion

        #region Projects
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project obj)
        {
            obj.datetime = DateTime.Now;
            obj.updatedAt = DateTime.Now;
            //account.CreatedBy = Global.UserID;
            //obj.deleted = true;
            context.Projects.Add(obj);
            context.SaveChanges();

            RedirectToAction("Projects", "Admin");
            return View();
        }

        public ActionResult EditProject()
        {
            return View();
        }

        public JsonResult ProjectsList()
        {
            List<Project> projs = new List<Project>();

            projs = context.Projects.Where(m => m.deleted == false).ToList();

            return Json(projs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyIDProject(int ID)
        {
            var obj = context.Projects.Where(m => m.id == ID).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateProject(Project obj)
        {
            var org = context.Projects.Where(m => m.id == obj.id).FirstOrDefault();
            if (org != null)
            {
                obj = org;
                obj.datetime = org.datetime;
                obj.updatedAt = DateTime.Now;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();

            RedirectToAction("Projects", "Admin");
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProject(int ID)
        {
            var org = context.Projects.Where(m => m.id == ID).FirstOrDefault();
            if (org != null)
            {
                var account = org;
                account.deleted = true;
                context.Entry(org).CurrentValues.SetValues(account);
            }
            context.SaveChanges();
            RedirectToAction("Projects", "Admin");
            return Json(org, JsonRequestBehavior.AllowGet);
        }

        #endregion
        
        #region Land Acquisition Account
        public JsonResult LAAccountList(int landAcqId)
        {

            List<LandAcquisitionAccount> accounts = context.LandAcquisitionsAccount.Where(m => m.landAcqId== landAcqId).OrderBy(m => m.datetime).ToList();
            double balance = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                balance = accounts[i].balance = balance + accounts[i].debit - accounts[i].credit;
            }
            return Json(accounts, JsonRequestBehavior.AllowGet);

            //var la = context.LandAcquisitionsAccount.Where(p => p.landAcqId == landAcqId).ToList();

            //return Json(la, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditLAAccount()
        {
            return View();
        }

        public JsonResult UpdateLAAccount(LandAcquisitionAccount obj)
        {
            var org = context.LandAcquisitionsAccount.Where(m => m.id == obj.id).FirstOrDefault();
            if (org != null)
            {
                org.details = obj.details;
                org.debit = obj.debit;
                org.credit = obj.credit;
                //org.datetime = DateTime.Now;
                obj = org;
                obj.updatedAt = DateTime.Now;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyIDLAAccount(int ID)
        {
            var obj = context.LandAcquisitionsAccount.Where(m => m.id == ID).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Land Acquisition
        public ActionResult LandAcquisition()
        {
            return View();
        }
        public ActionResult CreateLA()
        {
            return View();
        }

        public ActionResult DetailsLA()
        {
            return View();
        }

        
        public JsonResult CreateLandAcq(LandAcquisition obj)
        {
            obj.datetime = DateTime.Now;
            //account.CreatedBy = Global.UserID;
            //obj.deleted = true;
            context.LandAcquisitions.Add(obj);
            context.SaveChanges();

            return Json(obj, JsonRequestBehavior.AllowGet);
            //return View(obj);
            //return RedirectToAction("LandAcquisition", "Admin",new { id=obj.projId});
        }

        public ActionResult EditLA()
        {
            return View();
        }
        public JsonResult LAList(int projId)
        {
            var la = context.LandAcquisitions.Where(p => p.projId == projId).ToList();

            return Json(la, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyIDLA(int ID)
        {
            var obj = context.LandAcquisitions.Where(m => m.id == ID).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateLA(LandAcquisition obj)
        {
            var org = context.LandAcquisitions.Where(m => m.id == obj.id).FirstOrDefault();
            if (org != null)
            {
                org.name = obj.name;
                org.details= obj.details;
                //org.datetime = DateTime.Now;
                obj = org;
                obj.updatedAt = DateTime.Now;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();
            
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteLA(int ID)
        {
            var org = context.LandAcquisitions.Where(m => m.id == ID).FirstOrDefault();
            if (org != null)
            {
                var account = org;
                account.deleted = true;
                context.Entry(org).CurrentValues.SetValues(account);
            }
            context.SaveChanges();
            return Json(org, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Land Acquisition APs
        public ActionResult LA_AP(int id)
        {
            return View();
        }

        public JsonResult CreateLA_AP(LandAcqAP obj)
        {
            obj.datetime = DateTime.Now;
            context.LandAcqAP.Add(obj);
            context.SaveChanges();

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditLA_AP(int id)
        {
            return View();
        }
        public JsonResult GetbyIDLA_APs(int ID)
        {
            var obj = context.LandAcqAP.Where(m => m.id == ID).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateLA_APs(LandAcqAP obj)
        {
            var org = context.LandAcqAP.Where(m => m.id == obj.id).FirstOrDefault();
            if (org != null)
            {
                //obj = org;
                obj.datetime =DateTime.Now;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();

            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadLA_APs(int id)
        {
            var APs = context.LandAcqAP.Where(p => p.landAcqId == id).ToList();

            return Json(APs, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Land Acquisition ARs
        public ActionResult LA_AR(int id)
        {
            return View();
        }

        public JsonResult CreateLA_AR(LandAcqAR obj)
        {
            obj.datetime = DateTime.Now;
            context.LandAcqAR.Add(obj);
            context.SaveChanges();

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditLA_AR(int id)
        {
            return View();
        }
        public JsonResult GetbyIDLA_ARs(int ID)
        {
            var obj = context.LandAcqAR.Where(m => m.landAcqId == ID).OrderByDescending(m=>m.datetime).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateLA_ARs(LandAcqAR obj)
        {
            var org = context.LandAcqAR.Where(m => m.id == obj.id).FirstOrDefault();
            if (org != null)
            {
                obj = org;
                obj.datetime = org.datetime;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();

            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadLA_ARs(int id)
        {
            var APs = context.LandAcqAR.Where(p => p.landAcqId == id).ToList();

            return Json(APs, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Plot
        public ActionResult Plots()
        {
            return View();
        }
        public ActionResult CreatePlot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePlot(Plot obj)
        {
            obj.datetime = DateTime.Now;
            //account.CreatedBy = Global.UserID;
            //obj.deleted = true;
            context.Plots.Add(obj);
            context.SaveChanges();
            return RedirectToAction("Plots", "Admin");
        }

        public ActionResult EditPlot()
        {
            return View();
        }
        public JsonResult PlotList(int projId)
        {
            var la = context.Plots.Where(p => p.projId == projId).ToList();

            return Json(la, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyIDPlot(int ID)
        {
            var obj = context.Plots.Where(m => m.id == ID).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdatePlot(Plot obj)
        {
            var org = context.Plots.Where(m => m.id == obj.id).FirstOrDefault();
            if (org != null)
            {
                obj = org;
                obj.datetime = org.datetime;
                context.Entry(org).CurrentValues.SetValues(obj);
            }
            context.SaveChanges();

            //return RedirectToAction("Projects", "Admin");
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePlot(int ID)
        {
            var org = context.Plots.Where(m => m.id == ID).FirstOrDefault();
            if (org != null)
            {
                var account = org;
                account.deleted = true;
                context.Entry(org).CurrentValues.SetValues(account);
            }
            context.SaveChanges();
            return Json(org, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region LandAcquisition Accounts

        #endregion
    }
}