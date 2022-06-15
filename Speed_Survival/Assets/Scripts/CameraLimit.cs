using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(transform.localRotation.x);

        if (transform.localRotation.x > 0.576f)
            transform.localRotation = Quaternion.Euler(70.0f, transform.rotation.y, transform.rotation.z);

        if (transform.localRotation.x < -0.576f)
            transform.localRotation = Quaternion.Euler(-70.0f, transform.rotation.y, transform.rotation.z);
    }
}
