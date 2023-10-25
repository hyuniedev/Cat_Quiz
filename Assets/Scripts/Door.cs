using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject keyE;
    private float timeHoldKey = 0;
    private bool okOpen = false;
    private bool isEnterPlayer = false;
    private bool haveKey = false;
    // Start is called before the first frame update
    void Start()
    {
        keyE.SetActive(false);
        anim.SetFloat("checkOpen", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        haveKey = FindObjectOfType<Key>().getHaveKey();
        if(isEnterPlayer)
        {
            if (timeHoldKey < 1.0f)
            {
                timeHoldKey += Time.fixedDeltaTime;
            }
            else
            {
                okOpen = true;
                timeHoldKey = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && haveKey)
        {
            keyE.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                isEnterPlayer = true;
                if (okOpen) anim.SetFloat("checkOpen", 1);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                okOpen = false;
                keyE.SetActive(false);
                anim.SetFloat("checkOpen", 0);
                isEnterPlayer = false;
            }
        }
    }
}
