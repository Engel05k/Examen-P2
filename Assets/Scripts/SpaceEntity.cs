using UnityEngine;

public class SpaceEntity : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    protected Vector3 direction;

    protected virtual bool ShouldClampToScreen => true;

    protected virtual void Move()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (ShouldClampToScreen)
            ClampToScreen();
    }

    private void ClampToScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    public void SetDirection(Vector3 newDir) => direction = newDir;
    public void SetSpeed(float newSpeed) => speed = newSpeed;
}