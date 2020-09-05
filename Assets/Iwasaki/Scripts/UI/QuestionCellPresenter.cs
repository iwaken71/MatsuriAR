using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
namespace Iwaken
{
    [RequireComponent(typeof(QuestionCellView))]
    public class QuestionCellPresenter : MonoBehaviour
    {
        QuestionCellModel model;
        [SerializeField] QuestionCellView view;
        public bool isSelected { private set; get; }
        [SerializeField] LampionColor color;

        void Awake()
        {
            view = GetComponent<QuestionCellView>();
            model = new QuestionCellModel(isSelected, color);
        }

        public void ActiveSelect(bool isSelected)
        {
            this.isSelected = isSelected;
            view.SetSelected(isSelected);
        }

        public LampionColor GetColor()
        {
            return model.color;
        }

        public IObservable<Unit> OnClick => view.CellButton.OnClickAsObservable();
    }

    [System.Serializable]
    public class QuestionCellModel
    {
        public bool isSelected;

        public LampionColor color;

        public QuestionCellModel(bool isSelected, LampionColor color)
        {
            this.isSelected = isSelected;
            this.color = color;
        }
    }
}
