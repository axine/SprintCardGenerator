using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SprintCardGenerator.Models
{
    public class CardViewModel
    {
        public CardViewModel(XElement e)
        {
            Title = (string)e.XPathSelectElement("title");
            IssueKey = (string)e.XPathSelectElement("key");
            ProjectName = (string)e.XPathSelectElement("project");
            Assignee = (string)e.XPathSelectElement("assignee");
            Summary = (string)e.XPathSelectElement("summary");
            OriginalEstimate = (string)e.XPathSelectElement("timeoriginalestimate");
            Status = (string)e.XPathSelectElement("status");
            ProjectKey = (string)e.XPathSelectElement("project").Attribute("key");
        }

        public string Title { get; set; }
        public string IssueKey { get; set; }
        public string ProjectKey { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Resolution { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public string OriginalEstimate { get; set; }
        public string TitleColor { get; set; }
        public string ProjectName { get; set; }  
    }
}