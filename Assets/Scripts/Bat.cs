using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] private Transform aPoint, bPoint, cPoint;
    [SerializeField] private float timeFly, TimeSleep;
    [SerializeField] private float speed;
    private Animator anim;
    private Vector3 target;
    private float realTimeFly, realTimeSleep;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        realTimeFly = 0;
        realTimeSleep = 0;
        transform.position = aPoint.position;
        target = bPoint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == cPoint.position)
        {
            anim.SetBool("isFly", false);
            if (realTimeSleep < TimeSleep)
            {
                realTimeSleep += Time.fixedDeltaTime * speed;
            }
            else
            {
                realTimeFly = 0; realTimeSleep = 0;
                target = bPoint.position;
            }
        }
        else
        {
            anim.SetBool("isFly", true);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, aPoint.position) < 0.1f)
        {
            target = bPoint.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Vector2.Distance(transform.position, bPoint.position) < 0.1f)
        {
            target = aPoint.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        
        if(realTimeFly < timeFly)
        {
            realTimeFly += Time.fixedDeltaTime * speed;
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            target = cPoint.position;
        }
    }
}
