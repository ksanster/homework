using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EyeBatMove : MonoBehaviour
{
    public const string Player = "player";
    private NavMeshAgent agent;
    private Camera mainCamera;
    
    [SerializeField]
    private GameObject bombPrefab;
    
    public bool HasBomb {get; set; }
        
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, 100))
                agent.destination = hit.point;                
        }   
        if (HasBomb && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }
}
