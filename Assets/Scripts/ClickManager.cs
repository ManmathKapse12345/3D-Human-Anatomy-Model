using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                // GameObject clickedObject = hit.collider;
                BodyPart bodyPart = hit.collider.GetComponent<BodyPart>();
                if (bodyPart != null)
                {
                    Camera.main.GetComponent<ZoomCamera>().ZoomTo(bodyPart.gameObject);
                }
            }
        }


    }
}
