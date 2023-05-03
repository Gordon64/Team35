using UnityEngine;
using System.Collections;
using TMPro;

public class Bandit : MonoBehaviour, SaveLoadInterface
{

    [SerializeField] public float m_speed = 4.0f;
    [SerializeField] public float m_jumpForce = 7.5f;

    public static Bandit Instance;
    public bool shopEnabled = false;
    public Rigidbody2D rb2d;

    private Animator m_animator;
    private Sensor_Bandit m_groundSensor;
    private bool m_grounded = false;
    private bool m_combatIdle = false;
    private bool m_isDead = false;
    private bool m_running = false;

    public TMP_Text healthText;
    public float health;
    public float defense;
    public int level;

    SavePlayerPos playerPosData;
    public GameObject PlayerUnit;
    private UnitStats units;

    private void Awake()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
        units = PlayerUnit.GetComponent<UnitStats>();
    }

    // Use this for initialization
    void Start()
    {
        Instance = this;
        m_animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        updateText(); 
        
    }

    // Update is called once per frame
    void Update()
    {

        //UnityEngine.Debug.Log(units.health);
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
        if(!shopEnabled){
            if (!m_isDead)
            {
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

                //Hurt
                if (Input.GetKeyDown("q"))
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
        }
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

    //increase health with the potion
    public void increaseHealth(int healthBoost)
    {
        health += healthBoost;
        healthText.text = $"HP: {health}";
    }

    //increase defense with the potion
    public void increaseDefense(int defenseBoost)
    {
        defense += defenseBoost;
    }

    //increase energy
    public void increaseEnergy(int energyBoost){
        units.energy += energyBoost;
    }

    //increase attack
    public void increaseAttack(int attackBoost){
        units.attack += attackBoost;
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
            if (this != null){
                if(StartNewGame.instance.BattleCheck != true){
                    units.health = info.health;
                    units.attack = info.attack;
                    units.defense = info.defense;
                    units.speed  = info.speed;
                    units.energy = info.energy;
                    units.maxHealth = info.MaxHealth;
                    units.maxEnergy = info.MaxEnergy;
                }
                StartNewGame.instance.BattleCheck = false;
                this.transform.position = info.position;
            }
        }
    }

    public void SaveData(SavedInfo info){
        if(this != null){
            UnityEngine.Debug.Log("data I am saving: " + units.health);
            info.health = units.health;
            info.position = this.transform.position;
            info.attack = units.attack;
            info.defense = units.defense;
            info.speed = units.speed;
            info.energy = units.energy;
            info.MaxHealth = units.maxHealth;
            info.MaxEnergy = units.maxEnergy;
            info.LastScene = StartNewGame.instance.sceneStack.Pop();
            UnityEngine.Debug.Log(info.LastScene);
        }
    }
}
