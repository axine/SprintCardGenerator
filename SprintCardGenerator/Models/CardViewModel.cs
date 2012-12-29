using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SprintCardGenerator.Models
{
    public class CardViewModel
    {
        public CardViewModel(string title, string issueKey, string projectKey, string assignee, string summary, string estimate, string status)
        {
            Title = title;
            IssueKey = issueKey;
            ProjectKey = projectKey;
            Assignee = assignee;
            Summary = summary;
            OriginalEstimate = estimate;
            Status = status;
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
    }
}