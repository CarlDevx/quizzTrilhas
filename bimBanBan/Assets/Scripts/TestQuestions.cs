using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestQuestions : MonoBehaviour
{
    List<Dictionary<string, string>> list;
    public Questoes Qt;
    [SerializeField]
    string playerAnswer = "";
    [SerializeField]
    TMP_Text questionText, alt1, alt2, alt3, alt4;
    void Start()
    {
        Dictionary<string, string> a; //futuro array contendo perguntas
        a["A"] = "Brazil";
        a["B"] = "China";
        a["C"] = "Brazil";
        a["D"] = "China";
        list.add(a)

        Qt = new Questoes("Pais conhecido por fazer meme com qualquer coisa.", list "A");
        Dictionary<string, string> alternativas = Qt.getAlternativas();
        try {
            questionText.text = Qt.enunciado;
            alt1.text = alternativas["A"];
            alt2.text = alternativas["B"];
            alt3.text = alternativas["C"];
            alt4.text = alternativas["D"];
        }
        catch (Exception error)
        {
            print(error);
        }
    }

    void Update()

    {

    }
}
