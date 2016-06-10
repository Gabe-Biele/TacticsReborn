using Assets.Scripts.ButtonEventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameLobby
{
    class UIManager
    {
        //Central Dependency
        GameLobbyManager ourGLM;

        private Dictionary<Button, ButtonEventHandler> buttonDictionary = new Dictionary<Button, ButtonEventHandler>();

        public UIManager(GameLobbyManager gLM)
        {
            //Setup ButtonEventHandlers
            buttonDictionary.Add((Button)GameObject.Find("PlayButton").GetComponent<Button>(), new PlayButtonHandler());
            buttonDictionary.Add((Button)GameObject.Find("EnterChatButton").GetComponent<Button>(), new EnterChatButtonHandler());

        }

        public Dictionary<Button, ButtonEventHandler> getButtonDictionary()
        {
            return buttonDictionary;
        }
    }
}
