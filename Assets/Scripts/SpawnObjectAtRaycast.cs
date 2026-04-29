using UnityEngine;
using Meta.XR;

public class SpawnObjectAtRaycast : MonoBehaviour
{
    [Header("Input Settings")]
    [SerializeField] private OVRInput.Controller controller = OVRInput.Controller.LTouch;
    [SerializeField] private OVRInput.Button button = OVRInput.Button.Two;

    [Header("Ray Settings")]
    public Transform rayStartPoint;
    public float rayLength = 5f;

    [Header("Spawn Settings")]
    public float yOffset = 0.05f;

    public EnvironmentRaycastManager envRayManager;
    public GameObject hitObjectPrefab;

    void Update()
    {
        if (OVRInput.GetDown(button, controller))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

        bool hasHit = envRayManager.Raycast(ray, out var hit, rayLength);

        if (hasHit)
        {
            GameObject spawnedObject = Instantiate(hitObjectPrefab);

            Vector3 hitPoint = hit.point;
            Vector3 hitNormal = hit.normal;

            // Apply Y offset only (world space)
            Vector3 offset = Vector3.up * yOffset;

            spawnedObject.transform.position = hitPoint + offset;

            spawnedObject.transform.rotation =
                Quaternion.FromToRotation(Vector3.up, hitNormal);
        }
    }
}