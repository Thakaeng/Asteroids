using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class script_ScreenWrap : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Arena"))
        {
            Vector2 newPosition = transform.position;
            var otherBounds = other.bounds;
            if (transform.position.x < otherBounds.min.x || transform.position.x > otherBounds.max.x)
                newPosition.x = -transform.position.x;
            if (transform.position.y < otherBounds.min.y || transform.position.y > otherBounds.max.y)
                newPosition.y = -transform.position.y;
            transform.position = newPosition;
        }
    }
}
