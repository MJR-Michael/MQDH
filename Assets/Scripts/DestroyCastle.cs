using UnityEngine;

public class DestroyCastle : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private string targetTag = "Castle";

    [Header("Growth")]
    [SerializeField] private float growthMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject other)
    {
        if (!other.CompareTag(targetTag))
            return;

        Destroy(other);

        // grow the enemy after the kill
        transform.localScale *= growthMultiplier;
    }
}