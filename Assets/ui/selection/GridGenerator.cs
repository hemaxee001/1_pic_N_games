using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{

    public GameObject buttonPrefab;
    public Sprite[] images;
   


    private void Start()
    {
        for(int i = 0; i<images.Length; i++)
        {
            GameObject clone = Instantiate(buttonPrefab, transform);
            Image image = clone.transform.GetChild(0).GetComponent<Image>();
            image.sprite = images[i];
        }
    }

}
