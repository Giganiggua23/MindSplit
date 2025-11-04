using UnityEngine;

public class LampAnimation : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    [Header("Current State")]
    public bool isMovingUp = false;
    public bool isMoving = false;
    [Range(0f, 1f)] public float progress = 0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.down * moveDistance;
    }

    void Update()
    {
        HandleInput();
        PerformMovement();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleDirection();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetDirection(true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetDirection(false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveUpContinuous();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveDownContinuous();
        }
    }

    private void PerformMovement()
    {
        if (!isMoving) return;

        float progressChange = moveSpeed * Time.deltaTime;

        if (isMovingUp)
        {
            progress -= progressChange;
        }
        else
        {
            progress += progressChange;
        }

        progress = Mathf.Clamp01(progress);
        transform.position = Vector3.Lerp(startPosition, targetPosition, progress);

        CheckForCompletion();
    }

    public void ToggleDirection()
    {
        isMoving = true;
        isMovingUp = !isMovingUp;
    }

    public void SetDirection(bool moveUp)
    {
        isMoving = true;
        isMovingUp = moveUp;
    }

    private void MoveUpContinuous()
    {
        isMoving = true;
        isMovingUp = true;
    }

    private void MoveDownContinuous()
    {
        isMoving = true;
        isMovingUp = false;
    }

    private void CheckForCompletion()
    {
        if (isMovingUp && progress <= 0f)
        {
            isMoving = false;
            progress = 0f;
            transform.position = startPosition;
        }
        else if (!isMovingUp && progress >= 1f)
        {
            isMoving = false;
            progress = 1f;
            transform.position = targetPosition;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startPosition, targetPosition);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPosition, 0.3f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetPosition, 0.3f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }

    // Public methods
    public void StartMovingUp() => SetDirection(true);
    public void StartMovingDown() => SetDirection(false);

    public void StopMovement() => isMoving = false;

    public void SetProgress(float newProgress)
    {
        progress = Mathf.Clamp01(newProgress);
        transform.position = Vector3.Lerp(startPosition, targetPosition, progress);
    }

    public float GetProgress() => progress;
    public bool IsMoving() => isMoving;
    public bool IsMovingUpward() => isMovingUp;

    public void SetMoveDistance(float newDistance)
    {
        moveDistance = newDistance;
        targetPosition = startPosition + Vector3.down * moveDistance;
    }

    public void SetMoveSpeed(float newSpeed) => moveSpeed = Mathf.Max(0, newSpeed);
}
