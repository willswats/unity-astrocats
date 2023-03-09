using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileVelocity = 500f;
    private float projectileLifeTimeSeconds = 10f;
    private Rigidbody2D rb2d;

    public void SetForce(Vector2 direction)
    {
        this.rb2d.AddForce(direction * projectileVelocity);
    }

    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(this.gameObject, this.projectileLifeTimeSeconds);
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        Destroy(this.gameObject);
    }
}
