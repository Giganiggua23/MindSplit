using UnityEngine;

public class DragItem : MonoBehaviour
{
    [SerializeField] private float pickUpRadius = 0.5f;       // Радиус подьёма 
    [SerializeField] private LayerMask playerLayer = 1;       // Слой 
    [SerializeField] private Transform holdPoint;             // Точка установки 
    [SerializeField] private float pickUpSmoothTime = 0.2f;   // Время подтяжки

    private bool isDragged = false;
    private Transform playerTransform;
    private Rigidbody rb;
    private Vector3 dragVelocity = Vector3.zero;

    // Таймер
    private bool isTimerActive = false;
    private float timer = 0f;
    private const float RELEASE_DELAY = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckForPickUpInput();

        if (isDragged)
        {
            UpdateDragPosition();

            if (Input.GetMouseButtonUp(0))
            {
                ReleaseItem();
            }
        }

        // Обновление таймера
        if (isTimerActive)
        {
            timer += Time.deltaTime;
            if (timer >= RELEASE_DELAY)
            {
                DisablePhysics();
            }
        }
    }

    void CheckForPickUpInput()
    {
        if (Input.GetMouseButtonDown(0) && !isDragged)
        {
            TryPickUpItem();
        }
    }

    void TryPickUpItem()
    {
        Collider[] playersInRange = Physics.OverlapSphere(transform.position, pickUpRadius, playerLayer);

        if (playersInRange.Length > 0)
        {
            playerTransform = playersInRange[0].transform;

            HoldPoint holder = playerTransform.GetComponentInChildren<HoldPoint>();
            if (holder != null && holder.holdPoint != null)
            {
                holdPoint = holder.holdPoint;
                StartDragging();
            }
        }
    }

    void StartDragging()
    {
        isDragged = true;

        // Отменяем таймер если он активен
        if (isTimerActive)
        {
            CancelTimer();
        }

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        OnPickUp();
    }

    void UpdateDragPosition()
    {
        if (holdPoint == null) return;

        if (Vector3.Distance(transform.position, holdPoint.position) > 0.1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, holdPoint.position,
                ref dragVelocity, pickUpSmoothTime);
        }
        else
        {

            transform.position = holdPoint.position;
            dragVelocity = Vector3.zero;
        }
        transform.rotation = holdPoint.rotation;
    }

    void ReleaseItem()
    {
        isDragged = false;

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;


            rb.linearVelocity = dragVelocity;
        }

        playerTransform = null;
        holdPoint = null;


        OnRelease();
    }

    void OnPickUp()
    {
        // Отменяем таймер при поднятии предмета
        CancelTimer();
    }

    void OnRelease()
    {
        // Запускаем таймер при отпускании предмета
        StartTimer();
    }

    void StartTimer()
    {
        isTimerActive = true;
        timer = 0f;
    }

    void CancelTimer()
    {
        isTimerActive = false;
        timer = 0f;
    }

    void DisablePhysics()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        // Останавливаем таймер
        CancelTimer();
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }
}