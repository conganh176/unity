using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommandPattern.Practicals
{
    public class CommandManager : MonoBehaviour
    {
        private static CommandManager _instance;
        public static CommandManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Command Manager is null");

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        private List<ICommand> _commandBuffer = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commandBuffer.Add(command);
        }

        public void Rewind()
        {
            StartCoroutine(RewindRoutine());
        }

        IEnumerator RewindRoutine()
        {
            Debug.Log("Rewinding");
            foreach(var command in Enumerable.Reverse(_commandBuffer))
            {
                command.Undue();
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("Finish");
        }

        public void Play()
        {
            StartCoroutine(PlayRoutine());
        }

        IEnumerator PlayRoutine()
        {
            Debug.Log("Playing");
            foreach (var command in _commandBuffer)
            {
                command.Execute();
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("Finish");
        }
    }
}
