using UnityEngine;

public class FlyAway : MonoBehaviour
{
    public float tiltThreshold = 0.5f; // Adjust between 0 and 1
    public float flySpeed = 5f;
    private bool isFlying = false;

    void Update()
    {
        // 1. Get the 'Up' direction of the cube face this duck is on
        // If the script is on the cube face, use transform.up
        Vector3 faceUp = transform.up;

        // 2. Compare it to the World Up (0, 1, 0)
        float dot = Vector3.Dot(faceUp, Vector3.up);

        // 3. Trigger flight if the tilt is too great
        if (dot < tiltThreshold && !isFlying)
        {
            StartFlying();
        }

        if (isFlying)
        {
            // Simple flight logic: move away from the cube face
            transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
        }
    }

    void StartFlying()
    {
        isFlying = true;
        // Optional: Detach from the cube so they don't move with it anymore
        transform.SetParent(null);
    }
}
