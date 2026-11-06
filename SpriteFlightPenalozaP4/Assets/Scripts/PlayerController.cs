using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public UIDocument uiDocument;
    private float score = 0f;
    public float scoreMultiplier = 10f;
    private float elapsedTime = 0f;
    public float maxSpeed = 5f;
    public float thrustForce = 1f;
    Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        Debug.Log("Score: " + score);

        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            Vector2 direction = (mousePos - transform.position).normalized;

            transform.up = direction;

            rb.AddForce(direction * thrustForce);
          
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }
}
