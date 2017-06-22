using UnityEngine;
using System.Collections;

public class SketchLineParticle : MonoBehaviour {
    public GameObject sketchLine;
    Vector3 currentLinePosition;
    Vector3 savedLinePosition;
    float dist=0.8f;
    Transform lastDroppedLine;
	// Use this for initialization
	void Start () {
        lastDroppedLine = this.transform;
        StartCoroutine(dropLinesRoutine());
	}


    IEnumerator dropLinesRoutine() {

        savedLinePosition = transform.position;

        while (true) {

            currentLinePosition = transform.position;
            if (Vector3.Distance(currentLinePosition, savedLinePosition) > dist)
            {
                GameObject sketch = (GameObject)Instantiate(sketchLine, sketchLine.transform.position, Quaternion.identity);
                savedLinePosition = currentLinePosition;
                sketch.transform.LookAt(lastDroppedLine);
                lastDroppedLine = sketch.transform;
            }

            yield return new WaitForEndOfFrame();
        }


    }


}
