using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallexEffectMultiplier;
    private Vector3 lastCameraposition;

    private void Awake()
    {
        lastCameraposition = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = Camera.main.transform.position - lastCameraposition;
        transform.position += deltaMovement * parallexEffectMultiplier;
        lastCameraposition = Camera.main.transform.position;
    }
}
