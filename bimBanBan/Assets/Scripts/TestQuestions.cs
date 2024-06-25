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
        CreateQuestion("O que � cashback?", new Dictionary<string, string>
        {
            { "A", "Um desconto na compra de produtos." },
            { "B", "Um valor devolvido ao consumidor ap�s uma compra" },
            { "C", "Um tipo de imposto sobre vendas." },
            { "D", "Um pagamento extra feito pelo vendedor." }
        }, "B");
        CreateQuestion("O que � infla��o?", new Dictionary<string, string>
        {
            { "A", "Aumento geral e cont�nuo dos pre�os." },
            { "B", "Redu��o dos pre�os dos produtos." },
            { "C", "Estagna��o dos pre�os no mercado." },
            { "D", "Crescimento econ�mico r�pido." }
        }, "A");
        CreateQuestion("O que � um empr�stimo?", new Dictionary<string, string>
        {
            { "A", "Dinheiro doado pelo governo." },
            { "B", "Dinheiro dado a fundo perdido." },
            { "C", "Dinheiro cedido temporariamente, com promessa de devolu��o futura." },
            { "D", "Uma forma de investimento direto." }
        }, "C");
        CreateQuestion("Qual a principal fun��o de um banco central?", new Dictionary<string, string>
        {
            { "A", "Arrecadar impostos." },
            { "B", "Emitir moeda e controlar a pol�tica monet�ria.\n" },
            { "C", "Fiscalizar o com�rcio exterior." },
            { "D", "Fornecer empr�stimos aos cidad�os." }
        }, "B");
        CreateQuestion("O que � o PIB (Produto Interno Bruto)?", new Dictionary<string, string>
        {
            { "A", "A soma dos sal�rios pagos em um pa�s." },
            { "B", "O total de dinheiro em circula��o em um pa�s." },
            { "C", "O valor total de bens e servi�os produzidos em um pa�s durante um ano." },
            { "D", "A quantidade de dinheiro que o governo arrecada em impostos." }
        }, "C");
        CreateQuestion("'Em uma economia de mercado, o pre�o de um bem � determinado pela...'", new Dictionary<string, string>
        {
            { "A", "Interven��o direta do governo. " },
            { "B", "Lei da oferta e da demanda." },
            { "C", "Vontade dos consumidores." },
            { "D", "Quantidade de dinheiro em circula��o." }
        }, "B");
        CreateQuestion("Qual dos seguintes conceitos se refere � perda do poder de compra da moeda ao longo do tempo?", new Dictionary<string, string>
        {
            { "A", "Defla��o." },
            { "B", "Hiperinfla��o." },
            { "C", "Estagfla��o." },
            { "D", "Infla��o." }
        }, "D");
        CreateQuestion("Qual das alternativas descreve melhor o papel do governo em uma economia mista?", new Dictionary<string, string>
        {
            { "A", "Planejar e controlar toda a atividade econ�mica." },
            { "B", "Fornecer bens e servi�os p�blicos." },
            { "C", "Regular o mercado." },
            { "D", "Todas as alternativas." }
        }, "D");
        CreateQuestion("Qual � a fun��o principal da bolsa de valores?", new Dictionary<string, string>
        {
            { "A", "Arrecadar fundos para o governo." },
            { "B", "Facilitar a compra e venda de a��es e outros t�tulos." },
            { "C", "Estocar produtos agr�colas." },
            { "D", "Regular o com�rcio internacional." }
        }, "B");
        CreateQuestion("O que � cr�dito consignado?", new Dictionary<string, string>
        {
            { "A", "Empr�stimo com juros flutuantes." },
            { "B", "Empr�stimo cuja parcela � descontada diretamente da folha de pagamento do tomador." },
            { "C", "Empr�stimo para financiar a compra de im�veis." },
            { "D", "Empr�stimo com prazo de pagamento superior a 10 anos." }
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
