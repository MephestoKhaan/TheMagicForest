using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    void Update()
    {
        if (Camera.main != null)
        {
            Vector3 clampedDirection = Vector3.ProjectOnPlane(Camera.main.transform.position - this.transform.position, Vector3.up).normalized;
            this.transform.rotation = Quaternion.LookRotation(clampedDirection, Vector3.up);
        }
    }
}
