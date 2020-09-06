using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Iwaken
{
    public class LampsManager : SingletonMonoBehaviour<LampsManager>
    {
        [SerializeField] Transform lampRoot;
        LampionController[] controllers;
        public LampionController selectedLamp { private set; get; }

        [SerializeField] GameObject teraObject;
        public BoolReactiveProperty isHouseMode;

        void Awake()
        {
            base.Awake();
            Initialize();
        }
        void Initialize()
        {

            isHouseMode = new BoolReactiveProperty(true);

            isHouseMode.Subscribe(houseMode =>
            {
                Debug.Log(houseMode);
                teraObject.SetActive(houseMode);
            });
            controllers = lampRoot.GetComponentsInChildren<LampionController>();
            ApplyAllLampColor(LampionColor.Gray);
        }
        public void SwitchHouseMode()
        {

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