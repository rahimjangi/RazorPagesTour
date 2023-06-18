using Microsoft.EntityFrameworkCore;
using RazorPagesTour.Data.Models;

namespace RazorPagesTour.Data;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {

    }
    public DbSet<HelpTicket> HelpTickets { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SurveyItem> SurveyItems { get; set; }
}
