using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getQestionScenePontuation : MonoBehaviour
{
    [SerializeField]
    TMP_Text pontuacaoTexto;
    void Start()
    {
        pontuacaoTexto.text += Runtime.score.ToString();
    }
}
