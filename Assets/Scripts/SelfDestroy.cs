using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {
    public float destructionTime = 15;
	// Use this for initialization
	void Start () {
        StartCoroutine(selfDestroyRoutine());
	}

    IEnumerator selfDestroyRoutine() {
        yield return new WaitForSeconds(destructionTime);
        Destroy(gameObject);
    }
}
