using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SS.API.Controllers
{
    public class teestMVController : Controller
    {
        // GET: teestMV
        public ActionResult Index()
        {
            return View();
        }

        // GET: teestMV/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: teestMV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: teestMV/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: teestMV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: teestMV/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: teestMV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: teestMV/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}