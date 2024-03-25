using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject targetObject;
    // Update is called once per frame
    void Update()
    {
                if (targetObject != null)
        {
            // Get the position of the target object
            Vector3 targetPosition = targetObject.transform.position;

            // Offset the camera's position by (0, 5, 0) relative to the target object's position
            Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y + 1, targetPosition.z - 5);

            // Update the camera's position
            transform.position = newPosition;
        }
    }
}
