using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Iwaken
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        [SerializeField] UIScreenBase[] screenBases;
        public ScreenState currentScreen { private set; get; }

        void Start()
        {
            Initialize();
        }
        void Initialize()
        {
            MoveScreen(ScreenState.LightFire);
            currentScreen = ScreenState.LightFire;
        }
        void AddScreen(ScreenState state)
        {
            if (!ContainScreen(state))
            {
                return;
            }
            var addScreen = screenBases.Where(screen => screen.state == state).First();
            addScreen.SetActive(true);
            currentScreen = state;
            addScreen.OnOpenPanel();
        }
        public void MoveScreen(ScreenState state)
        {
            if (!ContainScreen(state))
            {
                return;
            }
            ClearAllScreen();
            AddScreen(state);
        }
        bool ContainScreen(ScreenState state)
        {
            return screenBases.Count(screen => screen.state == state) > 0;
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