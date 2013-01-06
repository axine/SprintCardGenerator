using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using SprintCardGenerator.Models;


namespace SprintCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        public List<string> Colors { get; private set; }
        private readonly Dictionary<string, string> _projectColors = new Dictionary<string, string>();
        private static int _colorIndex;

        public HomeController()
        {
            InitColors();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Hello !";

            return View();
        }
        // This action handles the form POST and the upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
            {
                return null;
            }            
            var model = GetCardsFromXml(file);
            return View("Cards", model);
        }

        public ActionResult Cards()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public List<CardViewModel> GetCardsFromXml(HttpPostedFileBase file)
        {
            var xDocument = XDocument.Load(file.InputStream);
            var issueItems = xDocument.Descendants("item").ToList();
            var projectKeys = new List<string>();
            var cardViewModels = new List<CardViewModel>();
            foreach (var e in issueItems)
            {
                var cardViewModel = new CardViewModel(e);
                cardViewModels.Add(cardViewModel);
                if (!projectKeys.Contains(cardViewModel.ProjectKey))
                {
                    projectKeys.Add(cardViewModel.ProjectKey);
                    
                }
                cardViewModel.TitleColor = GetColor(cardViewModel.ProjectKey);
            }
            var distinctProjectKeys = cardViewModels.Select(c => c.ProjectKey).Distinct().ToList();
            return cardViewModels.OrderBy(c => c.ProjectKey).ToList();
        }

        private static string GetElementValue(XElement issue, string name)
        {
            if (issue == null || issue.Element(name) == null)
            {
                return "";
            }
            return issue.Element(name).Value;
        }

        public string GetColor(string projectKey)
        {
            if (!_projectColors.ContainsKey(projectKey))
            {
                if (_colorIndex > Colors.Count - 1)
                {
                    _colorIndex = 0;
                }
                _projectColors.Add(projectKey, Colors[_colorIndex]);
                _colorIndex++;

            }
            return _projectColors[projectKey];
        }

        private void InitColors()
        {
            Colors = new List<string>
                         {
                             "#F3F781",
                             "#FA5858",
                             "#FAAC58",
                             "#A9F5BC",
                             "#A9A9F5",
                             "#E2A9F3",
                             "#86B404",
                             "#BDAA93",
                             "#A9D0F5"
                         };
        }
    }
}
