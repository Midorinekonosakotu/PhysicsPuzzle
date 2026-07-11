using UnityEngine;


public class ProjectileManager : MonoBehaviour
{
    [SerializeField]
    private ProjectileController projectilePrefab;


    [SerializeField]
    private Transform spawnPoint;


    [SerializeField]
    private SlingshotController slingshot;



    private void Start()
    {
        SpawnProjectile();
    }



    public void SpawnProjectile()
    {
        ProjectileController projectile =
            Instantiate(
                projectilePrefab,
                spawnPoint.position,
                Quaternion.identity
            );


        slingshot.LoadProjectile(projectile);
    }
}