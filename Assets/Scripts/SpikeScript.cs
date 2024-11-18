using System;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public SpikeGeneratorScript spikeGenerator;

    // Update is called once per frame
    void Update()
    {
        if (spikeGenerator != null)
        {
            transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextline"))
        {
            spikeGenerator.GenerateSpikeContinuously();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }

    internal void SetSpeed(float currentSpeed)
    {
        spikeGenerator.currentSpeed = currentSpeed;
    }
}
