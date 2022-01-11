using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stomped : MonoBehaviour
{
   public float bounce;
   public Rigidbody2D rb2D;
   public Spawner call;

   public int KillReward = 1;
   public int Score, totalScore;
   public Text giftText;

    void Start()
   {
        Score = 0;
   }

   void Update()
   {

    }

   void Awake()
   {
       call = GameObject.FindObjectOfType<Spawner> ();
   }

   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Enemy"))
       {
           Score = Score + KillReward;
            giftText.text = "x " + Score;
           totalScore = Score;
            Destroy(other.gameObject);
           rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
           call.spawn();
       }
   }
}
