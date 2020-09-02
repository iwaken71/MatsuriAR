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
            meshRenderer.material = materialResource.lampionMaterials.Where(l => color == l.color).Select(l => l.material).First();
        }
        void Update()
        {
            if (Input.GetKeyDown("1"))
            {
                ChangeColor(LampionColor.Gray);

            }
            if (Input.GetKeyDown("2"))
            {
                Debug.Log("2");
                ChangeColor(LampionColor.Red);
            }
            if (Input.GetKeyDown("3"))
            {
                ChangeColor(LampionColor.Blue);
            }
            if (Input.GetKeyDown("4"))
            {
                ChangeColor(LampionColor.Green);
            }
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