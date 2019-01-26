using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    GameState gameState;
    Rigidbody rb;
    Camera myCamera;


    void Start()
    {
        gameState = GameState.instance;

        rb = GetComponent<Rigidbody>();
        myCamera = Camera.main;
    }

    void FixedUpdate()
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

        float angle = Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(0, angle, 0);
    }
}
