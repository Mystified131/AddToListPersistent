using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        public static int editID;
        public static string editelement;
        static public string Searchstr;

        public IActionResult Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Result()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                ResultViewModel resultViewModel = new ResultViewModel();

                resultViewModel.TheList = TheList;

                return View(resultViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (ModelState.IsValid)
            {
                Listelement newel = new Listelement(resultViewModel.NewElement.ToLower());
                TheList.Add(newel);
                context.Listelements.Add(newel);
                context.SaveChanges();

                resultViewModel.TheList = TheList;

                return View(resultViewModel);
            }

            return Redirect("/Home/Error");

        }


        [HttpGet]
        public IActionResult Remove()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                RemoveViewModel removeViewModel = new RemoveViewModel();

                removeViewModel.TheList = TheList;

                return View(removeViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Remove(RemoveViewModel removeViewModel)

        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (ModelState.IsValid)
            {
                Listelement remstr = context.Listelements.Single(c => c.ID == removeViewModel.NewElement1);
                TheList.RemoveAll(x => x.ID == removeViewModel.NewElement1);
                
                context.Listelements.Remove(remstr);
                context.SaveChanges();


                removeViewModel.TheList = TheList;

                return Redirect("/Home/Result");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult EditSelect()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                EditSelectViewModel editSelectViewModel = new EditSelectViewModel();

                editSelectViewModel.TheList = TheList;

                return View(editSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }


        [HttpPost]
        public IActionResult EditSelect(EditSelectViewModel editSelectViewModel)
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (ModelState.IsValid)
            {
                Listelement editstr = context.Listelements.Single(c => c.ID == editSelectViewModel.NewElement1);
                editID = editSelectViewModel.NewElement1;
                editelement = editstr.Element;
                ViewBag.editID = editID;
                ViewBag.editelement = editelement;


                return View("EditItem");
            }

            return Redirect("/Home/Error");

        }


        [HttpGet]
        public IActionResult EditItem()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                EditItemViewModel editItemViewModel = new EditItemViewModel();

                return View(editItemViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult EditItem(EditItemViewModel editItemViewModel)

        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (ModelState.IsValid)

            {

                Listelement editstr = context.Listelements.Single(c => c.ID == editID);
                editstr.Element = editItemViewModel.NewElement2;
                context.SaveChanges();

                return Redirect("/Home/Result");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchSelect()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                SearchSelectViewModel searchSelectViewModel = new SearchSelectViewModel();

                return View(searchSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult SearchSelect(SearchSelectViewModel searchSelectViewModel)

        {
            if (ModelState.IsValid)

            {
                Searchstr = searchSelectViewModel.Searchstr.ToLower();
                return Redirect("/Home/SearchResult");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchResult()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                SearchResultViewModel searchResultViewModel = new SearchResultViewModel();
                List<Listelement> Anslist = new List<Listelement>();

                foreach (var item in TheList)
                {
                    if (item.Element.Contains(Searchstr))
                    {

                        Anslist.Add(item);

                    }


                }

                if (Anslist.Count == 0)
                {

                    Listelement errstr = new Listelement("That search returned no results.");
                    Anslist.Add(errstr);

                }

                ViewBag.Anslist = Anslist;

                return View(searchResultViewModel);
            }

            else
            {
                return Redirect("/");
            }

        }

        [HttpGet]
        public IActionResult Sort()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                SortViewModel sortViewModel = new SortViewModel();


                List<string> Bridgelist = new List<string>();
                foreach (var item in TheList)
                {

                    Bridgelist.Add(item.Element);

                }

                Bridgelist.Sort();

                sortViewModel.Sortlist = Bridgelist;

                return View(sortViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpGet]
        public IActionResult Random()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                RandomViewModel randomViewModel = new RandomViewModel();

                Random random = new Random();
                int obj = random.Next(0, TheList.Count());

                randomViewModel.Ranobj = TheList[obj];

                return View(randomViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }
        }
        }

