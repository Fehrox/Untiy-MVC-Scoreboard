
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
            var scoreRequest = new WWW(_serverUri + "Board?gameName="+_gameName);
            yield return scoreRequest;
            var reader = new JsonReader();
            resultHandler(reader.Read<Score[]>(scoreRequest.text));
        }

        public void SubmitGameScore(string playerName, int points) { 
            var scoreForm = new WWWForm();
            var checkSum = CheckSumScore.CheckSum(playerName, points);
            var scoreSubmit = new WWW(_serverUri + "Score" +
                "?gameName=" + _gameName + 
                "?userName=" + playerName + 
                "?checkSum=" + checkSum + 
                "?points=" + points);
        }
    }
}
