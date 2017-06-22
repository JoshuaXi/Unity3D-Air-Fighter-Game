using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour {

	// Use this for initialization

	// Update is called once per frame
	void Update () {
	transform.Rotate(0, 90 * Time.deltaTime,0);
	}
}
