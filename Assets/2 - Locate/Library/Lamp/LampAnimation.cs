using UnityEngine;

public class LampAnimation : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    [Header("Animation Settings")]
    public float hangDuration = 2f;
    public float jerkSpeedMultiplier = 3f;

    [Header("Current State")]
    public bool isMovingUp = false;
    public bool isMoving = false;
    [Range(0f, 1f)] public float progress = 0f;

    [Header("Object Switching")]
    public GameObject objectA;
    public GameObject objectB;

    [Header("SFX")]
    public AudioSource sfxSource;
    public AudioClip jerkSound;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isHanging = false;
    private float hangTimer = 0f;
    private bool jerkCompleted = false;

    public bool OnActive;
    public bool InsAnimBranch;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.down * moveDistance;
        OnActive = false;

        // Инициализация объектов (объект А включен, объект Б выключен)
        if (objectA != null) objectA.SetActive(true);
        if (objectB != null) objectB.SetActive(false);
    }

    void Update()
    {
        if (OnActive)
        {
            HandleInput();
            PerformMovement();
            LampAnim();
        }
    }

    private void LampAnim()
    {
        if (InsAnimBranch && progress >= 0.5f && !isHanging && !jerkCompleted)
        {
            StartHanging();
        }

        if (isHanging)
        {
            hangTimer += Time.deltaTime;
            if (hangTimer >= hangDuration)
            {
                EndHanging();
            }
        }
    }

    private void StartHanging()
    {
        isHanging = true;
        isMoving = false;
        hangTimer = 0f;
        Debug.Log("Объект завис в середине движения");
    }

    private void EndHanging()
    {
        isHanging = false;
        jerkCompleted = true;

        // Проигрываем SFX эффект
        if (sfxSource != null && jerkSound != null)
        {
            sfxSource.PlayOneShot(jerkSound);
        }

        // Переключаем объекты
        SwitchObjects();

        // Продолжаем движение с увеличенной скоростью
        isMoving = true;
        moveSpeed *= jerkSpeedMultiplier;

        Debug.Log("Рывок! Объекты переключены");
    }

    private void SwitchObjects()
    {
        // Выключаем объект А, включаем объект Б
        if (objectA != null) objectA.SetActive(false);
        if (objectB != null) objectB.SetActive(true);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetDirection(true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetDirection(false);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isMoving = false;
        }
    }

    private void PerformMovement()
    {
        if (!isMoving || isHanging) return;

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

    public void SetDirection(bool moveUp)
    {
        isMoving = true;
        isMovingUp = moveUp;

        // Сбрасываем состояния анимации при начале нового движения
        if (moveUp)
        {
            isHanging = false;
            jerkCompleted = false;
            // Восстанавливаем нормальную скорость
            moveSpeed = moveSpeed / jerkSpeedMultiplier;
        }
    }

    private void CheckForCompletion()
    {
        if (isMovingUp && progress <= 0f)
        {
            isMoving = false;
            progress = 0f;
            transform.position = startPosition;

            // Сбрасываем состояния анимации при возврате в начальное положение
            isHanging = false;
            jerkCompleted = false;
            // Восстанавливаем нормальную скорость
            moveSpeed = moveSpeed / jerkSpeedMultiplier;

            // Возвращаем объекты в исходное состояние
            if (objectA != null) objectA.SetActive(true);
            if (objectB != null) objectB.SetActive(false);
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
    public bool IsHanging() => isHanging;

    public void SetMoveDistance(float newDistance)
    {
        moveDistance = newDistance;
        targetPosition = startPosition + Vector3.down * moveDistance;
    }

    public void SetMoveSpeed(float newSpeed) => moveSpeed = Mathf.Max(0, newSpeed);

    // Методы для настройки анимации
    public void SetHangDuration(float duration) => hangDuration = Mathf.Max(0, duration);
    public void SetJerkSpeedMultiplier(float multiplier) => jerkSpeedMultiplier = Mathf.Max(1, multiplier);
}