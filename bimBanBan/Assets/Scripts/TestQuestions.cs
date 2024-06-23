using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestQuestions : MonoBehaviour
{
    QuestionsCore.QuestionManager manager;
    [SerializeField]
    short actualQuestionID = 1;
    [SerializeField]
    TMP_Text questionText, alt1, alt2, alt3, alt4;
    [SerializeField]
    Button a_btn, b_btn, c_btn, d_btn;
    void Start()
    {
        manager = new QuestionsCore.QuestionManager();
        CreateQuestion("O que é cashback?", new Dictionary<string, string>{
            ["A"] = "Um desconto na compra de produtos.",
            ["B"] = "Um valor devolvido ao consumidor após uma compra.",
            ["C"] = "Um tipo de imposto sobre vendas.",
            ["D"] = "Um pagamento extra feito pelo vendedor."
        }, "B");
        CreateQuestion("O que é inflação?", new Dictionary<string, string>
        {
            ["A"] = "Aumento geral e contínuo dos preços.",
            ["B"] = "Redução dos preços dos produtos.",
            ["C"] = "Estagnação dos preços no mercado.",
            ["D"] = "Crescimento econômico rápido."
        }, "A");

        DisplayQuestion(actualQuestionID);
        List<Button> buttons = new()
        {
            a_btn,
            b_btn,
            c_btn,
            d_btn
        };
        foreach(Button btn in buttons){
            btn.onClick.AddListener(delegate { BottonCheck(btn); });
        }
    }
    void Update()

    {
        
    }
    void BottonCheck(Button btn) {
        if (btn.CompareTag(manager.getQuestion(actualQuestionID)["alternativaCorreta"]))
        {
            print("true");
        }
        else
        {
            print("false");
        }
    }

    void CreateQuestion(string enunciado, Dictionary<string,string> a, string alternativaCorreta) {
        manager.AddQuestion(new QuestionsCore.Questoes(enunciado, a, alternativaCorreta));
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
