using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
   
    public GameObject buttonPrefab;
    //public Sprite[] images;
    //public Image targetImages;
    public static Grid instance;
    public Text starText;

    Image[] completedImageArray;
    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Sprite[] images = Game_manager.instance.images;
        completedImageArray = new Image[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            GameObject clone = Instantiate(buttonPrefab, transform);
            Image image = clone.transform.GetChild(0).GetComponent<Image>();
            Image completedImage = clone.transform.GetChild(1).GetComponent<Image>(); //
            image.sprite = images[i];//

            var state = PlayerPrefs.GetString("" + i, "");//
            completedImage.gameObject.SetActive(state == "clear");//
            completedImageArray[i] = completedImage;//

            int finalI = i;
            Button button = clone.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
               //targetImages.sprite = images[finalI];
                Scr_manager.instance.openLevel(finalI);
            });
        }
    }
    private void OnEnable()//
    {
        starText.text = PlayerPrefs.GetInt("star", 0).ToString();
        if (completedImageArray == null) return;

        for (int i = 0; i < completedImageArray.Length; i++)
        {
            Image completedImage = completedImageArray[i];
            var state = PlayerPrefs.GetString("" + i, "");
            completedImage.gameObject.SetActive(state == "clear");
        }

    }

}