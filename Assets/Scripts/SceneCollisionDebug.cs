using UnityEngine;
using Meta.XR;

public class SceneCollisionDebug : MonoBehaviour
{
    public OVRInput.Button button = OVRInput.Button.One;

    public Transform rayStartPoint;
    public float rayLenth = 5;
    public EnvironmentRaycastManager envRayManager;
    public TMPro.TextMeshPro debugTextPrefab;

    void Update()
    {
        if (OVRInput.GetDown(button))
        {
            Debug.Log("Button pressed!");
        }

        if(OVRInput.GetDown(button))
        {
            Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

            bool hasHit = envRayManager.Raycast(ray, out var hit, rayLenth);

            if(hasHit)
            {
                TMPro.TextMeshPro debugText = Instantiate(debugTextPrefab);

                Vector3 hitpoint = hit.point;
                Vector3 hitNormal = hit.normal;

                debugText.transform.position = hitpoint;
                debugText.transform.rotation = Quaternion.LookRotation(-hitNormal);

                debugText.text = "HIT";
            }
        }
    }
}
