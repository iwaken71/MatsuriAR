using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iwaken
{
    public class ExplanationPanelController : MonoBehaviour
    {
        public LampionColor color;
        public void Activate(bool active)
        {
            foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(active);
            }
        }
    }
}