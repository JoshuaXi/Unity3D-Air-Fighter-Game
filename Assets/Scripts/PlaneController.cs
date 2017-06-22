using UnityEngine;
using System.Collections;
public class PlaneController : MonoBehaviour {
   public Rigidbody rigid;
    public float SpeedMultiplier = 2;
    public float steeringPower = 180;
    public static PlaneController instance;

     Transform controllerStick;
     Transform controllerCenter;


    void Awake() {
        instance = this;
    }

    void Start() {

    }

	
	// Update is called once per frame
	void Update () {

        controllerStick = Controller.instance.stick;
        controllerCenter = Controller.instance.center;
        RotatePlane();
	}
    void FixedUpdate() {
        MovePlane();

    }

    void MovePlane() {
        rigid.velocity = transform.forward*SpeedMultiplier;
    }

    void RotatePlane() {

        Vector3 controllerAxis = Vector3.zero;
        //horizontal and vertical
        if (RedControllerContainer.instance.gameObject.activeInHierarchy)
        {

            controllerAxis = controllerStick.position - controllerCenter.position;
        }
        else {

            transform.rotation = Quaternion.identity;
            return;
        }
        controllerAxis = new Vector3(controllerAxis.x, 0, controllerAxis.y);

        if (controllerAxis != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(controllerAxis);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, steeringPower * Time.deltaTime);
        }
    }




}
