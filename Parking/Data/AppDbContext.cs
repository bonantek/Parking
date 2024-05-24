using Microsoft.EntityFrameworkCore;

namespace Parking.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    }
}