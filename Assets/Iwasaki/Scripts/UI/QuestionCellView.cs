using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Iwaken
{
    public class QuestionCellView : MonoBehaviour
    {
        [SerializeField] Button cellButton;
        public Button CellButton => cellButton;

        [SerializeField] ButtonSprite SelectedSprite;
        [SerializeField] ButtonSprite NoSeletedSprite;

        [SerializeField] Image center, waku;

        public void SetSelected(bool isSeleced)
        {
            if (isSeleced)
            {
                center.sprite = SelectedSprite.center;
                waku.sprite = SelectedSprite.waku;
            }
            else
            {
                center.sprite = NoSeletedSprite.center;
                waku.sprite = NoSeletedSprite.waku;
            }
        }
    }
    [System.Serializable]
    public class ButtonSprite
    {
        public Sprite center;
        public Sprite waku;


    }
}