using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{    
    private Player _player;
    [SerializeField]
    private AudioClip _coinSound;

    // Start is called before the first frame update
    void Start()
    {
        Player _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!_player)
        {
            Debug.LogError("Failed to find Game Object with tag: Player");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            _player.AddCoin();
            this.GetComponent<SphereCollider>().enabled = false;
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            Destroy(this.gameObject);
        }
    }
}
