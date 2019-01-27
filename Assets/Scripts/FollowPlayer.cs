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

        var player = GameObject.FindWithTag("Player");
        if (player) {
            target = player.GetComponent<Transform>();
        }
    }

    void LateUpdate()
    {
        if (target != null) {
            Vector3 goalPos = target.position + target.forward;
            goalPos.y = myTransform.position.y;

            myTransform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, dampen);
        }
    }
}