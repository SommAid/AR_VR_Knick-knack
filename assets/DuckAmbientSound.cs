using UnityEngine;
using System.Collections;

public class DuckAmbientSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float minDelay = 5f; // Min delay
    public float maxDelay = 20f; // Max delay
    public float quackVolume = .1f;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        StartCoroutine(QuackLoop());
    }

    IEnumerator QuackLoop()
    {
        while (true)
        {
            // Wait for a random amount of time
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            // Play the quack
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip, quackVolume);
            }
        }
    }
}
