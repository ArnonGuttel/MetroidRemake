using UnityEngine;

public class Enemy2Radius : MonoBehaviour
{
    public Enemy2Script script;
    private float _circleRaduis;
    private CircleCollider2D _circleCollider2D;

    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleRaduis = _circleCollider2D.radius;
    }

    private void OnEnable()
    {
        _circleCollider2D.enabled = true;
        _circleCollider2D.radius = _circleRaduis;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            script.playerPosition = other.gameObject.transform.position;
            script.attackPlayer = true;
            gameObject.GetComponentInParent<Animator>().SetTrigger("EnemyActivate");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
        {
            if (script.attackPlayer)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    script.playerPosition = other.gameObject.transform.position;
                    _circleCollider2D.radius -= 0.1f * Time.deltaTime;
                }
            }
        }
}
