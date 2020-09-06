using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Iwaken
{
    public class ObjectModePresenter : MonoBehaviour
    {
        [SerializeField] Image outsideImage, houseImage;
        [SerializeField] Sprite selectedOutsideSprite, nonSelectedOutsideSprite, selectedHouseSprite, nonSelectedHouseSprite;

        [SerializeField] Button modeButton;

        void Start()
        {
            LampsManager.Instance.isHouseMode.Subscribe(HouseMode =>
            {
                SetView(HouseMode);
            });
            modeButton.OnClickAsObservable().Subscribe(_ =>
            {
                LampsManager.Instance.isHouseMode.Value = !LampsManager.Instance.isHouseMode.Value;
            });
        }



        void SetView(bool isHouseMode)
        {
            if (isHouseMode)
            {
                houseImage.sprite = selectedHouseSprite;
                outsideImage.sprite = nonSelectedOutsideSprite;
            }
            else
            {
                houseImage.sprite = nonSelectedHouseSprite;
                outsideImage.sprite = selectedOutsideSprite;
            }
        }
    }
}