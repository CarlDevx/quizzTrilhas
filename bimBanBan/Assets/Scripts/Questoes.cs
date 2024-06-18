using System;
using System.Collections.Generic;

namespace QuestionsCore
{
    public class Questoes
{
    public string enunciado;
    private Dictionary<string, string> alternativas;
    private string alternativaCorreta;

    //class contructor
    public Questoes(string Enunciado, Dictionary<string,string> alternativas, string alternativaCorreta) { 
        this.enunciado = Enunciado; //recebe o enunciado posto no construtor
        this.alternativas = alternativas; //recebe a lista de dicionarios posta no construtor
        this.alternativaCorreta = alternativaCorreta; //recebe um caractere que corresponde a alternativa correta
    }
    public Dictionary<string,string> getAlternativas() {
        try{
        return alternativas;
        }catch(Exception error){
            Dictionary<string,string> errorMessage = new Dictionary<string, string>();
            errorMessage["error"] = error.Message.ToString();
            return errorMessage;
        }
    }
    public string getAlternativaCorreta()
    {
        return alternativaCorreta;
    }
}
}
