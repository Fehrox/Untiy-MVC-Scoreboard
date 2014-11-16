namespace ScoreBoardClient
{
    using System;
    using System.Collections.Generic;
    
    public partial class Board
    {
        public Board()
        {
            this.Scores = new HashSet<Score>();
        }
    
        public int Id { get; set; }
        public string GameName { get; set; }
    
        public virtual ICollection<Score> Scores { get; set; }
    }
}
