using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float MaxDistance = 7f;
        
    [SerializeField]
    private float speed;
        
    private Vector3 target;
    private Vector3 startPosition;
        
    public Vector3 Target
    {
        set => target = value;
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, startPosition) > MaxDistance)
            Destroy(gameObject);
    }
}