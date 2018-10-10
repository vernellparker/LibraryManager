using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LibraryManager.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? GenreId { get; set; }
        public int? BookId { get; set; }
        public int? CustomerId { get; set; }
        public int? MembershipId { get; set; }

        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (BookId != null && BookId > 0)
                {
                    param.Append($"{BookId}");
                }
                if (GenreId != null && GenreId > 0)
                {
                    param.Append($"{GenreId}");
                }
                if (CustomerId != null && CustomerId > 0)
                {
                    param.Append($"{CustomerId}");
                }
                if (MembershipId != null && MembershipId > 0)
                {
                    param.Append($"{MembershipId}");
                }

                return param.ToString();

            }
        }
    }
}