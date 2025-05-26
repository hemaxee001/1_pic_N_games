using UnityEngine;
using UnityEngine.UI;

public class Game_playing : MonoBehaviour
{
    int levelIndex = 0;
    public Image levelImage;

    private void OnEnable()
    {
        levelIndex = Scr_manager.instance.levelIndex;
        levelImage.sprite = Game_manager.instance.images[levelIndex];

        //var rightAnswer = Game_manager.instance.answer[levelIndex];

    }


}
