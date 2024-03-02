using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topdownmoevement : MonoBehaviour
{
    Vector3 movedir;
    public Animator animator;
    public float speedconfig;
    public float turnrate;
    public int runstate = 0;
    public float stamina = 100f;
    public float staminaregenrate = 1f;
    public float curregen;
    public float staminadegenrate = 2f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            sprint();
    }
    private void FixedUpdate()
    {
        move();
        if(movedir == Vector3.zero)
        {
            curregen = staminaregenrate*2;
            animator.SetBool("Iswalking", false);
        }
        else
        {
            animator.SetBool("Iswalking", true);
        }
        
        stamina += curregen;
        stamina = Mathf.Clamp(stamina, 0, 100);
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * turnrate);
        
        if(stamina == 0f)
        {
            runstate = 0;
        }
    }
    
    private void move()
    {
        float speed = speedconfig;
        var ymove = -Input.GetAxisRaw("Horizontal");
        var xmove = Input.GetAxisRaw("Vertical");
        Vector3 movex = rb.transform.up * ymove;
        Vector3 movey = rb.transform.right * xmove;
         movedir = (movex + movey).normalized;
        if(runstate == 0 )
        {
            speed = speedconfig;
            curregen =   staminaregenrate - staminadegenrate;
            animator.speed = 0.3f;
        }
        else if(runstate == 1 )
        {
            speed = speedconfig*1.5f;
            curregen =  staminaregenrate - staminadegenrate * 1.25f;
            animator.speed = 0.3f * 1.5f;
        }
        else if(runstate == 2 )
        {
            speed = speedconfig * 2f;
            curregen =  staminaregenrate - staminadegenrate * 3f ;
            animator.speed = 0.3f * 3f;
        }

        if (movedir == rb.transform.up || movedir == -rb.transform.up)
        {
            rb.velocity = movedir * speedconfig * 0.75f;
            animator.speed = 0.3f * 0.75f;
            runstate = 0;
        }
        else if (movedir == -rb.transform.right)
        {
            rb.velocity = movedir * speedconfig * 0.5f;
            animator.speed = 0.3f * 0.5f;
            runstate = 0;
        }
        else if (movedir == rb.transform.right)
            rb.velocity = movedir * speed;
        else
        {
            rb.velocity = movedir * speedconfig * 0.75f;
            animator.speed = 0.3f * 0.75f;
            runstate = 0;
        }
    }
    void sprint()
    {
            runstate++;
        
        if(runstate == 3)
        {
            runstate = 0;
        }
            
    }
}
