using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public string prev_id = "Idle";
    public string prevDirId = "Front";
    Dictionary<string, int> animations;
    public float animationSpeed = 0.05f;
    public Text life;
    public GameObject target;

    public float speed = 4f;
    public int hp = 100;
    public Vector3 direction;
    private Transform enemyTransform;

    float threshold = 0.1f;

    void Start()
    {
        enemyTransform = this.transform;
        animations = new Dictionary<string, int>();
        #region Init animations
        animations.Add("FrontIdle", 0);
        animations.Add("FrontWalk", 1);
        animations.Add("FrontAttack", 2);
        animations.Add("BackIdle", 3);
        animations.Add("BackWalk", 4);
        animations.Add("BackAttack", 5);
        animations.Add("LeftIdle", 6);
        animations.Add("LeftWalk", 7);
        animations.Add("LeftAttack", 8);
        animations.Add("RightIdle", 9);
        animations.Add("RightWalk", 10);
        animations.Add("RightAttack", 11);
        #endregion
    }

    void Update()
    {
        /*
        life.text = "Life" + hp + "%";
        if (hp > 60)
            life.color = Color.green;
        else if (hp > 40)
            life.color = Color.yellow;
        else
            life.color = Color.red;
        */
        if (target != null)
            AttackPlayer();
        if (hp <= 0)
            Destroy(this.gameObject);
    }

    public void GetDamage(int dgt)
    {
        Debug.Log("Enemy DMG");
        if (hp > 0)
        {
            hp -= dgt;
        }
    }

    void AttackPlayer()
    {
        Debug.Log(Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2)));
        if (Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2)) > 1)
        {
            this.GetComponent<SpriteAnimationScript>().PlayAnimation(animations["FrontIdle"], animationSpeed);
            return;
        }
        float xdir = 0;
        float ydir = 0;
        if (target.transform.position.x - transform.position.x > threshold)
            xdir = 1;
        if (target.transform.position.x - transform.position.x < -threshold)
            xdir = -1;
        if (target.transform.position.y - transform.position.y > threshold)
            ydir = 1;
        if (target.transform.position.y - transform.position.y < -threshold)
            ydir = -1;

        Vector3 direction = new Vector3(xdir, ydir, 0);

        transform.position += direction * speed * Time.deltaTime;

        string id_anim = "";

        if (direction.x != 0 || direction.y != 0)
            id_anim = "Walk";
        else
        {
            id_anim = "Attack";
            target.GetComponent<PlayerScript>().GetDamage(10);
        }

        if (id_anim == "")
        {
            animationSpeed = 0.05f;
            id_anim = "Idle";
        }
        if (DirectionId(direction) + id_anim != prevDirId + prev_id)
        {
            Debug.Log(DirectionId(direction) + id_anim);
            this.GetComponent<SpriteAnimationScript>().PlayAnimation(animations[DirectionId(direction) + id_anim], animationSpeed);
            prevDirId = DirectionId(direction);
            prev_id = id_anim;
        }
    }

    private string DirectionId(Vector3 direction)
    {
        if (direction.x > 0)
            return "Right";
        if (direction.x < 0)
            return "Left";
        if (direction.y > 0)
            return "Back";
        if (direction.y < 0)
            return "Front";
        return prevDirId;
    }
}
