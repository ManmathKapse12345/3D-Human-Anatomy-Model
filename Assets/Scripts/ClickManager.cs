using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickManager : MonoBehaviour
{
    // public TMP_Text partText;
    public RectTransform panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.gameObject.SetActive(false);

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
                // Debug.Log(hit.collider.gameObject.name);
                // GameObject clickedObject = hit.collider;
                BodyPart bodyPart = hit.collider.GetComponent<BodyPart>();
                if (bodyPart != null)
                {
                    Camera.main.GetComponent<ZoomCamera>().ZoomTo(bodyPart.gameObject);
                    Camera.main.GetComponent<ZoomCamera>().PutLabel(panel);
                    // panel.gameObject.SetActive(true);   
                    // partText.text = bodyPart.gameObject.name;
                }
            }
        }


    }
}
