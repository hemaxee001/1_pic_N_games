using UnityEngine;

public class GameManager_lecture : MonoBehaviour
{

    public Sprite[] images;
    public string[] answer;
    public static GameManager_lecture instance;

    private void Awake()
    {
        instance = this;
    }

}
