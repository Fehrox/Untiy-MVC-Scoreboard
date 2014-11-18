using UnityEngine;
using System.Collections;
using ScoreBoardClient;

public class ScoreBoardTest : MonoBehaviour {

	void Start () {
        //Arrange.
        var gameName = "OrbitalExchange";
        var address = "http://localhost:4035/api/";
        //var address = "http://pixelflair.com.au/ScoreBoard/api/";
        var client = new ScoreBoardClient.ScoreBoardClient(address, gameName);

        StartCoroutine(TestRetrieve(client));
        TestSubmit(client);

	}

    void TestSubmit(ScoreBoardClient.ScoreBoardClient client) {
        StartCoroutine(client.SubmitGameScore("Mel", 200, r => {
            if (r) {
                Debug.Log("Score sucessfully submitted!");
            } else {
                Debug.Log("Failed to submit score!");
            }
        }));
    }

    IEnumerator TestRetrieve(ScoreBoardClient.ScoreBoardClient client) {

        Score[] scores = new Score[0];
        StartCoroutine(client.GetGameScores(r => { scores = r; }));
        while (scores.Length == 0)
            yield return null;

        foreach (var score in scores) {
            Debug.Log(score.PlayerName + " " + score.Points);
        }

    }
}
