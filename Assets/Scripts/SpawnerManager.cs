using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour {
    public SpawnInPlaneRadius coinspawner, missilespawner,bonusspawner;
    public static SpawnerManager instance;
	// Use this for initialization
	void Awake () {
        instance = this;
	}
	
	
}
