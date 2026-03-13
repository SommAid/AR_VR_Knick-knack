using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class weather_api : MonoBehaviour
{
    public GameObject weatherTextObject;

    private string url = "https://api.openweathermap.org/data/2.5/weather?lat=32.7157&lon=-117.1611&APPID=<API_KEY_HERE>&units=imperial";

    void Start()
    {
        Debug.Log("Weather Script Starting...");

        // Check every 10 minutes (600s)
        InvokeRepeating("GetDataFromWeb", 2f, 600f);
    }

    void GetDataFromWeb()
    {
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Weather Error: " + webRequest.error);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Debug.Log("Received Weather Data: " + jsonResponse);

                int startTemp = jsonResponse.IndexOf("temp", 0);
                int endTemp = jsonResponse.IndexOf(",", startTemp);
                double tempF = float.Parse(jsonResponse.Substring(startTemp + 6, (endTemp - startTemp - 6)));
                int easyTempF = Mathf.RoundToInt((float)tempF);

                // OpenWeather puts the main condition (e.g., "Clear") inside the "weather" array
                int startConditions = jsonResponse.IndexOf("\"main\":\"", jsonResponse.IndexOf("\"weather\"")) + 8;
                int endConditions = jsonResponse.IndexOf("\"", startConditions);
                string conditions = jsonResponse.Substring(startConditions, (endConditions - startConditions));

                Debug.Log("San Diego Temp: " + easyTempF + "F, Conditions: " + conditions);

                // Update the TextMeshPro text
                if (weatherTextObject != null)
                {
                    // Check if it's TextMeshPro or TextMeshProUGUI (Canvas vs World)
                    var tmp = weatherTextObject.GetComponent<TextMeshPro>();
                    if (tmp != null)
                    {
                        tmp.text = "San Diego\n" + easyTempF.ToString() + "°F\n" + conditions;
                    }
                    else
                    {
                        // Fallback if you are using a Canvas-based TMP
                        weatherTextObject.GetComponent<TextMeshProUGUI>().text = "San Diego\n" + easyTempF.ToString() + "°F\n" + conditions;
                    }
                }
            }
        }
    }
}
