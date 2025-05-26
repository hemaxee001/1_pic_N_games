using UnityEngine;
using UnityEngine.UI;

public class LecPlaying : MonoBehaviour
{
    int levelIndex = 0;
    public Image levelImage;

    private void OnEnable()
    {
        levelIndex = ScreenManager_lecture.instance.levelIndex;
        levelImage.sprite = GameManager_lecture.instance.images[levelIndex];
        var rightAnswer = GameManager_lecture.instance.answer[levelIndex];
    }

}
