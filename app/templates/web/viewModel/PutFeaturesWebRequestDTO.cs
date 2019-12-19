using System.Collections.Generic;
using GuestBell.Common.Web.Base;
using GuestBell.Common.Web.Model.<%= featureName %>;

namespace GuestBell.Common.Web.ViewModel.<%= featureName %>
{
    public class Put<%= featureName %>sWebRequestDTO : BaseWebRequestDTO
    {
        public List<Put<%= featureName %>WebDTO> <%= featureName %>s { get; set; }
    }
}
