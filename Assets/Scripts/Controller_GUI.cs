using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller_GUI : MonoBehaviour
{
    [SerializeField] private GameObject GUI_Main;
    [SerializeField] private GameObject GUI_Play;
    [SerializeField] private GameObject GUI_Store;
    [SerializeField] private GameObject GUI_Help;
    [SerializeField] private Text txt_CountGem;
    [SerializeField] private AudioSource audio;
    private static int countGem = 0;
    public void incCountGem()
    {
        countGem++;
    }
    public void LoadLV1()
    {
        audio.Play();
        LoadSceneIndex(1);
    }
    public void LoadLV2()
    {
        audio.Play();
        LoadSceneIndex(2);
    }
    public void LoadLV3()
    {
        audio.Play();
        LoadSceneIndex(3);
    }
    public void LoadLV4()
    {
        audio.Play();
        LoadSceneIndex(4);
    }
    public void LoadLV5()
    {
        audio.Play();
        LoadSceneIndex(5);
    }
    private static void LoadSceneIndex(int x)
    {
        SceneManager.LoadScene(x);
    }
    public void btnPlay()
    {
        audio.Play();
        GUI_Main.SetActive(false);
        GUI_Play.SetActive(true);
        GUI_Help.SetActive(false);
        GUI_Store.SetActive(false);
    }
    public void btnHelp()
    {
        audio.Play();
        GUI_Main.SetActive(false);
        GUI_Play.SetActive(false);
        GUI_Help.SetActive(true);
        GUI_Store.SetActive(false);
    }
    public void btnStore()
    {
        audio.Play();
        txt_CountGem.text = "Your Diamonds: " + countGem.ToString();
        GUI_Main.SetActive(false);
        GUI_Play.SetActive(false);
        GUI_Help.SetActive(false);
        GUI_Store.SetActive(true);
    }
    public void btnBack()
    {
        audio.Play();
        GUI_Main.SetActive(true);
        GUI_Play.SetActive(false);
        GUI_Help.SetActive(false);
        GUI_Store.SetActive(false);
    }
}
