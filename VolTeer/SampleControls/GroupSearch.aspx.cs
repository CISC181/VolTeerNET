using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.DomainModels.VT.Vol;
using System.Xml.Serialization;
using System.IO;
using Telerik.Web.UI;
namespace VolTeer.SampleControls
{
    public partial class GroupSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //sp_GroupSearch_DM gSearch = new sp_GroupSearch_DM();
            //sp_GroupSearch_DM gSearch2 = new sp_GroupSearch_DM();
            //List<sp_GroupSearch_DM> searches = new List<sp_GroupSearch_DM>();

            //gSearch.QueryTerm = "123";
            //searches.Add(gSearch);
            //gSearch2.QueryTerm = "456";
            //searches.Add(gSearch2);


            //var ser = new XmlSerializer(typeof(List<sp_GroupSearch_DM>));

            //StringWriter sw = new StringWriter();
            //ser.Serialize(sw, searches);

            ////return sw.ToString();
        }

        protected void rBTNProcess_Click(object sender, EventArgs e)
        {


            AutoCompleteBoxEntryCollection entries = this.rACGroups.Entries;
            List<sp_GroupSearch_DM> searches = new List<sp_GroupSearch_DM>();
            for (int i = 0; i < entries.Count; i++)
            {

                // Skill doesn't exist, insert new Skill, return SkillID through domain model
                sp_GroupSearch_DM searchDM = new sp_GroupSearch_DM();

                searchDM.QueryTerm = entries[i].Text.ToString();
                searches.Add(searchDM);
            }

            if (entries.Count > 0)
            {
                var ser = new XmlSerializer(typeof(List<sp_GroupSearch_DM>));

                StringWriter sw = new StringWriter();
                ser.Serialize(sw, searches);
            }
            else
            {
                //Error TODO
            }
        }

        protected void rGridAddress_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void rbtSelect_Click(object sender, EventArgs e)
        {

        }
    }
}