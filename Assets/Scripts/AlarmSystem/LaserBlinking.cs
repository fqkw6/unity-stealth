using UnityEngine;

public class LaserBlinking : MonoBehaviour {

    public float onTime;
    public float offTime;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (renderer.enabled && timer >= onTime)
            // Switch the beam.
            SwitchBeam();

        // If the beam is off and the offTime has been reached...
        if (!renderer.enabled && timer >= offTime)
            // Switch the beam.
            SwitchBeam();

    }

    void SwitchBeam() 
    {
        timer = 0f;
        renderer.enabled = !light.enabled;
        light.enabled = !light.enabled;

    }


}
