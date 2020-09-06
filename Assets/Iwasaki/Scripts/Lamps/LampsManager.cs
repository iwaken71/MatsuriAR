using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Iwaken
{
    public class LampsManager : SingletonMonoBehaviour<LampsManager>
    {
        [SerializeField] LampionController[] controllers;
        public LampionController selectedLamp { private set; get; }

        void Start()
        {
            Initialize();
        }
        void Initialize()
        {
            ApplyAllLampColor(LampionColor.Gray);
        }
        void SetAllId()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                controllers[i].SetUpId(i);
            }
        }

        public void SelectLamp(LampionController controller)
        {
            this.selectedLamp = controller;
        }
        public void FireSelectedLamp(LampionColor color)
        {
            if (this.selectedLamp == null)
            {
                return;
            }
            this.selectedLamp.ChangeColor(color);
        }
        void ApplyAllLampColor(LampionColor color)
        {
            foreach (var lamps in controllers)
            {
                lamps.ChangeColor(color);
            }
        }
    }
}