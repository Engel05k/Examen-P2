using UnityEngine;

public class Asteroid : SpaceEntity
{
    [SerializeField] private float size = 2f;

    protected override bool ShouldClampToScreen => false;

    private void Update()
    {
        Move();
        transform.Rotate(Vector3.forward * speed * 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (size > 1f)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject small = Instantiate(gameObject, transform.position, Quaternion.identity);
                    Asteroid a = small.GetComponent<Asteroid>();
                    a.SetSize(size / 2f);
                    a.transform.localScale = Vector3.one * a.GetSize();
                    a.SetDirection(Random.insideUnitCircle.normalized);
                    a.SetSpeed(Random.Range(1f, 3f));
                }
            }

            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerShip>().TakeDamage();
            Destroy(gameObject);
        }
    }

    public void SetSize(float newSize) => size = newSize;
    public float GetSize() => size;
}