using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]

    public float speed = 10f;      // The speed in m/s
    public float fireRate = 0.3f;  // Seconds/shot
    public float health = 2;
    public int score = 0;      // Points earned for destroying this

    protected BoundsCheck bndCheck;

    private TextMesh playerScore;
    private TextMesh ammoText;

    public Vector3 pos
    {                                                    
        get
        {
            return (this.transform.position);
        }

        set
        {
            this.transform.position = value;
        }

    }                   

    void Awake()
    {                                                
        bndCheck = GetComponent<BoundsCheck>();
    }

    void Update()
    {
        Move();

        if (bndCheck != null && bndCheck.offDown)
        {                   
            // We're off the bottom, so destroy this GameObject
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {                                             
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;                                 

        if (otherGO.tag == "ProjectileHero")
        {                               
            Destroy(otherGO);        // Destroy the Projectile
            health--;
            Debug.Log("hit");
        }

        else
        {
            print("Enemy hit by non-ProjectileHero: " + otherGO.name);    
        }

        if (health == 0)
        {
            Destroy(gameObject);
            playerScore = (TextMesh)GameObject.Find("Score").GetComponent<TextMesh>();
            playerScore.text = (int.Parse(playerScore.text) + score).ToString();
        }
    }
}
