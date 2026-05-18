using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZoomCamera : MonoBehaviour
{
    public Camera mainCamera;
    public bool isMouseClicked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMouseClicked = false;
    }


    void OnMouseDown(){
        isMouseClicked = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(isMouseClicked && gameObject.name == "Female_Left_Hand"){
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(-2.090401f, 1.267887f, -1.0f), Time.deltaTime * 2);
        }

        if(isMouseClicked && gameObject.name == "Female_Left_Wrist"){
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(-1.751723f,1.285874f,-0.3057939f), Time.deltaTime * 2);
        }
    }

}
