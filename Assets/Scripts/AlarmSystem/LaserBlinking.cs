using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour {

    public float onTime;
    public float offTime;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if ( (renderer.enabled && timer >= onTime) || (!renderer.enabled && timer >= offTime) )
        {
            SwitchBeam();
        }

    }

    void SwitchBeam() 
    {
        timer = 0f;
        renderer.enabled = !light.enabled;
        light.enabled = !light.enabled;

    }


}
