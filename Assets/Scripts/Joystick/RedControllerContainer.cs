using UnityEngine;
using System.Collections;

public class RedControllerContainer : MonoBehaviour {

    public static RedControllerContainer instance;
    public Camera camera;
   

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var pos = camera.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


}
