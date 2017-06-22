using UnityEngine;
using System.Collections;

public class SketchLinesContainer : MonoBehaviour {
    public static SketchLinesContainer instance;
    void Awake() {
        instance = this;
    }

}
