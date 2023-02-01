using Microsoft.EntityFrameworkCore;
using UserSearch.Domain;

namespace UserSearch.Infrastructure;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseInMemoryDatabase("Users");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Antony", LastName = "Fitt", Email = "afitt0@a8.net", Gender = "Male" },
            new User
            {
                Id = 2, FirstName = "Katey", LastName = "Gaines", Email = "kgaines1@bbb.org", Gender = "Female"
            },
            new User
            {
                Id = 3, FirstName = "Ardelle", LastName = "Soames", Email = "asoames2@google.it", Gender = "Female"
            },
            new User
            {
                Id = 4, FirstName = "Kalila", LastName = "Tennant", Email = "ktennant3@phpbb.com", Gender = "Female"
            },
            new User { Id = 5, FirstName = "Veda", LastName = "Emma", Email = "vemma4@nature.com", Gender = "Female" },
            new User { Id = 6, FirstName = "Pauli", LastName = "Isacke", Email = "pisacke5@is.gd", Gender = "Female" },
            new User
            {
                Id = 7, FirstName = "Belita", LastName = "Ruoff", Email = "bruoff6@wiley.com", Gender = "Female"
            },
            new User
            {
                Id = 8, FirstName = "James", LastName = "Kubu", Email = "hkubu7@craigslist.org", Gender = "Male"
            },
            new User
            {
                Id = 9, FirstName = "Jasen", LastName = "Jiroudek", Email = "jjiroudek8@google.it",
                Gender = "Polygender"
            },
            new User
            {
                Id = 10, FirstName = "Gusty", LastName = "Tuxill", Email = "gtuxill9@illinois.edu", Gender = "Female"
            },
            new User
            {
                Id = 11, FirstName = "James", LastName = "Pfeffer", Email = "bpfeffera@amazon.com", Gender = "Male"
            },
            new User
            {
                Id = 12, FirstName = "Mignonne", LastName = "Whitewood", Email = "mwhitewoodb@godaddy.com",
                Gender = "Female"
            },
            new User
            {
                Id = 13, FirstName = "Moselle", LastName = "Gaize", Email = "mgaizec@tumblr.com", Gender = "Female"
            },
            new User
            {
                Id = 14, FirstName = "Chalmers", LastName = "Longfut", Email = "clongfujam@wp.com", Gender = "Male"
            },
            new User
            {
                Id = 15, FirstName = "Linnell", LastName = "Jumont", Email = "ljumonte@storify.com", Gender = "Female"
            },
            new User
            {
                Id = 16, FirstName = "Viole", LastName = "Eaglen", Email = "veaglenf@nytimes.com", Gender = "Female"
            },
            new User
            {
                Id = 17, FirstName = "Sileas", LastName = "Tarr", Email = "starrg@telegraph.co.uk", Gender = "Female"
            },
            new User
            {
                Id = 18, FirstName = "Katey", LastName = "Soltan", Email = "ksoltanh@simplemachines.org",
                Gender = "Female"
            },
            new User
            {
                Id = 19, FirstName = "Gar", LastName = "Motion", Email = "gmotioni@shop-pro.jp", Gender = "Male"
            },
            new User
            {
                Id = 20, FirstName = "Kameko", LastName = "Vanes", Email = "kvanesj@discuz.net", Gender = "Female"
            });
    }
}