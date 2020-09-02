using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Iwaken
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        [SerializeField] UIScreenBase[] screenBases;

        void Start()
        {
            Initialize();
        }
        void Initialize()
        {
            MoveScreen(ScreenState.LightFire);
        }
        public void AddScreen(ScreenState state)
        {
            screenBases.Where(screen => screen.state == state).First().SetActive(true);
        }
        public void MoveScreen(ScreenState state)
        {
            ClearAllScreen();
            AddScreen(state);
        }

        public void ClearAllScreen()
        {
            foreach (var screen in screenBases)
            {
                screen.SetActive(false);
            }

        }
    }
}