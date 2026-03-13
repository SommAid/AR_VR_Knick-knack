using UnityEngine;
using TMPro;
using System;
using System.Runtime.InteropServices;

public class ParisClock : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Update()
    {
        if (timeText == null) return;

        try
        {
            DateTime utcTime = DateTime.UtcNow;
            string tzId;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                tzId = "W. Europe Standard Time";
            }
            else
            {
                tzId = "Europe/Paris";
            }

            TimeZoneInfo parisTimeZone = TimeZoneInfo.FindSystemTimeZoneById(tzId);
            DateTime parisTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, parisTimeZone);

            timeText.text = "Paris\n" + parisTime.ToString("HH:mm:ss");
        }
        catch (TimeZoneNotFoundException)
        {
            timeText.text = "TZ Not Found";
        }
        catch (Exception e)
        {
            timeText.text = "Error!";
            Debug.LogError($"Clock Error: {e.Message}");
        }
    }
}