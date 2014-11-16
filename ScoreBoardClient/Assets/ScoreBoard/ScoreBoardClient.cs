
using System.Collections;
using UnityEngine;
using JsonFx.Json;

namespace ScoreBoardClient
{
    public class ScoreBoardClient
    {
        string _serverUri, _gameName;
        public ScoreBoardClient(string serverUri, string gamename) { 
            _serverUri = serverUri;
            _gameName = gamename;
        }

        public IEnumerator GetGameScores(System.Action<Score[]> resultHandler) {
            var scoreGet = new WWW(_serverUri + "Board?gameName="+_gameName);
            yield return scoreGet;
            var reader = new JsonReader();
            resultHandler(reader.Read<Score[]>(scoreGet.text));
        }

        public IEnumerator SubmitGameScore(string playerName, int points) { 
            var checkSum = CheckSumScore.CheckSum(playerName, points);
            var scorePost = new WWW(_serverUri + "Score" +
                "?gameName=" + _gameName +
                "&playerName=" + playerName +
                "&points=" + points +
                "&checkSum=" + checkSum); 
            yield return scorePost;
            if (scorePost.error != null) {
                Debug.LogError(scorePost.error);
            }
        }
    }
}
