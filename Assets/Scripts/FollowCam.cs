using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        cameraFollow();
    }
    void cameraFollow()
    {
        float charPosX = transform.position.x;
        float charPosZ = transform.position.z - 15f;
        float cameraOffset = -4;

        Camera.main.transform.position = new Vector3(charPosX, cameraOffset, charPosZ);

    }
}
