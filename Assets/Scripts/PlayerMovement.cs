using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float jumpingPower = 15f;
    private bool isFacingRight = true;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private AudioSource audiocry;
    [SerializeField]
    private AudioSource audiojump;

     [SerializeField]
    private AudioSource uwee;

    public Animator anim;
    private bool canMoveHorizontal = true;
    private bool IsGrounded;

    public UmbrellaBullet umbrella;
    public Transform shotPos;

    public float ShotDelay;
    private float ShotCounter;
    public bool canShoot = true;
    void Start()
    {
        ShotCounter = ShotDelay;
    }
    void Update()
    {



        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (canMoveHorizontal)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded)
            {
                audiojump.Play();

                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetButtonDown("Fire1") && IsGrounded)
            {
                anim.SetTrigger("cry");

                canMoveHorizontal = false;
                rb.velocity = new Vector2(0f, 0f);
            }

            if (ShotCounter > 0)
            { ShotCounter -= Time.deltaTime; }

            else
            {

                if (Input.GetButtonDown("Fire2"))
                {
                    if (ShotCounter <= 0)
                    {
                         uwee.Play();
                        UmbrellaBullet bullet = Instantiate(umbrella, shotPos.position, shotPos.rotation);
                        bullet.moveDir = new Vector2(transform.localScale.x, 0f);
                        bullet.transform.localScale = new Vector3(transform.localScale.x, 1f, 1f);
                        ShotCounter = ShotDelay;
                    }
                }
            }
        }
        Flip();
        anim.SetBool("IsGrounded", IsGrounded);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("falling", rb.velocity.y);

    }

    private void entercry()
    {
        audiocry.Play();
    }
    private void exitcry()
    {
        canMoveHorizontal = true;
    }



    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
