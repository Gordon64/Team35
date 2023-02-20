using UnityEngine;
using System.Collections;
using TMPro;

public class Bandit : MonoBehaviour, SaveLoadInterface
{

    [SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 7.5f;

    private Animator m_animator;
    private Rigidbody2D rb2d;
    private Sensor_Bandit m_groundSensor;
    private bool m_grounded = false;
    private bool m_combatIdle = false;
    private bool m_isDead = false;
    private bool m_running = false;

    public TMP_Text healthText;
    public static int maxHealth = 10;
    public int health = 10;


    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        health = maxHealth;
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        rb2d.velocity = new Vector2(inputX * m_speed, rb2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", rb2d.velocity.y);

        //Check health
        if (health <= 0)
        {
            m_isDead = true;
            m_animator.SetTrigger("Death");
            health = 0;
            //updateText();
        }
        updateText();

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e"))
        {
            if (!m_isDead)
            {
                health = 0;
                m_animator.SetTrigger("Death");
                //updateText();
            }
            else
            {
                health += 1;
                m_animator.SetTrigger("Recover");
                //updateText();
            }

            m_isDead = !m_isDead;
        }

        //Hurt
        else if (Input.GetKeyDown("q"))
        {
            health -= 1;
            m_animator.SetTrigger("Hurt");
            //updateText();
        }

        //Attack
        else if (Input.GetMouseButtonDown(0))
        {
            m_animator.SetTrigger("Attack");
        }

        //Change between idle and combat idle
        else if (Input.GetMouseButtonDown(1))
        {
            m_combatIdle = !m_combatIdle;
            /*
            if (m_combatIdle)
            {
                takeDamage(0);
            }
            else
            {
                takeDamage(2);
            }
            */
            //Need to update this
        }

        else if (Input.GetKeyDown("f"))
        {
            m_running = !m_running;
            if (m_running)
            {
                m_speed += 2;
            }
            else
            {
                m_speed -= 2;
            }
        }

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            rb2d.velocity = new Vector2(rb2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        m_animator.SetTrigger("Hurt");
    }

    void updateText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        updateText();
    }

    public void LoadData(SavedInfo info){
        if(info == null){
            UnityEngine.Debug.Log("info is null");
            return;
        }
        if (info != null){
            this.health = info.health;
        }
    }

    public void SaveData(SavedInfo info){
        info.health = this.health;
    }
}
