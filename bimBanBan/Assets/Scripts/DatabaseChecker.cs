using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DatabaseChecker : MonoBehaviour
{
    private const string URL = "https://desafio-4-inova-maranhao.onrender.com/usuario/login";//Mudar para o link/endpoint correto do backend
    private Button Loginbtn;

    [SerializeField]
    private TMP_InputField m_email;
    [SerializeField]
    private TMP_InputField m_password;
    [SerializeField]
    private GameObject sceneObjectGroup;

    private void Start()
    {
        Loginbtn = GetComponent<Button>();
        Loginbtn.onClick.AddListener(delegate { ChecarCadastro(); });
    }
    public void ChecarCadastro()
    {
        //DestroyLoginObjects.DestroyLoginPage();
        StartCoroutine(ProcuraUsuarioNoBackEnd(URL));
    }

    private IEnumerator ProcuraUsuarioNoBackEnd(string uri)
    {
        WWWForm form = new CadastroWWWForm(m_email.text, m_password.text).GetForm();

        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success) //se der algum erro, mostra a mensagem no Console
            {
                Debug.LogError($"Error: {request.error}\nStatus Code: {request.responseCode}\nResponse: {request.downloadHandler.text}");
            }
            else
            {
                Debug.Log(request.downloadHandler.text); //Se não deu erro, aqui a gente vê a mensagem
                if(request.responseCode == 200)
                {
                    SceneManager.LoadScene("QuestionScene");//Mude para o nome para o nome da sua cena em que o jogo está
                }
            }
        }
    }
}

public class CadastroWWWForm
{
    public WWWForm form;

    public CadastroWWWForm(string newEmail, string newPassword)
    {
        form = new WWWForm();
        form.AddField("email", newEmail);
        form.AddField("password", newPassword);
    }

    public WWWForm GetForm()
    {
        return form;
    }
}

