using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoomCamera : MonoBehaviour
{
    // public Camera mainCamera;
    public GameObject targetObject;
    public float moveSpeed = 5.0f;

    public RectTransform labelRectTransform;


    void Start()
    {
        if (labelRectTransform != null)
        {
            labelRectTransform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            Vector3 targetPosition = targetObject.GetComponent<Collider>().bounds.center + Vector3.forward * -2.0f;
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            // Update label position each frame so it follows the target
            
            if (labelRectTransform != null && labelRectTransform.gameObject.activeSelf)
            {
                Canvas canvas = labelRectTransform.GetComponentInParent<Canvas>();
                if (canvas != null)
                {
                    // Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Camera.main.transform.right * 2.0f;
                    Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Vector3.up*0.5f + Vector3.left*0.5f;
                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);
                    RectTransform canvasRect = canvas.GetComponent<RectTransform>();
                    Vector2 localPoint;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, canvas.worldCamera, out localPoint);
                    labelRectTransform.anchoredPosition = localPoint;
                }
                else
                {
                    // Fallback: place using world to screen (may be off for some Canvas modes)
                    // Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Camera.main.transform.right * 2.0f;
                    Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Vector3.up*5.0f;

                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);
                    labelRectTransform.position = screenPoint;
                }
            }
        }
    }

    public void ZoomTo(GameObject newTargetObject){
        targetObject = newTargetObject;
    }

    public void PutLabel(RectTransform label)
    {
        if (label == null || targetObject == null)
        {
            Debug.LogError("Label or Target Object is null");
            return;
        }

        labelRectTransform = label;

        // Include inactive children in case label was disabled
        TMP_Text childText = labelRectTransform.GetComponentInChildren<TMP_Text>(true);
        if (childText == null)
        {
            Debug.LogError("No TMP_Text component found inside label");
            return;
        }

        childText.text = targetObject.name;
        labelRectTransform.gameObject.SetActive(true);

        // Convert world position to canvas local position so UI lines up correctly
        
        // Canvas canvas = labelRectTransform.GetComponentInParent<Canvas>();
        // Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Camera.main.transform.right * 2.0f;
        // Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);

        // if (canvas != null)
        // {
        //     RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        //     Vector2 localPoint;
        //     RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, canvas.worldCamera, out localPoint);
        //     labelRectTransform.anchoredPosition = localPoint;
        // }
        // else
        // {
        //     // Fallback: set world-to-screen position (may be off depending on canvas mode)
        //     labelRectTransform.position = screenPoint;
        // }
    }

}
