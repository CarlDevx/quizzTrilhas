using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runtime : MonoBehaviour
{
    public static short score = TestQuestions.score;
    private void Update()
    {
        if (TestQuestions.actualQuestionID <= 10) {
            score = TestQuestions.score;
        }
    }
}
