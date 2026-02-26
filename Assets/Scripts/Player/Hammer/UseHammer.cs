using UnityEngine;

public class UseHammer : MonoBehaviour
{
    [SerializeField] private Transform raycastSource; 
    [SerializeField] private float rayDistance = 100f;
    [SerializeField] private LayerMask hitLayers = -1; 
    [SerializeField] private Vector3 rayOffset = Vector3.zero; // Смещение луча относительно источника

    private void Start()
    {
        if (raycastSource == null)
        {
            Debug.LogError("Источник луча (raycastSource) не назначен в инспекторе!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireRaycast();
        }
    }

    public void FireRaycast()
    {
        if (raycastSource == null) return;

        Vector3 rayOrigin = raycastSource.position + raycastSource.TransformDirection(rayOffset);
        Ray ray = new Ray(rayOrigin, raycastSource.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, rayDistance, hitLayers))
        {
            EscapeActive escape = hit.collider.GetComponent<EscapeActive>();

            if (escape != null)
            {
                escape.IsBroken();
            }
        }
    }
}

