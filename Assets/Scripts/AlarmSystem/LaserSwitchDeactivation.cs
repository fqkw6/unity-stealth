using UnityEngine;

public class LaserSwitchDeactivation : MonoBehaviour {

    public GameObject laser;
    public Material unlockedMat;

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetButton("Switch"))
            {
                LaserDeactivate();
            }
        }
    }

    private void LaserDeactivate()
    {
        laser.SetActive(false);
        Renderer screen = transform.Find("prop_switchUnit_screen").renderer;
        screen.material = unlockedMat;
        audio.Play();
    }
}
