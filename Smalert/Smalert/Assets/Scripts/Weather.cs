using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class Weather : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string url = "http://www.inteligenciafutura.com/api/Weather.php";
        WWWForm form = new WWWForm();
        form.AddField("username", "3b2c520e-eaf5-4862-9ae3-6692092ec1c2");
        form.AddField("password", "Mt7s3PTq2o");
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors access_token and token_type
        if (www.error == null)
        {
            string json = www.text;
            JSONNode data = JSON.Parse(json);
            
            Debug.Log("Post: " + data);
            //Debug.Log("WWW Ok!: " + www.data);
        }
        else
        {
            // Debug.Log("WWW Error: " + www.error);
        }
    }

}
