using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using KanKikuchi.AudioManager;

namespace Iwaken
{
    public class ExplanationScreenPresenter : UIScreenBase
    {
        public override ScreenState state => ScreenState.Explanation;
        [SerializeField] Button cancelButton;

        ExplanationPanelController[] controllers;
        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            cancelButton.OnClickAsObservable().Subscribe(_ => { Move(ScreenState.LightFire); }).AddTo(this);
            controllers = GetComponentsInChildren<ExplanationPanelController>();
        }

        public override void OnOpenPanel()
        {
            base.OnOpenPanel();
            ActivatePanel(LampsManager.Instance.selectedLamp.currentColor);
        }

        void ActivatePanel(LampionColor color)
        {
            foreach (var controller in controllers)
            {
                if (controller.color == color)
                {
                    controller.Activate(true);
                }
                else
                {
                    controller.Activate(false);
                }
            }
        }
    }
}