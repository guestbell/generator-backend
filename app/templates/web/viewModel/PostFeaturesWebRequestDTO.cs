using System.Collections.Generic;
using GuestBell.Common.Web.Base;
using GuestBell.Common.Web.Model.<%= featureName %>;

namespace GuestBell.Common.Web.ViewModel.<%= featureName %>
{
    public class Post<%= featureName %>sWebRequestDTO : BaseWebRequestDTO
    {
        public List<Post<%= featureName %>WebDTO> <%= featureName %>s { get; set; }
    }
}
