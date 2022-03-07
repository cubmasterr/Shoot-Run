using UnityEngine;
using Cinemachine;

[RequireComponent (typeof (CinemachineVirtualCamera))]
public class CameraFollowController : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    private Transform _characterTransform;

    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        GameStateManager.Instance.OnCharacterCreated += FollowCharacter;
        GameStateManager.Instance.OnCharacterStoped += StopFollow;
    }

    private void StopFollow()
    {
        _camera.Follow = null;
    }

    private void FollowCharacter(Transform characterTransform)
    {
        _characterTransform = characterTransform;
        SetCameraValues(characterTransform);
    }

    private void SetCameraValues(Transform characterTransform)
    {
        _camera.LookAt = characterTransform;
        _camera.Follow = characterTransform;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnCharacterCreated -= FollowCharacter;
        GameStateManager.Instance.OnCharacterStoped -= StopFollow;
    }
}