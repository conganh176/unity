using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.Practicals
{
    public interface ICommand
    {
        void Execute();
        void Undue();
    }
}
