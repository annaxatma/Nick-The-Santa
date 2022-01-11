using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    int hp = 1;
    int condition = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && condition > 0)
        {
            Destroy(this.gameObject);

            condition = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            --hp;
            Application.LoadLevel("Scenes/gameOver");
        }
    }
}
