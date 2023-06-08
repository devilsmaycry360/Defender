using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerVCam;
    [SerializeField] private Vector3 playerVCamOffset;
    [SerializeField] private float horizontalSpeed = 2.0f;
    [SerializeField] private float verticalSpeed = 2.0f;
    [SerializeField][Range(0,1)] private float minVerticalView = 0.2f;
    [SerializeField][Range(0,1)] private float maxVerticalView = 0.8f;
    
    [SerializeField] private Animator playerAnimator;

    private Action updateAction;
    
    private static readonly int verticalMove = Animator.StringToHash("VerticalMove");
    private static readonly int horizontalMove = Animator.StringToHash("HorizontalMove");

    private void Update()
    {
        updateAction?.Invoke();
    }

    private void OnEnable()
    {
        StartCoroutine(WaitAndInitialize());
    }

    private void OnDisable()
    {
        updateAction -= MovePlayerVertically;
        updateAction -= MovePlayerHorizontally;
    }

    private void MovePlayerHorizontally()
    {
        float pointerOffsetFromCenter = InputManager.PointerViewportPosition.x - 0.5f;
        float speedBasedOnOffset = pointerOffsetFromCenter * horizontalSpeed;
        transform.Translate(transform.right * Time.deltaTime * speedBasedOnOffset);
        playerAnimator.SetFloat(horizontalMove, pointerOffsetFromCenter);
    }
    
    private void MovePlayerVertically()
    {
        Vector2 movingDirection = new Vector2(0, InputManager.PointerWorldPosition.y - transform.position.y);
        transform.Translate(movingDirection * Time.deltaTime * verticalSpeed);
        playerAnimator.SetFloat(verticalMove, movingDirection.y);
        
        KeepPlayerInVerticalViewLimits();
    }

    private void KeepPlayerInVerticalViewLimits()
    {
        float minVerticalLimit = PositionConvertor.ViewportToWorldVector2(new Vector2(0, minVerticalView)).y;
        float maxVerticalLimit = PositionConvertor.ViewportToWorldVector2(new Vector2(0, maxVerticalView)).y;
        
        transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, minVerticalLimit, maxVerticalLimit));
    }

    private void SetVCamOffset()
    {
        playerVCam.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = playerVCamOffset;
    }

    private IEnumerator WaitAndInitialize()
    {
        yield return new WaitForSeconds(0.1f);
        
        SetVCamOffset();
        updateAction += MovePlayerVertically;
        updateAction += MovePlayerHorizontally;
    }
}
