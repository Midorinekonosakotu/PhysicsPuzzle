using UnityEngine;


public class TargetController : MonoBehaviour
{
    [SerializeField]
    private float hp = 10f;


    [SerializeField]
    private float destroyPower = 5f;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactPower =
            collision.relativeVelocity.magnitude;


        Damage(impactPower);
    }



    private void Damage(float amount)
    {
        hp -= amount;


        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}