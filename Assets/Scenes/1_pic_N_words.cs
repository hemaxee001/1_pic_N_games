using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    
    public GameObject buttonPrefab;
    public Transform answerParent, questionParent;


    Text[] questionText, answerText;
    public Text wintext;

    Dictionary<int, int> lastIndex = new Dictionary<int, int>();

    string[] rightAnswer = new string[] { "TWITTER" };

    public int levelIndex = 0;



    void generateQuestion()
    {
        for (int i = 0; i < 12; i++)
        {
            var clone = Instantiate(buttonPrefab, questionParent);
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


    private void OnEnable()
    {

        if (questionText == null)
        {
            generateQuestion();
        }

        string question = "JERATOIWTEST";
        for (int i = 0; i < questionText.Length; i++)
        {
            questionText[i].text = question[i].ToString();
        }

        int childCount = answerParent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(answerParent.GetChild(i).gameObject);
        }

        string answer = rightAnswer[levelIndex];
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


    void questionClick(int qIndex)
    {
        //if (wintext.text == "YOU WIN!")
        //{
        //    return;
        //}
        Text qText = questionText[qIndex];

        for (int i = 0; i < answerText.Length; i++)
        {
            if (wintext.text == "YOU WIN!")
            {
                return;
            }

            Text aText = answerText[i];
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

    void answerClick(int aIndex)
    {
        if (wintext.text == "YOU WIN!")
        {
            return;
        }

        int qIndex = lastIndex[aIndex];
        Text aText = answerText[aIndex];
        Text qText = questionText[qIndex];
        qText.text = aText.text;
        aText.text = "";
        lastIndex.Remove(aIndex);
        
    }
    void CheckWin()
    {
        string answer = rightAnswer[levelIndex];
        for (int i = 0; i < answer.Length; i++)
        {
            if (answer[i].ToString() != answerText[i].text) return;
        }
        wintext.text = "YOU WIN!";
    }
}
