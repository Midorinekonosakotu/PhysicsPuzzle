using UnityEngine;


public class SlingshotController : MonoBehaviour
{
    [SerializeField]
    private Transform launchPoint;  // スリングショットの弾を発射する位置

    [SerializeField]
    private float launchPower = 10f;    // 引っ張り距離をどれだけ強い力に変換するか

    [SerializeField]
    private float maxDistance = 2f; // スリングショットの最大引っ張り距離

    private bool isDragging;    // ドラッグ中かどうかのフラグ

    private Vector3 startPosition;  // スリングショットの弾の初期位置

    private Rigidbody2D projectileRb;   // 弾のRigidbody2D

    private ProjectileController projectileController; // 弾のProjectileController

    private ProjectileController currentProjectile; // 現在の弾のProjectileController

    private void Start()
    {
        startPosition = launchPoint.position;

        projectileRb = 
            currentProjectile.GetComponent<Rigidbody2D>();

        projectileController =
            currentProjectile.GetComponent<ProjectileController>();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }


        if(Input.GetMouseButton(0) && isDragging)
        {
            Drag();
        }


        if(Input.GetMouseButtonUp(0) && isDragging)
        {
            Release();
        }
    }


    private void StartDrag()
    {
        isDragging = true;

        projectileRb.bodyType = 
            RigidbodyType2D.Kinematic;
    }


    private void Drag()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);


        mousePos.z = 0;


        Vector3 offset =
            mousePos - startPosition;


        if(offset.magnitude > maxDistance)
        {
            offset =
                offset.normalized * maxDistance;
        }


        currentProjectile.transform.position =
            startPosition + offset;
    }


    private void Release()
    {
        isDragging = false;

        Rigidbody2D rb =
            currentProjectile.GetComponent<Rigidbody2D>();

        rb.bodyType =
            RigidbodyType2D.Dynamic;

        Vector2 direction = 
            startPosition - currentProjectile.transform.position;    // 発射方向の計算

        projectileController.Launch(
            direction * launchPower
        );
    }

    public void LoadProjectile(
        ProjectileController projectile)
    {
        currentProjectile = projectile;


        projectile.transform.position =
            launchPoint.position;
    }
}