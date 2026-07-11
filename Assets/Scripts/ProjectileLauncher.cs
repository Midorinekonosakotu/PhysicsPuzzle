using UnityEngine;


public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private ProjectileController projectile;


    [SerializeField]
    private Vector2 launchForce = new Vector2(10, 5);



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            projectile.Launch(launchForce);
        }
    }
}