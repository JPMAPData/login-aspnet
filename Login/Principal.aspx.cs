using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;
using MAPDataForge.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usuario"] == null)
            //    Response.Redirect("Login.aspx");

            if (!Page.IsPostBack)
            {
                string clientID = "Dm1AJ95famLKnf4MUOGpwO7zJIcBF4J7";
                string clientSecret = "V050fdb1761e4460";
                if (MAPDataForge.Global.Token.Validade < DateTime.Now) MAPDataForge.Global.GenetrateToken(clientID, clientSecret);

                Dictionary<string, string> pastas = new Dictionary<string, string>();

                var hubs = MAPDataForge.MAPBIM360.GetHubs();

                if (hubs.Count != 1) throw new Exception("Mais de um hub retornado");

                Global.HubID = hubs[0].ID;

                foreach (Projeto projectInfo in MAPDataForge.MAPBIM360.GetProjects(Global.HubID))
                {
                    treProjetos.Nodes.Add(new TreeNode(projectInfo.Nome, projectInfo.ID));
                }

            }
        }

        protected void treProjetos_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (treProjetos.SelectedNode.Depth == 0)
            {
                string projectID = treProjetos.SelectedNode.Value;
                var folders = MAPDataForge.MAPBIM360.GetTopFolders(Global.HubID, projectID);
                foreach (var folder in folders)
                {
                    treProjetos.SelectedNode.ChildNodes.Add(new TreeNode(folder.Nome, projectID + "|" + folder.ID));
                }
            }
            else
            {
                string[] IDs = treProjetos.SelectedNode.Value.Split('|');
                var folders = MAPDataForge.MAPBIM360.GetFolders(IDs[0],IDs[1]);
                foreach (var folder in folders)
                {
                    treProjetos.SelectedNode.ChildNodes.Add(new TreeNode(folder.Nome, IDs[0] + "|" + folder.ID));
                }
            }
        }


        //    //ListBox1.Items.Add(projectInfo.Value.attributes.name);
        //    ListItem projeto = new ListItem("Projeto "+projectInfo.Value.attributes.name, projectInfo.Value.id);
        //    CheckBoxList1.Items.Add(projeto);

        //    var folders = projectsApi.GetProjectTopFolders(hubtInfo.ID, projectInfo.Value.id);

        //    foreach (KeyValuePair<string, dynamic> folder in new DynamicDictionaryItems(folders.data))
        //    {
        //        if (folder.Value.type == "folders")
        //        {
        //            ListItem pasta = new ListItem("Pasta " + folder.Value.attributes.name, folder.Value.id);
        //            CheckBoxList1.Items.Add(pasta);
        //            addFolders(pasta);
        //        }
        //    }

        //void addFolders(ListItem pastam)
        //{
        //    var folders_inside = projectsApi.GetProjectTopFolders(hubtInfo.Value.id, projectInfo.Value.id);

        //    foreach (KeyValuePair<string, dynamic> folder_inside in new DynamicDictionaryItems(folders_inside.data))
        //    {
        //        if (folder_inside.Value.type == "folders")
        //        {
        //            ListItem pasta_inside = new ListItem("Pasta " + folder_inside.Value.attributes.name, folder_inside.Value.id);
        //            CheckBoxList1.Items.Add(pasta_inside);
        //            addFolders(pasta_inside);
        //        }
        //    }

        //}
    }
}