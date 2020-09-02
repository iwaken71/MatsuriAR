using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Iwaken
{
    public class QuestionScreenPresenter : UIScreenBase
    {
        public override ScreenState state => ScreenState.Question;
        [SerializeField] Button cancelButton;
        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            cancelButton.OnClickAsObservable().Subscribe(_ => { Move(ScreenState.LightFire); }).AddTo(this);
        }
    }
}