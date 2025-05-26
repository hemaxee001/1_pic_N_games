using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    public static NewMonoBehaviourScript instance;

    public GameObject buttonPrefab;

    public Transform answerParent, questionParent;

    Text[] questionText, answerText;

    public GameObject next_bt;

    public Image levelImage,winImage;

    public int startIndex = 0;   
    public  Text starCounter;
    bool isFinished;

    public Image starPanel; 
    public Image star_1, star_2, star_3;

    Dictionary<int, int> lastIndex = new Dictionary<int, int>();

    //string[] rightAnswer = new string[] { "TWITTER", "FACEBOOK", "YOUTUBE", "LIGHTROOM", 
    //                                        "LINKEDIN", "PHOTOSHOP", "TELEGRAM", "WHATSAPP", "AFTEREFFECT",
    //                                        "FILE", "ADIDAS", "INSTAGRAM", "NETFLIX", "SPOTIFY", "BMW", "SNAPCHAT" };

    //public int levelIndex = 0;
    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       startIndex = PlayerPrefs.GetInt("star", 0);
        starCounter.text = startIndex.ToString();
    }

    //-----------------------------generate question-----------------------------

    void generateQuestion()
    {
        for (int i = 0; i < 12; i++)
        {
            var clone = Instantiate(buttonPrefab,questionParent);
            var b = clone.GetComponent<Button>();
            var t = clone.GetComponentInChildren<Text>();
            t.text = "";
            int finalI = i;
            b.onClick.AddListener(() =>
            {
                questionClick(finalI);
            });
        }
        questionText = questionParent.GetComponentsInChildren<Text>();
    }

    // -----------------------onEnanle ---------------------------------
  
    private void OnEnable()
    {
        // -------------- question ----------------------
        starPanel.gameObject.SetActive(false);//===
        isFinished = false;
        winImage.gameObject.SetActive(false);//===
        next_bt.SetActive(false);//===
        questionParent.gameObject.SetActive(true);//==
        star_1.gameObject.SetActive(false);//===
        star_2.gameObject.SetActive(false);//===
        star_3.gameObject.SetActive(false);//=== 
        if (Game_manager.instance.images.Length == Scr_manager.instance.levelIndex)
        {
            return;
        }
        levelImage.sprite = Game_manager.instance.images[Scr_manager.instance.levelIndex];
        if (questionText == null)
        {
            generateQuestion();
        }
        string answer = Game_manager.instance.getAnswer();

        char[] question = getRandomQuestion(answer);

        for (int i = 0; i < questionText.Length; i++)
        {
            questionText[i].text = question[i].ToString();
        }
        // --------------------------------------answer  ----------------------

        int childCount = answerParent.childCount;

        for (int i = 0; i < childCount; i++)
        {
            DestroyImmediate(answerParent.GetChild(0).gameObject);
        }    
        for (int i = 0; i < answer.Length; i++)
        {
            var clone = Instantiate(buttonPrefab, answerParent);
            var t = clone.GetComponentInChildren<Text>();
            var b = clone.GetComponent<Button>();
            t.text = "";
            int finalI = i;
            b.onClick.AddListener(() =>
            {
                answerClick(finalI);
            });
        }
        answerText = answerParent.GetComponentsInChildren<Text>();
    }
    // ---------------------------------------question click----------------------
    // 
    string AllChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    char[] getRandomQuestion(string answer)
    {
        char[] q = new char[12];
        for (int i = 0; i < answer.Length; i++)
        {
            q[i] = answer[i];
        }
        for (int i = answer.Length; i < 12; i++)
        {
            var randomIndex = Random.Range(0, AllChar.Length);
            q[i] = AllChar[randomIndex];
        }
        for (int i = 0; i < q.Length; i++)
        {
            var randomIndex = Random.Range(0, q.Length);
            char temp = q[i];
            q[i] = q[randomIndex];
            q[randomIndex] = temp;
        }
        return q;
    }
    void questionClick(int qIndex)
    {
        
        Text qText = questionText[qIndex];

        for (int i = 0; i < answerText.Length; i++)
        {
            Text aText = answerText[i];
            if (qText.text == "") return;
            if (aText.text == "")
            {
                lastIndex.Add(i, qIndex);              
                aText.text = qText.text;
                qText.text = "";
                CheckWin();
                break;           
            }
        }
    }
    // ---------------- answer click----------------------
    void answerClick(int aIndex)
    {

        //Text qText = questionText[aIndex];
        Text aText = answerText[aIndex];

        if(aText.text == "")
        {
            return;
        }

        int qIndex = lastIndex[aIndex];
        Text qText = questionText[qIndex];
        qText.text = aText.text;
        aText.text = "";
        lastIndex.Remove(aIndex);
        if (isFinished == true)
        {
            return;
        }
    }
    // ---------------- check win----------------------
    void CheckWin()
    {
        string answer = Game_manager.instance.getAnswer();
        for (int i = 0; i < answer.Length; i++)
        {
            if (answer[i].ToString() != answerText[i].text) return;
        }       
        winImage.gameObject.SetActive(true);
        next_bt.SetActive(true); //===
        questionParent.gameObject.SetActive(false);//===
       
        starPanel.gameObject.SetActive(true);//===
        star_1.gameObject.SetActive(true);//===
        star_2.gameObject.SetActive(true);//===
        star_3.gameObject.SetActive(false);//===
     
        isFinished = true;

        if (isFinished == true)
        {
            startIndex += 3;
            PlayerPrefs.SetInt("star", startIndex);
            starCounter.text = startIndex.ToString();
        }

    }
    //====================next level=========================   
    public void nextLevel() //====
    {
        PlayerPrefs.SetString("" + Scr_manager.instance.levelIndex, "clear");//
        Scr_manager.instance.levelIndex++;
        lastIndex.Clear();
        OnEnable();
        
    }
    //============================reset=========================
    public void refresh()
    {       
        //wintext.text = "";
        foreach (var key in lastIndex.Keys)
        {
            questionText[lastIndex[key]].text = answerText[key].text;
        }
        lastIndex.Clear();
        for (int i = 0; i < answerText.Length; i++)
        {
            answerText[i].text = "";
        }
        winImage.gameObject.SetActive(false);
        //===
    }
}
