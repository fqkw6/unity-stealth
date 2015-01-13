using UnityEngine;

public class KeyPickup : MonoBehaviour {
    public AudioClip pickClip;

    private GameObject player;
    private PlayerInventory playerInventory;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        playerInventory = player.GetComponent<PlayerInventory>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            AudioSource.PlayClipAtPoint(pickClip, transform.position);
            Debug.Log("on play");
            playerInventory.hasKey = true;
            Destroy(gameObject);
        }
    }

}
