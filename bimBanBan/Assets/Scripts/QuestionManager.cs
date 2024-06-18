using System;
using System.Collections.Generic;
namespace QuestionsCore{
class QuestionManager{
    public static List<Questoes> qt = new List<Questoes>();
    
    //class contructor
    public QuestionManager(){
    }
    public void AddQuestion(Questoes questao){
        qt.Add(questao);
        //Console.WriteLine("Adicionado com sucesso");
    }
    public List<Questoes> GetQuestions(){
        //Console.WriteLine("Há um total de: " + qt.Count);
        return qt;
    }
    public Dictionary<string,string> getQuestion(int index){
        try{
        Dictionary<string,string> question_Dict = new Dictionary<string, string>();
        index --;
        question_Dict = qt[index].getAlternativas(); //retorna um dicionario
        question_Dict["alternativa correta"] = qt[index].getAlternativaCorreta();
        question_Dict["enunciado"] = qt[index].enunciado;

        /*Console.WriteLine("enunciado: " + question_Dict["enunciado"] + "\n" +
        "alternativa A: " + question_Dict["A"] + "\n" +
        "alternativa B: " + question_Dict["B"] + "\n" +
        "alternativa C: " + question_Dict["C"] + "\n" +
        "alternativa D: " + question_Dict["D"] + "\n" +
        "\n");
        "a resposta correta é: " + question_Dict["alternativa correta"]);*/

        return question_Dict;
        }catch(Exception e){
                Console.WriteLine("Error: " + e.ToString() + "\nDescription: " + e.Message.ToString());
                return new Dictionary<string, string>();
        }
        
    }
    public bool AnalyzeResponse(string userResponse, int questionNumber){
        try{ 
        Questoes question = qt[questionNumber-1];
        userResponse = userResponse.ToUpper();
        string questionResponse = question.getAlternativaCorreta();
        if(userResponse == questionResponse){
            Console.WriteLine("Voce acertou!");
            return true;
        }
        else{
            Console.WriteLine("Voce Errou");
            return false;
        }
        }catch(Exception e){
            Console.WriteLine("ERRO: {0}", e.Message);
            return false;
        }
    }
}
}