using UnityEngine;


public class SlingshotController : MonoBehaviour
{
    [SerializeField]
    private Transform projectile;

    [SerializeField]
    private Transform launchPoint;

    [SerializeField]
    private float launchPower = 10f;    // 引っ張り距離をどれだけ強い力に変換するか

    [SerializeField]
    private float maxDistance = 2f;

    private bool isDragging;

    private Vector3 startPosition;

    private Rigidbody2D projectileRb;   // 弾のRigidbody2D

    private ProjectileController projectileController;


    private void Start()
    {
        startPosition = launchPoint.position;

        projectileRb = 
            projectile.GetComponent<Rigidbody2D>();

        projectileController =
            projectile.GetComponent<ProjectileController>();
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


        projectile.position =
            startPosition + offset;
    }


    private void Release()
    {
        isDragging = false;

        projectileRb.bodyType = 
            RigidbodyType2D.Dynamic;

        Vector2 direction = 
            startPosition - projectile.position;    // 発射方向の計算

        projectileController.Launch(
            direction * launchPower
        );
    }
}