namespace ScoreBoardClient
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string PlayerName { get; set; }
        public int Points { get; set; }
    }
}
