
using UnityEngine;

public class HighScores : MonoBehaviour {

    const string privateCode = "PjZZobEChk2R09mGDqGfawRaSXbmB5GUKOM1nXXQhKOg";
    const string publicCode = "5a8193cd39992d09e4cbeb59";
    const string webURL = "http://dreamlo.com/lb/";

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + www.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
    }
}
