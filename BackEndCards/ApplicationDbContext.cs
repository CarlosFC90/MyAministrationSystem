using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCards.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndCards
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
