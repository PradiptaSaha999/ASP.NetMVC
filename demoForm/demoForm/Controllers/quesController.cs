using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demoForm.Models;
using Newtonsoft.Json;

namespace demoForm.Controllers
{
    public class quesController : Controller
    {
        private Survey db = new Survey();

        // GET: ques
        public ActionResult Index()
        {
            return View(db.Ques.ToList());
        }


        public ActionResult viewNew()
        {
            int id = 0;
            int count = 0;
            ViewBag.id = id;
            //int[] idArray;
            int Qcount = 0;
            List<queSet> que = new List<queSet>();
            que = db.QueSet.ToList();
            
            Dictionary<string, string> QueSets = new Dictionary<string, string>();
            foreach (queSet queSet in que)
            {
                int q = queSet.AccountID;
                int ID = queSet.ID;
                if (q == id)
                {

                    Dictionary<string, string> QueSets1 = new Dictionary<string, string>();
                    QueSets1 = (JsonConvert.DeserializeObject<Dictionary<string, string>>(queSet.QuesSet));
                    foreach (var key in QueSets1.Keys)
                    {
                        count = QueSets.Count + 1;
                        QueSets.Add(key + "c" + count, QueSets1[key]);
                        if (key.Contains("que"))
                        {   
                            QueSets.Add("ID" + " c" + ID,ID.ToString());
                            //idArray[Qcount] = ID;
                            Qcount++;
                        }
    
                    }

                }

            }

            ViewBag.Message1 = QueSets;
            //}

            return View();
        }

        public ActionResult createNew()
        {
            int id = 0;
            ViewBag.id = id;
           

            return View();
        }

        [HttpPost]
        public ActionResult createNew(FormCollection collection)
        {
            int count = 0;
           
            int accountID = Convert.ToInt32(collection["id"]);
            ViewBag.id = accountID;
            
            Dictionary<string, string> QueSets = new Dictionary<string, string>();
            foreach (var key in collection.AllKeys)
            {
                if(key!="id")
                {
                  
                    count = QueSets.Count+1;
                    QueSets[key + count] = collection[key];

                }
                     
            }

            string serialDat = JsonConvert.SerializeObject(QueSets);
           
           
                queSet queSet = new queSet();
                queSet.AccountID = accountID;
                queSet.QuesSet = serialDat;

                db.QueSet.Add(queSet);
                db.SaveChanges();
            
            ViewBag.Message1 = QueSets;
            return RedirectToAction("Index");
        }

        public ActionResult ViewAll()
        {
            return View(db.Ques.ToList());
        }
        // GET: ques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            que que = db.Ques.Find(id);
            if (que == null)
            {
                return HttpNotFound();
            }
            return View(que);
        }

        // GET: ques/Create
        public ActionResult Create(int id = 0)
        {
            que que = new que();
            if (id != 0)
            {

                que = db.Ques.Where(x => x.ID == id).FirstOrDefault<que>();
               
            }
            return View(que);
        }

        // POST: ques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ques,Op1,Op2,Op3,Op4")] que que)
        {
            if (ModelState.IsValid)
            {
                db.Ques.Add(que);
                db.SaveChanges();
                //return RedirectToAction("ViewAll");
            }
            return RedirectToAction("Index");
            // return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
        }

        // GET: ques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            que que = db.Ques.Find(id);
            if (que == null)
            {
                return HttpNotFound();
            }
            return View(que);
        }

        // POST: ques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ques,Op1,Op2,Op3,Op4")] que que)
        {
            if (ModelState.IsValid)
            {
                db.Entry(que).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(que);
        }

        // GET: ques/Delete/5
        public ActionResult DeleteNew(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            queSet que = db.QueSet.Find(id);
            ViewBag.id = id;
            if (que == null)
            {
                return HttpNotFound();
            }

            return View(que);
        }

        // POST: ques/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNewConfirmed(int? id)
        {
            queSet que = db.QueSet.Find(id);
            db.QueSet.Remove(que);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            que que = db.Ques.Find(id);
            if (que == null)
            {
                return HttpNotFound();
            }
            return View(que);
        }

        // POST: ques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            que que = db.Ques.Find(id);
            db.Ques.Remove(que);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
