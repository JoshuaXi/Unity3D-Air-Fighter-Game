using UnityEngine;
using System.Collections;

public class ExplosionSpawner : MonoBehaviour {
    public static ExplosionSpawner instance;
    public GameObject explosionEffect;
	// Use this for initialization
    void Awake()
    {

        instance = this;
    }

    public void SpawnExplosion(Vector3 position) {

        GameObject newExplosion = (GameObject)Instantiate(explosionEffect, position, explosionEffect.transform.rotation);

    }
}
