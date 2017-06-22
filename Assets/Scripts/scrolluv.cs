using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolluv : MonoBehaviour {

	float parralax = 4f;

	void Update ()  {

		MeshRenderer mr = GetComponent<MeshRenderer> ();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x = transform.position.x / transform.localScale.x / parralax;
		offset.y = transform.position.z / transform.localScale.y / parralax;


		mat.mainTextureOffset = offset;

	}

}