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
        private Dictionary<string, Text> onlinePlayerDictionary;
        private List<Text> chatTextLabel;

        public UIManager(GameLobbyManager gLM)
        {
            ourGLM = gLM;

            //Setup ButtonEventHandlers
            buttonDictionary.Add((Button)GameObject.Find("FindMatchButton").GetComponent<Button>(), new FindMatchButtonHandler());
            buttonDictionary.Add((Button)GameObject.Find("SetFormationButton").GetComponent<Button>(), new SetFormationButtonHandler());
            buttonDictionary.Add((Button)GameObject.Find("EnterChatButton").GetComponent<Button>(), new EnterChatButtonHandler());
            
            chatTextLabel = new List<Text>();
            onlinePlayerDictionary = new Dictionary<string, Text>();
        }
        public void alterOnlinePlayerText(string playerName)
        {
            //Define variables
            GameObject onlinePlayerBox = GameObject.Find("OnlinePlayerContent");

            //Check if the player exists, that means we need to remove it
            if(onlinePlayerDictionary.Keys.Contains(playerName))
            {
                ourGLM.destroyObject(playerName + " Text Label");
                onlinePlayerDictionary.Remove(playerName);
            }
            else
            { 
                onlinePlayerDictionary.Add(playerName, ourGLM.createObject("UI/ChatText").GetComponent<Text>());
                onlinePlayerBox.GetComponent<RectTransform>().sizeDelta = new Vector2(0, onlinePlayerDictionary.Count * 20);

                onlinePlayerDictionary[playerName].name = playerName + " Text Label";
                onlinePlayerDictionary[playerName].text = playerName;
                onlinePlayerDictionary[playerName].rectTransform.SetParent(onlinePlayerBox.GetComponent<RectTransform>());

            }
            //Update position of all PlayerNames
            int i = 0;
            foreach(string key in onlinePlayerDictionary.Keys)
            {
                onlinePlayerDictionary[key].rectTransform.offsetMin = new Vector2(9, -5 + i * 20);
                onlinePlayerDictionary[key].rectTransform.offsetMax = new Vector2(0, 15 + i * 20);
                //onlinePlayerDictionary[key].rectTransform.localPosition = new Vector2(0, i * 20);
                i++;
            }
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
