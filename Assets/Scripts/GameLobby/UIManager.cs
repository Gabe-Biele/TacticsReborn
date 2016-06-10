using Assets.Scripts.ButtonEventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameLobby
{
    public class UIManager
    {
        //Central Dependency
        GameLobbyManager ourGLM;

        private Dictionary<Button, ButtonEventHandler> buttonDictionary = new Dictionary<Button, ButtonEventHandler>();
        private List<Text> chatTextLabel;

        public UIManager(GameLobbyManager gLM)
        {
            //Setup ButtonEventHandlers
            buttonDictionary.Add((Button)GameObject.Find("PlayButton").GetComponent<Button>(), new PlayButtonHandler());
            buttonDictionary.Add((Button)GameObject.Find("EnterChatButton").GetComponent<Button>(), new EnterChatButtonHandler());
            
            chatTextLabel = new List<Text>();
        }

        public Dictionary<Button, ButtonEventHandler> getButtonDictionary()
        {
            return buttonDictionary;
        }
        public List<Text> getChatTextLabel()
        {
            return chatTextLabel;
        }
    }
}
