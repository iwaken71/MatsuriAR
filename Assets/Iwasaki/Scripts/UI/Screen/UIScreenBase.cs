using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iwaken
{
    public class UIScreenBase : MonoBehaviour
    {
        public virtual ScreenState state => ScreenState.None;
        public void SetActive(bool active)
        {
            foreach (var ui in GetComponentsInChildren<RectTransform>(true))
            {
                ui.gameObject.SetActive(active);
            }
        }

        protected void Move(ScreenState state)
        {
            UIManager.Instance.MoveScreen(state);
        }
    }
}