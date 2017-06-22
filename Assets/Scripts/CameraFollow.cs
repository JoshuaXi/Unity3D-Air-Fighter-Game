using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        if (PlaneController.instance == null) return;

        Vector3 targetPosition = PlaneController.instance.transform.position;
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
	}
}
