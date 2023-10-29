using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Animator anim;
    private static int[] countGem = new int[100];
    // Start is called before the first frame update
    void Start()
    {
        if (countGem[0] != 0)
        {
            for(int i = 0; i < countGem.Length; i++)
            {
                countGem[i] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || FindObjectOfType<Player>().Dead())
        {
            GetComponent<AudioSource>().Play();
            Invoke(nameof(LoadSceneCurrent), 0.5f);
        }
        if (FindObjectOfType<Door>().getOpenDoor())
        {
            GetComponent<AudioSource>().Play();
            anim.SetBool("isDead", true);
            Invoke(nameof(LoadSceneNext), 1f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public int getCountGem(int x)
    {
        return countGem[x];
    }
    public void incCountGem()
    {
        countGem[SceneManager.GetActiveScene().buildIndex]++;
    }

    private void LoadSceneCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadSceneNext()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
