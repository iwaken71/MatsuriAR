using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
namespace Iwaken
{
    public class QuestionListPresenter : MonoBehaviour
    {
        QuestionCellPresenter[] presenters;
        public LampionColor currentColor { private set; get; }
        void Awake()
        {
            presenters = GetComponentsInChildren<QuestionCellPresenter>();
            foreach (var presenter in presenters)
            {
                if (presenter.isSelected)
                {
                    currentColor = presenter.GetColor();
                }
            }

            for (int i = 0; i < presenters.Length; i++)
            {
                var presenter = presenters[i];
                presenter.OnClick.Subscribe(_ =>
                {
                    var color = presenter.GetColor();
                    SetSelect(color);
                    Debug.Log(color);

                }).AddTo(presenter.gameObject);
            }
        }

        void SetSelect(LampionColor color)
        {
            foreach (var presenter in presenters)
            {
                if (color == presenter.GetColor())
                {
                    presenter.ActiveSelect(true);
                    currentColor = color;
                }
                else
                {
                    presenter.ActiveSelect(false);
                }
            }
        }
    }
}
