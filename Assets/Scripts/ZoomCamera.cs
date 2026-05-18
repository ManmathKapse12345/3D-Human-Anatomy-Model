
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    // public Camera mainCamera;
    public GameObject targetObject;
    public float moveSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        if(targetObject != null){
            // Vector3 targetPos = targetObject.transform.position + new Vector3(0.0f,0.0f,-1f);
            transform.position = Vector3.Lerp(
                transform.position,
                targetObject.transform.position + new Vector3(0.0f,0.0f,-1f),
                moveSpeed*Time.deltaTime
            );
        }
    }

    public void ZoomTo(GameObject newTargetObject){
        targetObject = newTargetObject;
    }

}
