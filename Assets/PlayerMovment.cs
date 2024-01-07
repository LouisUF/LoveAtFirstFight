using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovment : MonoBehaviour
{
    //General Movement
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 smoothedMovInput;
    private Vector2 smoothVelocity;

    //Dash Ability
    public bool canDash = true;
    [HideInInspector] public bool isDashing = false;
    public float dashDuration = 0.3f;
    public float dashCooldown = 1.5f;
    public float dashSpeed = 10f;

    private Vector2 mousePos;

    //Clear Ability
    public float clearRadius = 5f;
    public bool canClear = false;
    public float clearCooldown = 25f;

    //Teleport Ability
    public bool canTeleport = false;
    public float teleportCooldown = 25f;

    //Animation
    public Animator anim;
    private Vector2 lastVel;

    //Speed Passive
    public bool speedBuff = false;

    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        canDash = false;
        canClear = false;
        speedBuff = false;

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Animate();

        if (Input.GetMouseButtonDown(0)&&canDash) {
            StartCoroutine(Dash());
        }

        if (Input.GetMouseButtonDown(1)&&canClear)
        {
            StartCoroutine(clearScreen(clearRadius));
        }
        if(Input.GetMouseButtonDown(1)&&canTeleport) { 
        
            StartCoroutine(Teleport());
        }

        if(speedBuff) {
            speed = 6.5f;
        }
            
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            smoothedMovInput = Vector2.SmoothDamp(smoothedMovInput, movement, ref smoothVelocity, 0.05f);
            rb.velocity = smoothedMovInput * speed;
        }

        if (movement.x != 0) 
        {
            lastVel.y = 0;
            lastVel.x = rb.velocity.x;
        }
        if (movement.y != 0)
        {
            lastVel.x = 0;
            lastVel.y = rb.velocity.y;
        }
    }

    private IEnumerator Dash()      
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = player.transform.position;
        
        
        Vector2 mouseToPlayer = (mousePos-playerPos).normalized;
        
        canDash = false;
        isDashing = true;
        playerHealth.globalIFrames(dashDuration);
        rb.velocity = mouseToPlayer * (dashSpeed);
        
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }

    private IEnumerator clearScreen(float radius)
    {
        canClear = false;
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[]objects = Physics2D.OverlapCircleAll(pos, radius);
        //Debug.Log(pos);
        foreach (var item in objects)
        {
            if (item.CompareTag("Projectile") || item.CompareTag("IceProjectile")){
                Destroy(item.gameObject);
            }
        }

        yield return new WaitForSeconds(clearCooldown);
        canClear = true;
        Debug.Log("can clear");
    }

    private IEnumerator Teleport()
    {
        canTeleport = false;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(0.5f);
        transform.position = mousePos;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
        Debug.Log("can teleport");
    }

    private void Animate()
    {
        anim.SetFloat("velX", movement.x);
        anim.SetFloat("velY", movement.y);
        anim.SetFloat("moveMagnitude", movement.magnitude);
        anim.SetFloat("lastMoveX", lastVel.x);
        anim.SetFloat("lastMoveY", lastVel.y);
    }

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("IceProjectile"))
        {
            StartCoroutine(Slow());
        }
    }

    private IEnumerator Slow()
    {
        speed = 3.5f;
        yield return new WaitForSeconds(2.0f);
        speed = 5f;
    }



}
