using DatabaseProject.Database;
using DatabaseProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseProject.Pages
{
    public class IndexModel : PageModel
    {
        public List<DatabaseClass> Products;

        public void OnGet()
        {
            ConnectDB dbs = new ConnectDB();
            Products = dbs.connectTo();
        }
    }
}