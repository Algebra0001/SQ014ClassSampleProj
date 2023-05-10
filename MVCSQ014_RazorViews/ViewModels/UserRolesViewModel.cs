namespace MVCSQ014_RazorViews.ViewModels
{
    public class UserRolesViewModel
    {
        //public string SearchTerm { get; set; } = "";
        public List<UserRolesDetail> UserRolesDetails { get; set; } = new List<UserRolesDetail>();

        public UserRolesDetail RoleToEdit { get; set; }
        public UserRolesViewModel() 
        { 
            UserRolesDetails= new List<UserRolesDetail>();
        }
    
    }
}
