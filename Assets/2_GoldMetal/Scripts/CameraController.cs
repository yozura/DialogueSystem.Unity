using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 distance;

    public void SetPlayer(GameObject player)
    {
        target = player;
        distance = new Vector3(0, 0, -10);
    }

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.transform.position + distance;
    }
}
