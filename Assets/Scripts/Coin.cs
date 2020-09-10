using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Player _player;

private void OnTriggerEnter(Collider other)
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is null");
        }
        if (other.CompareTag("Player"))
        {
            _player.addCoin();
            Destroy(this.gameObject);
        }
    }
}
