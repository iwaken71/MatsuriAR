using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iwaken
{
    public class LampsMaterials : SingletonMonoBehaviour<LampsMaterials>
    {
        public LampionMaterial[] lampionMaterials;
    }
    [System.Serializable]
    public class LampionMaterial
    {
        public LampionColor color;
        public Material material;
    }
}
