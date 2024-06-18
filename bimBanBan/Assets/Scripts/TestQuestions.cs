using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestQuestions : MonoBehaviour
{
    QuestionsCore.QuestionManager manager;
    [SerializeField]
    string playerAnswer = "A";
    [SerializeField]
    TMP_Text questionText, alt1, alt2, alt3, alt4;
    [SerializeField]
    Button a_btn, b_btn, c_btn, d_btn;
    void Start()
    {
        manager = new QuestionsCore.QuestionManager();
        CreateQuestion();
        DisplayQuestion(1);
        a_btn.onClick.AddListener(delegate { BottonCheck(a_btn); });
        b_btn.onClick.AddListener(delegate { BottonCheck(b_btn); });
        c_btn.onClick.AddListener(delegate { BottonCheck(c_btn); });
        d_btn.onClick.AddListener(delegate { BottonCheck(d_btn); });
    }
    void Update()

    {
        
    }
    //deixar a funcao buttonCheck dinamica, fazendo com q o botao seja passado como parametro, ao inves de passar por referencia
    void BottonCheck(Button btn) {
        if (btn.CompareTag(playerAnswer))
        {
            print("true");
        }
        else { 
            print("false");
        }
    }

    void CreateQuestion() {
        //futuro array contendo perguntas
        Dictionary<string, string> a = new Dictionary<string, string>
        {
            ["A"] = "Brazil",
            ["B"] = "China",
            ["C"] = "Canada",
            ["D"] = "Bulgaria"
        }; 
        manager.AddQuestion(new QuestionsCore.Questoes("Pais conhecido por fazer meme com qualquer coisa.", a, "A"));
    }
    private void DisplayQuestion(short index)
    {
        var qt = manager.getQuestion(index);
        try
        {
            questionText.text = qt["enunciado"];
            alt1.text = qt["A"];
            alt2.text = qt["B"];
            alt3.text = qt["C"];
            alt4.text = qt["D"];
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
