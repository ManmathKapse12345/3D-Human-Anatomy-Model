using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class ZoomCamera : MonoBehaviour
{
    // public Camera mainCamera;
    public Transform targetPosition;
    public float moveSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        if(targetPosition != null){
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition.position,
                moveSpeed*Time.deltaTime
            );

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetPosition.rotation,
                moveSpeed*Time.deltaTime
            );
        }

        // if(isMouseClicked && gameObject.name == "Female_Left_Hand"){
        //     mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(-2.090401f, 1.267887f, -1.0f), Time.deltaTime * 2);
        // }

        // if(isMouseClicked && gameObject.name == "Female_Left_Wrist"){
        //     mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(-1.751723f,1.285874f,-0.3057939f), Time.deltaTime * 2);
        // }
    }

    public void ZoomTo(Transform newTarget){
        targetPosition = newTarget;
    }

}
