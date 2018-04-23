using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    //Animation
    public string prev_id = "Idle";
    public string armed = "Armed";
    public string prevDirId = "Front";
    public string prevarmed = "";
    Dictionary<string, int> animations;
    public float animationSpeed = 0.05f;
    public GameObject enemy = null;
    public GameObject end = null;
    public Text life;

    //Movement
    public float speed = 4f;
    public int hp = 100;
    public Vector3 direction;
    private Transform playerTransform;
    public GameObject lvlManager;

    //Health
    float delay = 0f;
    // Use this for initialization
    void Start()
    {
        lvlManager = GameObject.Find("LevelManager");
        life = lvlManager.transform.GetChild(2).gameObject.GetComponent<Text>();
        playerTransform = this.GetComponent<Rigidbody2D>().transform;
        animations = new Dictionary<string, int>();
        #region Init animations
        animations.Add("ArmedFrontIdle", 0);
        animations.Add("ArmedFrontWalk", 1);
        animations.Add("ArmedFrontAttack", 2);
        animations.Add("ArmedBackWalk", 3);
        animations.Add("ArmedBackAttack", 4);
        animations.Add("ArmedLeftWalk", 5);
        animations.Add("ArmedLeftAttack", 6);
        animations.Add("ArmedRightWalk", 7);
        animations.Add("ArmedRightAttack", 8);
        animations.Add("ArmedRightIdle", 9);
        animations.Add("ArmedLeftIdle", 10);
        animations.Add("ArmedBackIdle", 11);

        animations.Add("FrontIdle", 12);
        animations.Add("FrontWalk", 13);
        animations.Add("BackWalk", 14);
        animations.Add("LeftWalk", 15);
        animations.Add("RightWalk", 16);
        animations.Add("RightIdle", 17);
        animations.Add("LeftIdle", 18);
        animations.Add("BackIdle", 19);

        #endregion
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp <= 0)
            lvlManager.GetComponent<LevelManagerScript>().GameOver();
        if (delay > 0)
            delay -= Time.deltaTime;
        else
            delay = 0f;
        life.text = "Life: " + hp + "%";
        if (hp > 60)
            life.color = Color.green;
        else if (hp > 40)
            life.color = Color.yellow;
        else
            life.color = Color.red;
        Actions();
    }

    private int YAxisHandler(float y)
    {
        if (y > 0)
        {
            //playerTransform.rotation = Quaternion.LookRotation(new Vector3(0, 1, 0));
            return 1;
        }
        if (y < 0)
        {
            //playerTransform.rotation = Quaternion.LookRotation(new Vector3(0, -1, 0));
            return -1;
        }
        return 0;
    }

    public void SetHealth()
    {
        hp = 100;
    }

    private int XAxisHandler(float x)
    {
        if (x > 0)
        {
            //playerTransform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
            return 1;
        }
        if (x < 0)
        {
            //playerTransform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
            return -1;
        }
        return 0;
    }

    public void GetDamage(int dgt)
    {
        if (delay == 0 && hp > 0)
        {
            hp -= dgt;
            delay = 1f;
        }
    }

    private void Attack()
    {
        if (enemy != null)
            enemy.GetComponent<EnemyScript>().GetDamage(10);
    }

    private void Actions()
    {
        direction = new Vector3(XAxisHandler(Input.GetAxisRaw("Horizontal")), YAxisHandler(Input.GetAxisRaw("Vertical")), 0);
        playerTransform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        string id_anim = "";
        animationSpeed = 0.01f;
        armed = "Armed";
        if (armed == "Armed" && (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)))
        {
            Attack();
            id_anim = "Attack";
        }
        /*
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (armed == "")
                armed = "Armed";
            else
                armed = "";
        }
        */
        if (direction.x != 0 || direction.y != 0)
            id_anim = "Walk";

        if (id_anim == "")
        {
            animationSpeed = 0.05f;
            id_anim = "Idle";
        }
        if (armed + DirectionId(direction) + id_anim != prevarmed + prevDirId + prev_id)
        {
            Debug.Log(armed + DirectionId(direction) + id_anim);
            this.GetComponent<SpriteAnimationScript>().PlayAnimation(animations[armed + DirectionId(direction) + id_anim], animationSpeed);
            prevarmed = armed;
            prevDirId = DirectionId(direction);
            prev_id = id_anim;
        }
    }

    private string DirectionId(Vector3 direction)
    {
        if (direction.x < 0)
            return "Left";
        if (direction.y > 0)
            return "Back";
        if (direction.x > 0)
            return "Right";
        if (direction.y < 0)
            return "Front";
        return prevDirId;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemy = collider.gameObject;
        }

        if (collider.gameObject.tag == "Finish")
        {
            end = collider.gameObject;
            lvlManager.GetComponent<LevelManagerScript>().GameOver();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemy = null;
        }
    }
}
