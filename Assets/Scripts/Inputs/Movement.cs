using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rb;
    Camera myCamera;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myCamera = Camera.main;
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        RotateTowards(rb.position, mousePos);

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        // Probably fine on keyboards, could be weird with controllers
        var movement = new Vector3(horizontal, 0, vertical);
        movement = movement.normalized * speed;

        var position = rb.position;
        position.x += horizontal * speed * Time.deltaTime;
        position.z += vertical * speed * Time.deltaTime;

        rb.MovePosition(position);
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
