using ECommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Data
{
    public class CameraGearContext : DbContext
    {
        public CameraGearContext(DbContextOptions<CameraGearContext> options) : base(options)// Constructor
        {

        }

        public DbSet<CameraGear> cameraGears { get; set; }
    }
}
