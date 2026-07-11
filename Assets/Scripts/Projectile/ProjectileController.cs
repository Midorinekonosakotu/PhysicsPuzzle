using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Launch(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}