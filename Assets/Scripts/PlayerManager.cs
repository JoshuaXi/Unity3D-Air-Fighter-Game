using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;
    public GameObject planeToSpawn;
    // Use this for initialization

    void Awake() {
        instance = this;
    }

    void Start() {
        SpawnNewPlane();
    }

    public void SpawnNewPlane() {
        GameObject newPlane = (GameObject)Instantiate(planeToSpawn, Vector3.zero, planeToSpawn.transform.rotation);
    }



}
