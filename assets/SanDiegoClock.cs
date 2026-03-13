using UnityEngine;
using TMPro;
using System;
using System.Runtime.InteropServices; 
public class SanDiegoClock : MonoBehaviour
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
                tzId = "Pacific Standard Time";
            }
            else
            {
                tzId = "America/Los_Angeles";
            }

            TimeZoneInfo sdTimeZone = TimeZoneInfo.FindSystemTimeZoneById(tzId);
            DateTime sdTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, sdTimeZone);

            timeText.text = sdTime.ToString("hh:mm:ss tt") + "\nSan Diego";
        }
        catch (Exception e)
        {
            timeText.text = "Timezone Error!";
            Debug.LogError("Clock Error: " + e.Message);
        }
    }
}