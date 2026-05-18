
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    // public Camera mainCamera;
    public GameObject targetObject;
    public float moveSpeed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        if(targetObject != null){
            Vector3 targetPosition = targetObject.GetComponent<Collider>().bounds.center + Vector3.forward*-1.0f; 
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                moveSpeed*Time.deltaTime
            );
        }
    }

    public void ZoomTo(GameObject newTargetObject){
        targetObject = newTargetObject;
    }

}
