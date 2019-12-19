using GuestBell.Common.Web.Base;
using System.Collections.Generic;

namespace GuestBell.Common.Web.ViewModel.<%= featureName %>
{
    public class Post<%= featureName %>sWebResponseDTO : BaseWebResponseDTO
    {
        public List<long> Ids { get; set; }
    }
}
