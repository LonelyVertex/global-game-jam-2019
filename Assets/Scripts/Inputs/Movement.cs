using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 1.4f;

    GameState gameState;
    Rigidbody rb;
    Camera myCamera;
    Transform stairsTarget;

    void Start()
    {
        gameState = GameState.instance;

        rb = GetComponent<Rigidbody>();
        myCamera = Camera.main;
    }

    void FixedUpdate()
    {
        if (stairsTarget) {
            HandleMoveUpstairs();
        } else {
            HandleMovement();
        }
    }

    void HandleMoveUpstairs()
    {
        var angle = Quaternion.LookRotation(stairsTarget.position - rb.position).eulerAngles.y;
        rb.rotation = Quaternion.Euler(0, angle, 0);
        rb.velocity = (stairsTarget.position - rb.position).normalized * speed;
    }

    void HandleMovement()
    {
        if (!gameState.IsPlaying) return;

        var mousePos = Input.mousePosition;
        RotateTowards(rb.position, mousePos);

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        // Probably fine on keyboards, could be weird with controllers
        var movement = new Vector3(horizontal, 0, vertical).normalized * speed;

        rb.velocity = movement;
    }

    void RotateTowards(Vector3 what, Vector2 position)
    {
        var objectPos = myCamera.WorldToScreenPoint(what);
        position.x = position.x - objectPos.x;
        position.y = position.y - objectPos.y;

        var angle = Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(0, angle, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stairs")) {
            var stairs = other.gameObject.GetComponent<StairsTrigger>();
            stairs.DisableStairsCollider();
            stairsTarget = stairs.target;

            gameState.NextScene();
        }
    }
}