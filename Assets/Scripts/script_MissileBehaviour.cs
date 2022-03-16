using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class script_MissileBehaviour : MonoBehaviour
{
    [SerializeField] private float thrustPower = 1;
    [SerializeField] private float timeBeforeExplode = 5;

    private Vector2 target;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Destroy(gameObject, timeBeforeExplode);

        rb.velocity = transform.up * thrustPower;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Meteor"))
        {
            col.gameObject.GetComponent<script_MeteorSplitting>().Split();
            Destroy(gameObject);
        }
    }
}
