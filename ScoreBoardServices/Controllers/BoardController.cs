using ScoreBoard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ScoreBoardServices.Controllers
{
    public class BoardController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Board
        public IEnumerable<Board> GetBoards() {
            return db.Boards.AsEnumerable();
        }

        // GET api/Board
        public IEnumerable<Score> Get(string gameName) {
            var scoreBoard = db.Boards.First(sb => sb.GameName == gameName);
            if (scoreBoard == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return scoreBoard.Scores.AsEnumerable();
        }

    }
}