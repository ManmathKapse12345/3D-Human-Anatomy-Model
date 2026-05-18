using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public Transform zoomPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Camera.main.GetComponent<ZoomCamera>().ZoomTo(zoomPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
