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
using ScoreBoard;

namespace ScoreBoardServices.Controllers
{
    public class ScoreController : ApiController
    {
        private Entities db = new Entities();

        // Get api/Score
        public bool Get(
            string gameName,
            string playerName,
            int points,
            string checkSum) {
 
            // Make new score board for game if it doesn't exist already.
            // TODO: Make another secure method of creating these.
            var gameScoreBoards = db.Boards.Where(sb => sb.GameName == gameName);
            Board gameScoreBoard;
            if (!gameScoreBoards.Any()) {
                var newScoreBoard = new Board { GameName = gameName };
                gameScoreBoard = db.Boards.Add(newScoreBoard);
                db.SaveChanges();
            } else {
                gameScoreBoard = gameScoreBoards.First();
            }

            // Check that the score is valid.
            var securityPassed = CheckSumScore.CheckSum(playerName, points) == checkSum;
            if (!securityPassed) return false;

            // Register new score.
            db.Scores.Add(
                new Score {
                    BoardId = gameScoreBoard.Id,
                    PlayerName = playerName,
                    Points = points
                });

            if (ModelState.IsValid) {
                db.SaveChanges();
            }

            return true;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}