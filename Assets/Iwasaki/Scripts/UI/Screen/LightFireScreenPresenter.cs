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
                ClickLamp();
            });
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(2))
            {
                ClickLamp();
            }
        }

        void ClickLamp()
        {
            if (LampsManager.Instance.selectedLamp == null)
            {
                return;
            }
            else if (LampsManager.Instance.selectedLamp.currentColor == LampionColor.Gray)
            {
                UIManager.Instance.MoveScreen(ScreenState.Question);

            }
            else
            {
                UIManager.Instance.MoveScreen(ScreenState.Explanation);
            }

        }
    }
}