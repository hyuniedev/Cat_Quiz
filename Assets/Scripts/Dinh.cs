using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinh : MonoBehaviour
{
    [SerializeField] private GameObject[] dinh;
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            for(int i = 0; i < dinh.Length; i++)
            {
                dinh[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                dinh[i].GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                dinh[i].GetComponent<Rigidbody2D>().gravityScale = 4;
            }
        }
        if (collision.gameObject.layer.Equals("Ground"))
        {
            transform.position = transform.position;
        }
    }
}
