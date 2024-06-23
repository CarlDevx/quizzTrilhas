using System;
using System.Collections.Generic;
namespace QuestionsCore{
class QuestionManager{
    //qt é o objeto responsavel por gerneciar as questoes
    public static List<Questoes> qt = new List<Questoes>();
    
    //class contructor
    public QuestionManager(){
    }
    public void AddQuestion(Questoes questao){
        qt.Add(questao);
    }
    public List<Questoes> GetQuestions(){
        return qt;
    }
    public Dictionary<string,string> getQuestion(int index){
        try{
        Dictionary<string,string> question_Dict = new Dictionary<string, string>();
        index --;
        question_Dict = qt[index].GetAlternativas(); //retorna um dicionario
        question_Dict["alternativaCorreta"] = qt[index].GetAlternativaCorreta();
        question_Dict["enunciado"] = qt[index].enunciado;
        return question_Dict;
        }catch(Exception e){
                return new Dictionary<string, string>();
        }
        
    }
    public bool AnalyzeResponse(string userResponse, int questionNumber){
        try{ 
        Questoes question = qt[questionNumber-1];
        userResponse = userResponse.ToUpper();
        string questionResponse = question.GetAlternativaCorreta();
        if(userResponse == questionResponse){
            return true;
        }
        else{
            return false;
        }
        }catch(Exception e){
            return false;
        }
    }
}
}
