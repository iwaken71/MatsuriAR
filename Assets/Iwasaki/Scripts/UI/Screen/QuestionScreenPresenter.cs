﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Iwaken
{
    public class QuestionScreenPresenter : UIScreenBase
    {
        public override ScreenState state => ScreenState.Question;
        [SerializeField] Button lightFireButton, cancelButton;
        [SerializeField] QuestionListPresenter listPresenter;
        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            lightFireButton.OnClickAsObservable().Subscribe(_ =>
            {
                LampsManager.Instance.FireSelectedLamp(listPresenter.currentColor);
                Move(ScreenState.LightFire);
            }
            ).AddTo(this);
            cancelButton.OnClickAsObservable().Subscribe(_ => { Move(ScreenState.LightFire); }).AddTo(this);
        }
    }
}