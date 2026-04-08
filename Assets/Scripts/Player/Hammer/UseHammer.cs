using UnityEngine;
using System.Collections;

public class UseHammer : MonoBehaviour
{
    [SerializeField] private Transform raycastSource; 
    [SerializeField] private float rayDistance = 100f;
    [SerializeField] private LayerMask hitLayers = -1; 
    [SerializeField] private Vector3 rayOffset = Vector3.zero; // —мещение луча относительно источника

    [SerializeField] private bool IsAttack;
    private Animator animator;

    [SerializeField] private GameObject _onePart;
    [SerializeField] private GameObject _theePart;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (raycastSource == null)
        {
            Debug.LogError("»сточник луча (raycastSource) не назначен в инспекторе!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsAttack)
        {
            animator.SetTrigger("AttackTrig");
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

/*
 * ѕри анимации указывать метод FireRaycast() дл€ активации удара
 */

