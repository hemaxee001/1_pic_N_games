using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public GameObject intro1, intro2;

    private void Start()
    {
        Invoke("openIntro2", 2f);
    }

    void openIntro2()
    {
        intro1.SetActive(false);
        intro2.SetActive(true);
        Invoke("startGame", 2f);
    }

    void startGame()
    {
        gameObject.SetActive(false);
        ScreenManager.instance.openScreen1();
    }

}
