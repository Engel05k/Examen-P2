using UnityEngine;

public class Bullet : SpaceEntity
{
    [SerializeField] private float lifetime = 5f;
    private float lifeTimer;

    protected override bool ShouldClampToScreen => false;

    private void Update()
    {
        Move();
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifetime)
            Destroy(gameObject);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}