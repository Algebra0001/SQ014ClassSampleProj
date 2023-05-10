using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCSQ014_RazorViews.Data
{
    public class MVCContext : IdentityDbContext
    {
        public MVCContext(DbContextOptions<MVCContext> options): base(options) { }
    }
}
