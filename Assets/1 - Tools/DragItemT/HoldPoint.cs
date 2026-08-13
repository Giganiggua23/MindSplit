using UnityEngine;

public class HoldPoint : MonoBehaviour
{
    [Header("Точка удержания предметов")]
    public Transform holdPoint;

    void Start()
    {
        // Автоматически создаем точку удержания если не назначена
        if (holdPoint == null)
        {
            CreateDefaultHoldPoint();

            
        }
        RayCastManagerStart();
    }

    void CreateDefaultHoldPoint()
    {
        GameObject holdPointObj = new GameObject("HoldPoint");
        holdPointObj.transform.SetParent(transform);
        holdPointObj.transform.localPosition = new Vector3(0f, 1f, 0.5f); // Перед персонажем
        holdPoint = holdPointObj.transform;
    }

    //==============================
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private LayerMask ignoredLayers;
    [SerializeField] private float speed = 5f;

    private float sphereRadius;

    private void RayCastManagerStart()
    {
        sphereRadius = GetComponent<SphereCollider>().radius;
    }

    private void Update()
    {
        Vector3 direction = (endPoint.position - startPoint.position).normalized;
        float distance = Vector3.Distance(startPoint.position, endPoint.position);

        int finalMask = collisionLayers & ~ignoredLayers;

        RaycastHit hit;

        Vector3 targetPosition;

        if (Physics.SphereCast(startPoint.position, sphereRadius, direction, out hit, distance, finalMask))
        {
            targetPosition = hit.point - hit.normal * sphereRadius;
        }
        else
        {
            targetPosition = endPoint.position;
        }

        // плавное движение
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (startPoint == null || endPoint == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startPoint.position, endPoint.position);

        if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, sphereRadius);
        }
    }
}