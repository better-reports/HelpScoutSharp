using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class Conversation : IHasId
    {
        public class Assignee
        {
            public long id { get; set;}

            public string type { get; set; }

            public string first { get; set; }

            public string last { get; set; }

            public string email { get; set; }
        }

        public class CreatedBy
        {
            public long id { get; set; }

            public string type { get; set; }

            public string email { get; set; }
        }

        public class ClosedByUser
        {
            public long id { get; set; }

            public string type { get; set; }

            public string first { get; set; }

            public string last { get; set; }

            public string photoUrl { get; set; }

            public string email { get; set; }
        }

        public class PrimaryCustomer
        {
            public long id { get; set; }

            public string type { get; set; }

            public string first { get; set; }

            public string last { get; set; }

            public string photoUrl { get; set; }

            public string email { get; set; }
        }

        public class CustomerWaitingSince
        {
            public DateTime time { get; set; }

            public string friendly { get; set; }

            public string latestReplyFrom { get; set; }
        }

        public class Source
        {
            public string type { get; set; }

            public string via { get; set; }
        }

        public class CustomField
        {
            public long id { get; set; }

            public string name { get; set; }

            public string value { get; set; }

            public string text { get; set; }
        }

        public class Tag
        {
            public long id { get; set; }

            public string color { get; set; }

            public string tag { get; set; }
        }

        public class Embedded
        {
            public Thread[] threads { get; set; }
        }

        public long id { get; set; }

        public long number { get; set; }

        public int threads { get; set; }

        public string type { get; set; }

        public long folderId { get; set; }

        public string status { get; set; }

        public string state { get; set; }

        public string subject { get; set; }

        public string preview { get; set; }

        public long mailboxId { get; set; }

        public Assignee assignee { get; set; }

        public CreatedBy createdBy { get; set; }
        
        public DateTime createdAt { get; set; }

        public long closedBy { get; set; }

        public ClosedByUser closedByUser { get; set; }

        public DateTime? closedAt { get; set; }

        public DateTime? userUpdatedAt { get; set; }

        public CustomerWaitingSince customerWaitingSince { get; set; }

        public Source source { get; set; }

        public Tag[] tags { get; set; }

        public string[] cc { get; set; }

        public string[] bcc { get; set; }

        public PrimaryCustomer primaryCustomer { get; set; }

        public CustomField[] customFields { get; set; }

        public Embedded _embedded { get; set; }
    }
}
