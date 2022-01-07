using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
   public float bounce;
   public Rigidbody2D rb2D;
   public Spawner call;

   void Start()
   {

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
           Destroy(other.gameObject);
           rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
           call.spawn();
       }
   }
   

}
