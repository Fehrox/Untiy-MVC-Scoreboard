using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScoreBoard {
    public class Entities : DbContext{
         public DbSet<Score> Scores { get; set; }
         public DbSet<Board> Boards { get; set; }
    }
}