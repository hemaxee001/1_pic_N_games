using System;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public Sprite[] images;
   // public string[] answer;
    public static Game_manager instance;

    private void Awake()
    {
        instance = this;
    }
    public string getAnswer()
    {
        return images[Scr_manager.instance.levelIndex].name;
    }

}
