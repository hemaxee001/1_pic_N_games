//using UnityEngine;
//using UnityEngine.UI;

//public class GridGenerator : MonoBehaviour
//{
//    public GameObject buttonPrefab;
//    private void Start()
//    {
//        Sprite[] images = GameManager_lecture.instance.images;
//        for (int i = 0; i < images.Length; i++)
//        {
//            GameObject clone = Instantiate(buttonPrefab, transform);
//            Image image = clone.transform.GetChild(0).GetComponent<Image>();
//            image.sprite = images[i];
//            int finalI = i;
//            Button button = clone.GetComponent<Button>();
//            button.onClick.AddListener(() =>
//            {
//                ScreenManager_lecture.instance.openLevel(finalI);
//            });
//        }
//    }

//}
