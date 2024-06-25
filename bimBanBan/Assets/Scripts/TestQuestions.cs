using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestQuestions : MonoBehaviour
{
    QuestionsCore.QuestionManager manager;
    [SerializeField]
    public static short actualQuestionID = 1, erros;
    public static short score = 0;
    [SerializeField]
    TMP_Text questionText, alt1, alt2, alt3, alt4, winsText, DefeatsText;
    [SerializeField]
    Button a_btn, b_btn, c_btn, d_btn;
    [SerializeField]
    GameObject questionImage, questionTitle, questionAlternatives;
    void Start()
    {
        //instancia do gerenciador de questoes
        manager = new QuestionsCore.QuestionManager();
        SetupQuestions();
        DisplayQuestion(actualQuestionID);
	//lista contendo os botoes da tela
        List<Button> buttons = new()
        {
            a_btn,
            b_btn,
            c_btn,
            d_btn
        };
        foreach(Button btn in buttons){
            btn.onClick.AddListener(delegate { BottonCheck(btn); }); //adicionando evento de click no btn
        }
    }

    private void SetupQuestions()
    {
        CreateQuestion("O que é cashback?", new Dictionary<string, string>
        {
            { "A", "Um desconto na compra de produtos." },
            { "B", "Um valor devolvido ao consumidor após uma compra" },
            { "C", "Um tipo de imposto sobre vendas." },
            { "D", "Um pagamento extra feito pelo vendedor." }
        }, "B");
        CreateQuestion("O que é inflação?", new Dictionary<string, string>
        {
            { "A", "Aumento geral e contínuo dos preços." },
            { "B", "Redução dos preços dos produtos." },
            { "C", "Estagnação dos preços no mercado." },
            { "D", "Crescimento econômico rápido." }
        }, "A");
        CreateQuestion("O que é um empréstimo?", new Dictionary<string, string>
        {
            { "A", "Dinheiro doado pelo governo." },
            { "B", "Dinheiro dado a fundo perdido." },
            { "C", "Dinheiro cedido temporariamente, com promessa de devolução futura." },
            { "D", "Uma forma de investimento direto." }
        }, "C");
        CreateQuestion("Qual a principal função de um banco central?", new Dictionary<string, string>
        {
            { "A", "Arrecadar impostos." },
            { "B", "Emitir moeda e controlar a política monetária.\n" },
            { "C", "Fiscalizar o comércio exterior." },
            { "D", "Fornecer empréstimos aos cidadãos." }
        }, "B");
        CreateQuestion("O que é o PIB (Produto Interno Bruto)?", new Dictionary<string, string>
        {
            { "A", "A soma dos salários pagos em um país." },
            { "B", "O total de dinheiro em circulação em um país." },
            { "C", "O valor total de bens e serviços produzidos em um país durante um ano." },
            { "D", "A quantidade de dinheiro que o governo arrecada em impostos." }
        }, "C");
        CreateQuestion("'Em uma economia de mercado, o preço de um bem é determinado pela...'", new Dictionary<string, string>
        {
            { "A", "Intervenção direta do governo. " },
            { "B", "Lei da oferta e da demanda." },
            { "C", "Vontade dos consumidores." },
            { "D", "Quantidade de dinheiro em circulação." }
        }, "B");
        CreateQuestion("Qual dos seguintes conceitos se refere à perda do poder de compra da moeda ao longo do tempo?", new Dictionary<string, string>
        {
            { "A", "Deflação." },
            { "B", "Hiperinflação." },
            { "C", "Estagflação." },
            { "D", "Inflação." }
        }, "D");
        CreateQuestion("Qual das alternativas descreve melhor o papel do governo em uma economia mista?", new Dictionary<string, string>
        {
            { "A", "Planejar e controlar toda a atividade econômica." },
            { "B", "Fornecer bens e serviços públicos." },
            { "C", "Regular o mercado." },
            { "D", "Todas as alternativas." }
        }, "D");
        CreateQuestion("Qual é a função principal da bolsa de valores?", new Dictionary<string, string>
        {
            { "A", "Arrecadar fundos para o governo." },
            { "B", "Facilitar a compra e venda de ações e outros títulos." },
            { "C", "Estocar produtos agrícolas." },
            { "D", "Regular o comércio internacional." }
        }, "B");
        CreateQuestion("O que é crédito consignado?", new Dictionary<string, string>
        {
            { "A", "Empréstimo com juros flutuantes." },
            { "B", "Empréstimo cuja parcela é descontada diretamente da folha de pagamento do tomador." },
            { "C", "Empréstimo para financiar a compra de imóveis." },
            { "D", "Empréstimo com prazo de pagamento superior a 10 anos." }
        }, "B");
        //Segunda Fase.
        /*CreateQuestion("", new Dictionary<string, string>
        {
            { "A", "" },
            { "B", "" },
            { "C", "." },
            { "D", "" }
        }, "");
        CreateQuestion("", new Dictionary<string, string>
        {
            { "A", "" },
            { "B", "" },
            { "C", "." },
            { "D", "" }
        }, "");
        */
    }

    void Update()

    {
        
    }
    void BottonCheck(Button btn) {
        if(manager.AnalyzeResponse(btn.tag,actualQuestionID)){
            actualQuestionID++;
            score++;
            winsText.text = "Acertos: " + score.ToString();
            DisplayNextQuestion();
	}else
	{
            erros++;
            DefeatsText.text = "Erros: " + erros.ToString();
            actualQuestionID++;
            DisplayNextQuestion();
        }
    }

    private void DisplayNextQuestion()
    {
        questionTitle.SetActive(false);
        questionImage.SetActive(false);
        questionAlternatives.SetActive(false);
        if (actualQuestionID <= 10)
        {
            DisplayQuestion(actualQuestionID);
        }
        else
        {
            SceneManager.LoadScene("FinalScene");
        }
        questionTitle.SetActive(true);
        questionImage.SetActive(true);
        questionAlternatives.SetActive(true);
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
