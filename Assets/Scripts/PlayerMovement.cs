using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction move;
    private Rigidbody rb;
    [SerializeField] private float rotationSpeed = 30, moveSpeed = 4;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Vector3 pushbackForce;
    [SerializeField] private bool disabled = false;
    [SerializeField] private float disableTime = 2f;
    private float lastDisableTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        ExplodingObstacle.OnPlayerHit += TakeDamage;
    }

    void TakeDamage()
    {
        disabled = true;
        lastDisableTime = Time.timeSinceLevelLoad;
        rb.AddForce(pushbackForce);
        Debug.Log("I got hit");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        {
            isGrounded = Physics.Linecast(transform.position, transform.position - transform.up,groundLayers);
            if (Time.timeSinceLevelLoad > lastDisableTime) 
                disabled = false;
            Debug.DrawLine(transform.position, transform.position - transform.up);
            if (isGrounded && !disabled)
            {
                Vector2 moveVector = move.ReadValue<Vector2>();
                float slopeAngle = Mathf.Abs(transform.localEulerAngles.y - 180);
                float speedMult = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
                rb.AddForce(transform.forward * moveSpeed * speedMult * Time.fixedDeltaTime);
                transform.Rotate(0, moveVector.x * rotationSpeed * Time.fixedDeltaTime, 0);


            }
        }
    }
}
