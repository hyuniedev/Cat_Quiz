using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject keyCollection;
    private bool haveKey = false;
    // Start is called before the first frame update
    void Start()
    {
        keyCollection.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            key.SetActive(false);
            keyCollection.SetActive(true);
            haveKey = true;
        }
    }
    public bool getHaveKey()
    {
        return haveKey;
    }
}
