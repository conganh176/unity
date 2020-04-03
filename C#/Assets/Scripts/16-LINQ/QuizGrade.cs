using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace LINQ
{
    public class QuizGrade : MonoBehaviour
    {
        public int[] quizGrades = { 42, 69, 25, 23, 96, 73 };
        void Start()
        {
            var passingGrades = quizGrades.Where(grade => grade > 60).OrderByDescending(grade => grade).Reverse();
            Debug.Log("Passing grades:");
            foreach (var grade in passingGrades)
            {
                Debug.Log(grade);
            }
        }
    }
}
