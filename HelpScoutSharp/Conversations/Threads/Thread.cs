using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class Thread
    {
        public class Action
        {
            public string type { get; set; }

            public string text { get; set; }

            //public associatedEntities
        }

        public class Source
        {
            public string type { get; set; }

            public string via { get; set; }
        }

        public class AssignedTo
        {
            public long id { get; set; }

            public string first { get; set; }

            public string last { get; set; }

            public string email { get; set; }
        }

        public class CreatedBy
        {
            public long id { get; set; }

            public string type { get; set; }

            public string first { get; set; }

            public string last { get; set; }

            public string email { get; set; }
        }

        public class ThreadCustomer
        {
            public long id { get; set; }

            public string photoUrl { get; set; }

            public string first { get; set; }

            public string last { get; set; }

            public string email { get; set; }
        }

        public class Embedded
        {
            public class Attachment
            {
                public long id { get; set; }

                public string filename { get; set; }

                public string mimeType { get; set; }

                public long width { get; set; }

                public long height { get; set; }

                public long size { get; set; }
            }

            public Attachment[] attachments { get; set; }
        }

        public long id { get; set; }

        public AssignedTo assignedTo { get; set; }

        public string status { get; set; }

        public string state { get; set; }

        public Action action { get; set; }

        public string body { get; set; }

        public Source source { get; set; }

        public ThreadCustomer customer { get; set; }

        public CreatedBy createdBy { get; set; }

        public long savedReplyId { get; set; }

        public string type { get; set; }

        public string[] to { get; set; }

        public string[] cc { get; set; }

        public string[] bcc { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime openedAt { get; set; }

        public Embedded _embedded { get; set; }
    }
}
