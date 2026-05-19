using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoomCamera : MonoBehaviour
{
    // public Camera mainCamera;
    public GameObject targetObject;
    public float moveSpeed = 5.0f;

    public RectTransform labelRectTransform;
    public RectTransform arrowRect;

    public Vector3 offset;
    public Vector2 offset1;


    void Start()
    {
        if (labelRectTransform != null)
        {
            labelRectTransform.gameObject.SetActive(false);
        }
        if (arrowRect != null)
        {
            arrowRect.gameObject.SetActive(false);
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
                    if (targetObject.name == "Right Hand" || targetObject.name == "Eyes" || targetObject.name == "Right Breast" || targetObject.name == "Right Thigh" || targetObject.name == "Right Knee" || targetObject.name == "Right Shin" || targetObject.name == "Right Toe" || targetObject.name == "Right Bridge" || targetObject.name == "Abdomen" || targetObject.name == "Umbilical" || targetObject.name == "Lips" || targetObject.name == "Nose" || targetObject.name == "Chest" || targetObject.name == "Neck")
                    {
                        offset = Vector3.left * 0.75f;
                    }
                    if (targetObject.name == "Left Hand" || targetObject.name == "Left Breast" || targetObject.name == "Left Thigh" || targetObject.name == "Left Knee" || targetObject.name == "Left Shin" || targetObject.name == "Left Toe" || targetObject.name == "Left Bridge")
                    {
                        offset = Vector3.right * 0.75f;
                    }
                    if (targetObject.name == "Right Forearm" || targetObject.name == "Right Arm" || targetObject.name == "Right Elbow" || targetObject.name == "Hair" || targetObject.name == "Left Forearm" || targetObject.name == "Left Arm" || targetObject.name == "Left Elbow")
                    {
                        offset = Vector3.up * 0.5f;
                    }
                    if (targetObject.name == "Right Wrist" || targetObject.name == "Right Shoulders")
                    {
                        offset = Vector3.left * 0.5f + Vector3.up * 0.5f;
                    }
                    if (targetObject.name == "Left Wrist" || targetObject.name == "Left Shoulders")
                    {
                        offset = Vector3.right * 0.5f + Vector3.up * 0.5f;
                    }
                    // Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Camera.main.transform.right * 2.0f;
                    Vector3 worldPoint1 = targetObject.GetComponent<Collider>().bounds.center + offset;
                    Vector3 worldPoint2 = targetObject.GetComponent<Collider>().bounds.center;
                    Vector3 screenPoint1 = Camera.main.WorldToScreenPoint(worldPoint1);
                    Vector3 screenPoint2 = Camera.main.WorldToScreenPoint(worldPoint2);
                    RectTransform canvasRect = canvas.GetComponent<RectTransform>();
                    Vector2 localPoint1;
                    Vector2 localPoint2;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint1, canvas.worldCamera, out localPoint1);
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint2, canvas.worldCamera, out localPoint2);
                    labelRectTransform.anchoredPosition = localPoint1;
                    
                    float distance = Vector3.Distance(transform.position, targetPosition);

                    if (distance < 0.05f)
                    {
                        UpdateArrow(localPoint2);
                    }
                    else{
                        arrowRect.gameObject.SetActive(false);
                    }
                    // UpdateArrow(localPoint2);
                }
                else
                {
                    // Fallback: place using world to screen (may be off for some Canvas modes)
                    // Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Camera.main.transform.right * 2.0f;
                    Vector3 worldPoint = targetObject.GetComponent<Collider>().bounds.center + Vector3.up * 5.0f;

                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);
                    labelRectTransform.position = screenPoint;
                }
            }
        }
    }

    public void ZoomTo(GameObject newTargetObject)
    {
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
    }

    public void UpdateArrow(Vector2 targetPos)
    {
        offset1 = Vector2.zero;
        if (targetObject.name == "Right Hand" || targetObject.name == "Eyes" || targetObject.name == "Right Breast" || targetObject.name == "Right Thigh" || targetObject.name == "Right Knee" || targetObject.name == "Right Shin" || targetObject.name == "Right Toe" || targetObject.name == "Right Bridge" || targetObject.name == "Abdomen" || targetObject.name == "Umbilical" || targetObject.name == "Lips" || targetObject.name == "Nose" || targetObject.name == "Chest" || targetObject.name == "Neck")
        {
            offset1 = Vector2.right * 150f;
        }
        if (targetObject.name == "Left Hand" || targetObject.name == "Left Breast" || targetObject.name == "Left Thigh" || targetObject.name == "Left Knee" || targetObject.name == "Left Shin" || targetObject.name == "Left Toe" || targetObject.name == "Left Bridge")
        {
            offset1 = Vector2.left * 150f;
        }
        if (targetObject.name == "Right Forearm" || targetObject.name == "Right Arm" || targetObject.name == "Right Elbow" || targetObject.name == "Hair" || targetObject.name == "Left Forearm" || targetObject.name == "Left Arm" || targetObject.name == "Left Elbow")
        {
            offset1 = Vector2.down * 100f;
        }
        if (targetObject.name == "Right Wrist" || targetObject.name == "Right Shoulders")
        {
            offset1 = Vector2.right * 100f + Vector2.down * 100f;
        }
        if (targetObject.name == "Left Wrist" || targetObject.name == "Left Shoulders")
        {
            offset1 = Vector2.left * 100f + Vector2.down * 100f;
        }
        arrowRect.anchoredPosition = labelRectTransform.anchoredPosition + offset1;
        Vector2 direction = targetPos - arrowRect.anchoredPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowRect.rotation = Quaternion.Euler(0, 0, angle + 90f);
        if (!arrowRect.gameObject.activeSelf)
        {
            arrowRect.gameObject.SetActive(true);
        }

    }

}
