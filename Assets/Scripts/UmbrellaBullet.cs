using UnityEngine;

public class UmbrellaBullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    public Vector2 moveDir;

    // Update is called once per frame
    void Update()
    {
         rb.velocity = moveDir *bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
   
}
