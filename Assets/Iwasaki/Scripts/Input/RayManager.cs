using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UniRx;

namespace Iwaken
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class RayManager : SingletonMonoBehaviour<RayManager>
    {

        ARRaycastManager raycastManager;
        List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

        public BoolReactiveProperty isCasted;

        // Start is called before the first frame update
        void Start()
        {
            isCasted = new BoolReactiveProperty(false);

        }

        // Update is called once per frame
        void Update()
        {



#if UNITY_EDITOR
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#else
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
#endif

            RaycastHit hit;
            // レイと検出平面が衝突時
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<LampionController>())
                {
                    LampsManager.Instance.SelectLamp(hit.collider.GetComponent<LampionController>());
                    isCasted.Value = true;
                    return;
                }
            }
            isCasted.Value = false;

        }
    }
}