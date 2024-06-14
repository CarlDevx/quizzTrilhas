using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

public class Questoes
{
    public string enunciado;
    private List<Dictionary<string, string>> alternativas;
    private string alternativaCorreta;

    public Questoes(string Enunciado, List<Dictionary<string,string>> alternativas, string alternativaCorreta) { 
        this.enunciado = Enunciado; //recebe o enunciado posto no construtor
        this.alternativas = alternativas; //recebe a lista de dicionarios posta no construtor
        this.alternativaCorreta = alternativaCorreta; //recebe um caractere que corresponde a alternativa correta
    }
    public Dictionary<string,string> getAlternativas() {
        
        this.alternativas.foreach (delegate (IDictionary<string, string> dictionary)) {
            console.log(dictionary);
        }

        /*dic["A"] = "Brazil";
        dic["B"] = "China";
        dic["C"] = "Coca-cola";
        dic["D"] = "XinXanzPro";
        return dic;*/
    }
    public string getAlternativaCorreta()
    {
        return alternativaCorreta;
    }
}

