using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
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
            FindAnyObjectByType<Player>().transform.position = startPoint.position;
            Invoke(nameof(LoadSceneCurrent), 0.1f);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void LoadSceneIndex(int x)
    {
        SceneManager.LoadScene(x);
    }
}
