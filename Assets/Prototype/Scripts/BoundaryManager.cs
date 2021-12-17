
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    private BoxCollider2D managerBox;
    public Transform Player;
    public GameObject boundary;

    public bool XMaxEnabled;
    public float XMaxValue;

    public bool XMinEnabled;
    public float XMinValue;
    
    public bool YMaxEnabled;
    public float YMaxValue;

    public bool YMinEnabled;
    public float YMinValue;
    
    private void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ManageBoundary();
    }

    private void ManageBoundary()
    {
        if (managerBox.bounds.min.x < Player.position.x && Player.position.x < managerBox.bounds.max.x &&
            managerBox.bounds.min.y < Player.position.y && Player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);
        }
        else
        {
            boundary.SetActive(false);
        }
    }
}
