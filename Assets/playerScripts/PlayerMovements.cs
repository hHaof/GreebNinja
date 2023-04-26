using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    public float runSpeed = 10f;
    public float crouchSpeed = 5f;
    public int maxHealth = 100;
    int currentHealth;

    public Rigidbody2D rb;

    public Transform attackPoint;
   

    [SerializeField] private Animator playerAni;
    Vector2 movements;
    Vector2 moveDirection;
    Vector2 lastMoveDirection;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        Animate();

        if (movements.x == -1) attackPoint.transform.position = new Vector2(this.transform.position.x - 1f, this.transform.position.y + .5f);

        if (movements.x == 1) attackPoint.transform.position = new Vector2(this.transform.position.x + 1f, this.transform.position.y + .5f);

        if (movements.y == -1) attackPoint.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - .8f);

        if (movements.y == 1) attackPoint.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.5f);



    }

    public void beingHit(int dmg){
        
        currentHealth -= dmg;

        playerAni.SetTrigger("isHurt");

    }
    void FixedUpdate()
    {
        Move();


    }

    void ProcessInput()
    {
        movements.x = Input.GetAxisRaw("Horizontal");
        movements.y = Input.GetAxisRaw("Vertical");

        if (movements.x != 0)
        {
            movements.y = 0;
        }
        else if (movements.y != 0)
        {
            movements.x = 0;
        }


        if ((movements.x == 0 && movements.y == 0) && (moveDirection.x != 0 || moveDirection.y != 0))
        {
            lastMoveDirection = moveDirection;
        }

        moveDirection = movements;

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<combo>().Attack();
        }
    }


    void Move()
    {
        rb.MovePosition(rb.position + movements * speed * Time.deltaTime);
    }

    void Animate()
    {
        playerAni.SetFloat("moveX", movements.x);
        playerAni.SetFloat("moveY", movements.y);

        playerAni.SetFloat("speed", movements.magnitude);

        playerAni.SetFloat("faceX", lastMoveDirection.x);
        playerAni.SetFloat("faceY", lastMoveDirection.y);
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerAni.SetBool("isCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            playerAni.SetBool("isCrouch", false);
        }



    }
}
