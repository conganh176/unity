using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts
{
    public abstract class Employee : MonoBehaviour
    {
        public static string company = "HQ";
        public string employeeName;

        public abstract void CalculateMonthlySalary();
    }
}
