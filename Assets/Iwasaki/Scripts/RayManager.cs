using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Iwaken
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class RayManager : MonoBehaviour
    {

        ARRaycastManager raycastManager;
        List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // レイと検出平面が衝突時
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.GetComponent<LampionController>())
                    {
                        hit.collider.GetComponent<LampionController>().ChangeColor(LampionColor.Red);
                    }
                }
            }
        }
    }
}