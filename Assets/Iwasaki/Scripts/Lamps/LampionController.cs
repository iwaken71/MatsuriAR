using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Iwaken
{
    public class LampionController : MonoBehaviour
    {
        [SerializeField] MeshRenderer meshRenderer;
        LampsMaterials materialResource;

        public LampionColor currentColor { private set; get; }
        //public string na,e

        int LampId;

        public void SetUpId(int id)
        {
            LampId = id;
        }
        public int GetId()
        {
            return LampId;
        }

        void Awake()
        {
            materialResource = LampsMaterials.Instance;
        }

        public void ChangeColor(LampionColor color)
        {
            currentColor = color;
            meshRenderer.material = materialResource.lampionMaterials.Where(l => color == l.color).Select(l => l.material).First();
        }
    }

    [System.Serializable]
    public enum LampionColor
    {
        Gray = 0,
        Red = 1,
        Blue = 2,
        Green = 3
    }
}