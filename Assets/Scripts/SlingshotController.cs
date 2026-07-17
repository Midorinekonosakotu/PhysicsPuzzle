using UnityEngine;


public class SlingshotController : MonoBehaviour
{
    private ProjectileController currentProjectile;

    [SerializeField]
    private Transform launchPoint;

    [SerializeField]
    private float maxDistance = 2f;

    [SerializeField]
    private float launchPower = 10f;

    private bool isDragging;

    private Vector3 startPosition;


    public void LoadProjectile(
            ProjectileController projectile)
    {
        currentProjectile = projectile;


        projectile.transform.position =
            launchPoint.position;
    }

    private void Start()
    {
        startPosition = launchPoint.position;
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

        Rigidbody2D rb =
            currentProjectile.GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    private void Drag()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        mousePos.z = 0;

        Vector3 offset =
            mousePos - startPosition;

        if(offset.magnitude > maxDistance)
        {
            offset =
                offset.normalized *
                maxDistance;
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
            startPosition -
            currentProjectile.transform.position;

        currentProjectile.Launch(
            direction * launchPower
        );
    }
}