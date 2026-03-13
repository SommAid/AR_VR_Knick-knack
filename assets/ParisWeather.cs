using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using System.Globalization;

public class ParisWeather : MonoBehaviour
{
    public GameObject weatherTextObject;
    public GameObject rainEffect;
    private string url = "https://api.openweathermap.org/data/2.5/weather?lat=48.864716&lon=2.349014&APPID=<API_key_Here>&units=imperial";

    void Start()
    {
        Debug.Log("Weather Script Starting...");

        if (rainEffect != null)
        {
            rainEffect.SetActive(false);
        }

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

                int startTemp = jsonResponse.IndexOf("temp", 0);
                int endTemp = jsonResponse.IndexOf(",", startTemp);
                double tempF = double.Parse(jsonResponse.Substring(startTemp + 6, (endTemp - startTemp - 6)), CultureInfo.InvariantCulture);
                int easyTempF = Mathf.RoundToInt((float)tempF);

                int startConditions = jsonResponse.IndexOf("\"main\":\"", jsonResponse.IndexOf("\"weather\"")) + 8;
                int endConditions = jsonResponse.IndexOf("\"", startConditions);
                string conditions = jsonResponse.Substring(startConditions, (endConditions - startConditions));

                Debug.Log("Paris, France temp: " + easyTempF + "F, Conditions: " + conditions);

                if (rainEffect != null)
                {
                    string lowerConditions = conditions.ToLower();

                    if (lowerConditions.Contains("rain") || lowerConditions.Contains("drizzle") || lowerConditions.Contains("thunderstorm"))
                    {
                        rainEffect.SetActive(true); // rain
                    }
                    else
                    {
                        rainEffect.SetActive(false); // no rain
                    }
                }

                if (weatherTextObject != null)
                {
                    var tmp = weatherTextObject.GetComponent<TextMeshPro>();
                    if (tmp != null)
                    {
                        tmp.text = "Paris, France\n" + easyTempF.ToString() + "°F\n" + conditions;
                    }
                    else
                    {
                        weatherTextObject.GetComponent<TextMeshProUGUI>().text = "Paris, France\n" + easyTempF.ToString() + "°F\n" + conditions;
                    }
                }
            }
        }
    }
}

