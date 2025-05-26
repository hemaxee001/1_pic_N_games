using UnityEngine;
using UnityEngine.UI;

public class Scr_manager : MonoBehaviour
{
    public GameObject screen1, screen2, screen3;
    
    public static Scr_manager instance;
    public int levelIndex;
   

    private void Awake()
    {
        instance = this;
        //print(this);
    }
    public void openScreen1()
    {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
        
    }
    public void openScreen2()
    {
        //NewMonoBehaviourScript.instance;
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
