using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Iwaken
{
    public class LampsManager : SingletonMonoBehaviour<LampsManager>
    {
        [SerializeField] LampionController[] controllers;

        void Initialize()
        {

        }
        void SetAllId()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                controllers[i].SetUpId(i);
            }
        }

    }
}