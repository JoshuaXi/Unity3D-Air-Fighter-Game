using UnityEngine;
using System.Collections;

public class RedController : MonoBehaviour
{

    public static RedController instance;
    float maxX = 1.70f;


    Vector3 originalPosition;

    void Awake()
    {
        originalPosition = transform.position;
    }

    // Use this for initialization
    void Start()
    {
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) == false)
        {
            transform.localPosition = Vector3.zero;
            return;
        }

        Vector2 worldMousePos = RedControllerContainer.instance.camera.ScreenToWorldPoint(Input.mousePosition);
        float distanceBetweenControllerCenterAndMousePos = Vector2.Distance(RedControllerContainer.instance.transform.position, worldMousePos);

        if (distanceBetweenControllerCenterAndMousePos > maxX * transform.root.localScale.x)
        {
            transform.localPosition = new Vector3(maxX, 0, 0);
        }
        else
        {
            transform.position = new Vector3(worldMousePos.x, worldMousePos.y, originalPosition.z);
        }

    }

    void OnDisable()
    {
        transform.localPosition = Vector3.zero;
    }

}
