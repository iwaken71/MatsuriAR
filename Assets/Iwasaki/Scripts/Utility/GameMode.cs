using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Iwaken
{
    public static class GameModeState
    {
        public static GameMode mode;

        static GameModeState()
        {
            mode = GameMode.House;
        }

    }

    public enum GameMode
    {
        House,
        Select

    }
}