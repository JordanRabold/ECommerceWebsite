using ECommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Data
{
    public class CameraGearContext : DbContext
    {
        public CameraGearContext(DbContextOptions<CameraGearContext> options) : base(options)
        {

        }

        public DbSet<CameraGear> cameraGears { get; set; }

        public DbSet<Member> members { get; set; }
    }
}
