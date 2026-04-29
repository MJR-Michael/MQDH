using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [Header("Optional direct reference (if assigned in Inspector)")]
    [SerializeField] private Rigidbody targetRb;

    [Header("Fallback search")]
    [SerializeField] private string targetTag = "Castle";

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // If we don't have a target yet, try to find it
        if (targetRb == null)
        {
            TryFindTarget();
            return;
        }

        MoveTowardsTarget();
    }

    private void TryFindTarget()
    {
        GameObject found = GameObject.FindGameObjectWithTag(targetTag);

        if (found != null)
        {
            targetRb = found.GetComponent<Rigidbody>();
        }
    }

    private void MoveTowardsTarget()
    {
        if (targetRb == null || rb == null) return;

        Vector3 direction = (targetRb.position - rb.position).normalized;

        Vector3 newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        // Rotate to face target
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion newRotation = Quaternion.Slerp(
                rb.rotation,
                lookRotation,
                rotationSpeed * Time.fixedDeltaTime
            );

            rb.MoveRotation(newRotation);
        }
    }

    public void SetTarget(Rigidbody newTarget)
    {
        targetRb = newTarget;
    }
}