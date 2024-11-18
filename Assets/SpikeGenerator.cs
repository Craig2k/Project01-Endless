using System.Collections;
using UnityEngine;

public class SpikeGeneratorScript : MonoBehaviour
{
    public GameObject spike; // Reference to the spike prefab
    public float MinSpeed;   // Minimum speed of spikes
    public float MaxSpeed;   // Maximum speed of spikes
    public float currentSpeed; // Current speed of spikes (affects spawn rate or movement speed)
    public float SpeedMultiplier; // Speed multiplier for increasing speed over time
    private Coroutine spikeCoroutine; // Reference to the running coroutine
    private bool isGenerating = true; // Flag to control spike generation

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;  // Initialize the current speed to the minimum speed
        spikeCoroutine = StartCoroutine(GenerateSpikeContinuously()); // Start the continuous spike generation
    }

    // Coroutine to generate spikes continuously with random delays
    IEnumerator GenerateSpikeContinuously()
    {
        while (isGenerating) // This will keep generating spikes as long as isGenerating is true
        {
            // Adjust spawn rate based on currentSpeed
            // The faster the spikes, the less time between generations (increased frequency)
            float randomWait = Mathf.Lerp(1.2f, 0.1f, (currentSpeed - MinSpeed) / (MaxSpeed - MinSpeed));
            yield return new WaitForSeconds(randomWait);  // Wait for the calculated amount of time
            GenerateSpike(); // Generate a new spike
        }
    }

    // Generate a new spike at the current position and rotation of the generator
    void GenerateSpike()
    {
        GameObject spikeInstance = Instantiate(spike, transform.position, transform.rotation);
        SpikeScript spikeScript = spikeInstance.GetComponent<SpikeScript>();

        // Optionally set the speed of the spike based on currentSpeed
        if (spikeScript != null)
        {
            spikeScript.SetSpeed(currentSpeed);  // Assume you have a method in SpikeScript to set speed
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Gradually increase the speed up to the maximum speed
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier * Time.deltaTime;  // Smoothly increase speed
        }
    }

    // Call this function to stop generating spikes (e.g., on game over or pause)
    public void StopGeneratingSpikes()
    {
        isGenerating = false;
        if (spikeCoroutine != null)
        {
            StopCoroutine(spikeCoroutine);
        }
    }

    // Call this function to restart spike generation if needed
    public void StartGeneratingSpikes()
    {
        if (!isGenerating)
        {
            isGenerating = true;
            spikeCoroutine = StartCoroutine(GenerateSpikeContinuously());
        }
    }
}
