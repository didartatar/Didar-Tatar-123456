using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 2f, -6f);

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + target.TransformDirection(offset);
            transform.LookAt(target);
        }
    }
}