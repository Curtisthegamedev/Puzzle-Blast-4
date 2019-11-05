using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    //sets bool variables needed to toggle flip and attack functions. 
    public bool isLookingRight;
    public static bool hasArmour = false, hasSword = false;
    public Text scoreText;

    private bool onGround, GravityFlip = false, isInvinsable = false, startSwordTimer = false,
        startCountdownTillDeath = false;
    private bool hasLaserGun = false;
    private float moveValue, speed = 10.0f, mass = 1.0f, swordTimer = 0.2f;
    private GameObject LaserSpawnPoint;
    private Rigidbody2D instanceOfBallShot, instanceOfLaserShot, rb;
    private Transform myTransform;
    private Vector3 velocity, accel;
    private SpriteRenderer foxSprite; 

    [SerializeField] float deathTimer;
    [SerializeField] float JumpForce;
    [SerializeField] Animator anim;
    [SerializeField] GameObject LaserBolt, sword, LaserGun, SwordWhileSwinging;
    [SerializeField] SpriteRenderer playerSpriteRenderer; //Get the sprite renderer
    [SerializeField] Transform shotSpawn;
    int _points;

    float horizontal;
    private void Awake()
    {
        //makes sure script has ridgidbody component and that mass is set. 
        rb = GetComponent<Rigidbody2D>();
        rb.GetComponent<Rigidbody2D>();
        rb.mass = 1.0f;
        myTransform = GetComponent<Transform>();
        foxSprite = GetComponent<SpriteRenderer>(); 
    } 

    //flips character based on where the player faces. 
    void Flip(float horizontal)
    {
        if ((horizontal > 0 && !isLookingRight || horizontal < 0 && isLookingRight) && !startCountdownTillDeath)
        {
            isLookingRight = !isLookingRight;
            transform.Rotate(0.0f, 180f, 0f);  
        }
    }

    public int points
    {
        get
        {
            return _points;
        }
        set
        {
            _points = value;
            if (scoreText)

                scoreText.text = "Score: " + points;
        }
    }

    //if player colldes with ground set animator bool and script bool to true. 
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "SwordAttackPowerUp")
        {
            hasSword = true;
            hasLaserGun = false; 
            sword.SetActive(true);
            LaserGun.SetActive(false); 
            Destroy(c.gameObject); 
        }

        if (c.gameObject.tag == "LaserGun")
        {
            Destroy(c.gameObject); 
            hasSword = false;
            hasLaserGun = true;
            LaserGun.SetActive(true);
            sword.SetActive(false);
            SwordWhileSwinging.SetActive(false); 
            //Instantiate(LaserGun, shotSpawn.position, shotSpawn.rotation); 
        }

        if (c.gameObject.tag == "Armour" && ArmourBar.armourAmount < 3)
        {
            ArmourBar.armourAmount = ArmourBar.armourAmount + 1;
            Destroy(c.gameObject);
        }
        else if(c.gameObject.tag == "Armour" && ArmourBar.armourAmount >= 3)
        {
            Destroy(c.gameObject); 
        }

        if(!isInvinsable && (c.gameObject.CompareTag("Enemy") || c.gameObject.CompareTag("EProjectile")))
        {
            Debug.Log(isInvinsable); 
            //starts the coroutine that makes the player invinsible
            StartCoroutine(TempInvinsibility()); 
            //projectiles will be destroyed when they touch the player
            if(c.gameObject.tag == "EProjectile")
            {
                Destroy(c.gameObject); 
            }

            if(!hasArmour)
            {
                Health.life--; 
            }
            else if (hasArmour)
            {
                ArmourBar.armourAmount--; 
            }
        }

        if (c.gameObject.tag == "CherryPowerUp")
        {
            speed = speed + 5;
            Destroy(c.gameObject);
        }

        if (c.gameObject.tag == "Invincible")
        {
            playerSpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            isInvinsable = true;
            Destroy(c.gameObject);
            StartCoroutine(waitAndTurnOffInvinsibility());
        }

        if (c.gameObject.tag == "Gem")
        {
            Gem gem = c.gameObject.GetComponent<Gem>(); 

            if (gem)
            {
                points += gem.Points;
                Destroy(c.gameObject);
            }
        }

        if(c.gameObject.tag == "Pie")
        {
            Health.life++;
            Destroy(c.gameObject); 
        }
    }

    private IEnumerator TempInvinsibility()
    {
        isInvinsable = true;
        foxSprite.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        foxSprite.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);
        foxSprite.color = new Color(1f, 1f, 1f, 0.5f); 
        yield return new WaitForSeconds(0.5f);
        foxSprite.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);
        foxSprite.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        foxSprite.color = new Color(1f, 1f, 1f, 1f);
        isInvinsable = false;
    }

    private IEnumerator waitAndTurnOffInvinsibility()
    {
        yield return new WaitForSeconds(15);
        playerSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        isInvinsable = false; 
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        //if the player collides with RGravity they will flip upside down allowing the to walk upside down. 
        //gravity will also be pushing the player up instead of down. 
       if(c.gameObject.tag == "RGravity")
        {
            myTransform.Rotate(0, 0, 540);
            rb.gravityScale = -1;
            GravityFlip = true;
        }

       if(c.gameObject.CompareTag("RedLaser"))
        {
            StartCoroutine(TempInvinsibility()); 
            if(hasArmour)
            {
                ArmourBar.armourAmount -= 1;
            }
            else
            {
                Health.life -= 1; 
            }
        }
        
        if (c.gameObject.tag == "NGravity")
        {
            myTransform.Rotate(0, 0, -540);  
            rb.gravityScale = 1;
            GravityFlip = false; 
        }

        if (c.gameObject.tag == "Blockman")
        {
            startCountdownTillDeath = true;
            rb.velocity = new Vector3(0, 0, 0); 
            myTransform.localScale = new Vector3(myTransform.localScale.x, 3.5f,
                myTransform.localScale.z);
            anim.enabled = false;
        }

        if (c.gameObject.tag == "Death")
        {
            SceneManager.LoadScene("GameOver"); 
        }

        if (c.gameObject.tag == "Gem")
        {
            Gem gem = c.GetComponent<Gem>();

            if (gem)
            {
                points += gem.Points;
                Destroy(c.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "RGravity")
        {
            Flip(-horizontal); 
        }
        if(col.gameObject.tag == "NGravity")
        {
            Flip(horizontal); 
        }
    }

    //on ground bools are always true when the player is onGround. 
    private void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("onGround", true);
        }
    }
    //on ground bools are flase if player leaves the ground.
    private void OnCollisionExit2D(Collision2D c)
    {
        //if(c.gameObject.tag == "Ground")
        //{
            onGround = false;
            anim.SetBool("onGround", false); 
        //}
    }

    private void SwordAttack()
    {
        if(hasSword && Input.GetKeyDown(KeyCode.LeftShift) && swordTimer == 0.2f)
        {
            sword.SetActive(false);
            SwordWhileSwinging.SetActive(true);
            startSwordTimer = true; 
            if(swordTimer <= 0)
            {
                sword.SetActive(true);
                SwordWhileSwinging.SetActive(false);
                swordTimer = 0.2f;
            }
        }
        if(startSwordTimer)
        {
            swordTimer -= Time.deltaTime; 
        }

        if (swordTimer <= 0)
        {
            sword.SetActive(true);
            SwordWhileSwinging.SetActive(false);
            startSwordTimer = false;
            swordTimer = 0.2f; 
        }
    }


    private void Update()
    {
        SwordAttack();
        horizontal = Input.GetAxis("Horizontal");
        if(startCountdownTillDeath)
        {
            deathTimer += Time.deltaTime;
            if(deathTimer >= 3)
            {
                SceneManager.LoadScene("GameOver"); 
            }
        }
        if(!GravityFlip)
        {
            Flip(horizontal);
        }
        else
        {
            Flip(-horizontal); 
        }
        moveValue = Input.GetAxisRaw("Horizontal");

        //Debug.Log(moveValue); 
        if (onGround)
        {
            anim.SetBool("onGround", true); 
            //controls movement. 
            if(Input.GetButtonDown("Jump") && !GravityFlip)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpForce;
            }
            else if(Input.GetButtonDown("Jump") && GravityFlip)
            {
                GetComponent<Rigidbody2D>().velocity = -Vector2.up * JumpForce;
                Debug.Log("upsidedown jump");
            }
        }

        if (rb && !startCountdownTillDeath)
        {
            rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);
            anim.SetFloat("Moveing", Mathf.Abs(moveValue)); 
        }
        else
        {
            Debug.Log("this script does not have the rb");
        }
    }
}