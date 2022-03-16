using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class script_ShipMovement : MonoBehaviour
{
    [SerializeField] private GameObject missile;
    
    [SerializeField] private float thrusterPower;
    [SerializeField] private float rotationSpeed;


    private Rigidbody2D rb;


    private void Awake()
    {
        Debug.Log("Ship Awake");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) FireMissile();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        rb.AddForce(transform.up * Input.GetAxis("Vertical") * thrusterPower * Time.deltaTime);
    }

    private void FireMissile()
    {
        Instantiate(missile, transform.position, transform.rotation);
    }
}
