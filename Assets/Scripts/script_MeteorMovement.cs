using UnityEngine;

public class script_MeteorMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float directionVariance = 0.3f;

    private Vector2 moveDirection;

    private void Awake()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void Setup(Vector2 newMoveDir)
    {
        moveDirection = newMoveDir + new Vector2(Random.Range(-directionVariance, directionVariance), Random.Range(-directionVariance, directionVariance));
    }
}
