using UnityEngine;

public class PlayerShip : SpaceEntity
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxLives = 3;

    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
    }

    private void Update()
    {
        HandleInput();
        Move();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.forward * 150f * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.back * 150f * Time.deltaTime);

        if (Input.GetKey(KeyCode.W)) direction += transform.up * Time.deltaTime * 2f;
        if (Input.GetKey(KeyCode.S)) direction -= transform.up * Time.deltaTime * 2f;

        direction = Vector3.ClampMagnitude(direction, 5f);

        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.up * 0.5f, transform.rotation);
        Bullet b = bullet.GetComponent<Bullet>();
        b.SetDirection(transform.up);
    }

    public void TakeDamage()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            Destroy(gameObject);
        }

        UIManager.Instance.UpdateLives(currentLives);
    }
}