using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectParticleSpawn : MonoBehaviour
{
    public int CoinAmount = 10;
    public GameObject CoinParticle;

    void SpawnCoinParticle()
    {
        GameObject spawnedObject = Instantiate(CoinParticle, transform.position, Quaternion.identity, null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SpawnCoinParticle();
            other.GetComponent<CharacterMovement>().CoinCollected(CoinAmount);
            Destroy(gameObject);
        }
    }
}
