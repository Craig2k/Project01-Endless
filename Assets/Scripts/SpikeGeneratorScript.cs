using UnityEngine;

public class SpikeGeneratorScript : MonoBehaviour
{
    public GameObject spike;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;  // Initialize the speed
        GenerateSpike();          // Call to generate the spike
    }

    public void GenerateSpike()
    {
        // Instantiate a new spike at the current position and rotation of this GameObject
        GameObject spikeInstance = Instantiate(spike, transform.position, transform.rotation);

        spikeInstance.GetComponent<SpikeScript>().spikeGenerator = this;
    }
}