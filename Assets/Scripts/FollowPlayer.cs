using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    float dampen = 0.3f;

    Transform myTransform;
    Transform target;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Vector3 goalPos = target.position;
        goalPos.y = myTransform.position.y;

        myTransform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, dampen);
    }
}
