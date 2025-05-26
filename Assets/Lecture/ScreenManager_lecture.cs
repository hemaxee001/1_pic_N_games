using UnityEngine;

public class ScreenManager_lecture : MonoBehaviour
{

    public GameObject screen1, screen2, screen3;
    public static ScreenManager_lecture instance;
    public int levelIndex;

    private void Awake()
    {
        instance = this;
    }

    public void openScreen1()
    {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
    }

    public void openScreen2()
    {
        screen1.SetActive(false);
        screen2.SetActive(true);
        screen3.SetActive(false);
    }

    public void openScreen3()
    {
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(true);
    }

    public void openLevel(int level)
    {
        levelIndex = level;
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(true);
    }

}
