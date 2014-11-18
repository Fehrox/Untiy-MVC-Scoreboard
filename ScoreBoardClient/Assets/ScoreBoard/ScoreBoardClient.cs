
using System.Collections;
using UnityEngine;
using JsonFx.Json;
using System;

namespace ScoreBoardClient
{
    public class ScoreBoardClient
    {
        string _serverUri, _gameName;
        public ScoreBoardClient(string serverUri, string gamename) { 
            _serverUri = serverUri;
            _gameName = gamename;
        }

        public IEnumerator GetGameScores(Action<Score[]> resultHandler) {
            var request = new WWW(_serverUri + "Board?gameName="+_gameName);
            yield return request;
            if (request.error != null) {
                Debug.LogError(request.error);
            } else {
                var reader = new JsonReader();
                resultHandler(reader.Read<Score[]>(request.text));
            }
        }

        public IEnumerator SubmitGameScore(string playerName, 
                                           int points, 
                                           Action<bool> responseHandler) { 

            var checkSum = CheckSumScore.CheckSum(playerName, points);
            var request = new WWW(_serverUri + "Score" +
                "?gameName=" + _gameName +
                "&playerName=" + playerName +
                "&points=" + points +
                "&checkSum=" + checkSum);
            yield return request;
            if (request.error != null) {
                Debug.LogError(request.error);
            } else {
                var reader = new JsonReader();
                responseHandler(reader.Read<bool>(request.text));
            }
        }
    }
}
