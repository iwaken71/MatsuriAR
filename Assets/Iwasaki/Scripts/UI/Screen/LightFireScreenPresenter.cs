using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Iwaken
{
    public class LightFireScreenPresenter : UIScreenBase
    {
        public override ScreenState state => ScreenState.LightFire;

        [SerializeField] Button FireButton;
        [SerializeField] Image FireImage;

        void Start()
        {
            RayManager.Instance.isCasted.Subscribe(casted =>
            {
                if (casted)
                {
                    FireImage.enabled = true;
                    FireButton.enabled = true;

                }
                else
                {
                    FireImage.enabled = false;
                    FireButton.enabled = false;
                }
            });


            FireButton.OnClickAsObservable().Subscribe(_ =>
            {
                UIManager.Instance.MoveScreen(ScreenState.Question);
            });
        }
    }
}