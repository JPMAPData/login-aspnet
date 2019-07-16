using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;
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
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            string clientID = "Dm1AJ95famLKnf4MUOGpwO7zJIcBF4J7";
            string clientSecret = "V050fdb1761e4460";

            TwoLeggedApi _twoLeggedApi = new TwoLeggedApi();

            var retorno = _twoLeggedApi.Authenticate(clientID, clientSecret, oAuthConstants.CLIENT_CREDENTIALS, new Scope[] { Scope.DataRead, Scope.DataCreate, Scope.DataWrite, Scope.ViewablesRead });

            //Task<ApiResponse<dynamic>> retorno = _twoLeggedApi.AuthenticateAsyncWithHttpInfo(clientID, clientSecret, oAuthConstants.CLIENT_CREDENTIALS, new Scope[] { Scope.DataRead, Scope.DataCreate, Scope.DataWrite, Scope.ViewablesRead });

            //if (retorno.Result.StatusCode < 200 || retorno.Result.StatusCode >= 300)
            //{
            //    throw new Exception("Erro de CONEXAO");
            //}

            string token;

            token = retorno["access_token"];

            HubsApi hubsApi = new HubsApi();
            hubsApi.Configuration.AccessToken = token;

            Dictionary<string, string> pastas = new Dictionary<string, string>();

            var hubs = hubsApi.GetHubs();

            foreach (KeyValuePair<string, dynamic> hubtInfo in new DynamicDictionaryItems(hubs.data))
            {
                ProjectsApi projectsApi = new ProjectsApi();
                var projects = projectsApi.GetHubProjects(hubtInfo.Value.id);
                foreach (KeyValuePair<string, dynamic> projectInfo in new DynamicDictionaryItems(projects.data))
                {
                    //ListBox1.Items.Add(projectInfo.Value.attributes.name);
                    ListItem projeto = new ListItem("Projeto "+projectInfo.Value.attributes.name, projectInfo.Value.id);
                    CheckBoxList1.Items.Add(projeto);

                    var folders = projectsApi.GetProjectTopFolders(hubtInfo.Value.id, projectInfo.Value.id);
                  
                    foreach (KeyValuePair<string, dynamic> folder in new DynamicDictionaryItems(folders.data))
                    {
                        if (folder.Value.type == "folders")
                        {
                            ListItem pasta = new ListItem("Pasta " + folder.Value.attributes.name, folder.Value.id);
                            CheckBoxList1.Items.Add(pasta);
                            addFolders(pasta);
                        }
                    }

                    void addFolders(ListItem pastam)
                    {
                        var folders_inside = projectsApi.GetProjectTopFolders(hubtInfo.Value.id, projectInfo.Value.id);

                        foreach (KeyValuePair<string, dynamic> folder_inside in new DynamicDictionaryItems(folders_inside.data))
                        {
                            if (folder_inside.Value.type == "folders")
                            {
                                ListItem pasta_inside = new ListItem("Pasta " + folder_inside.Value.attributes.name, folder_inside.Value.id);
                                CheckBoxList1.Items.Add(pasta_inside);
                                addFolders(pasta_inside);
                            }
                        }

                    }

                }
            }


        }
    }
}