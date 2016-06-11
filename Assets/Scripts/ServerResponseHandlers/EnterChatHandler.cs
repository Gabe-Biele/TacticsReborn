using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ServerResponseHandlers
{
    class EnterChatHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            //Define variables
            GameObject chatBox = GameObject.Find("ChatContent");
            List<Text> chatTextList = ourGLM.getUserInterface().getChatTextLabel();

            chatTextList.Add(ourGLM.createObject("UI/ChatText").GetComponent<Text>());
            chatBox.GetComponent<RectTransform>().sizeDelta = new Vector2(0, chatTextList.Count * 20);

            //Determine the Y-Position for the Chat Content rect to look at
            int posY;
            if(chatBox.GetComponent<RectTransform>().rect.height > 250) posY = (int)chatBox.GetComponent<RectTransform>().rect.height - 250;
            else posY = 0;

            //Update ChatContent position
            chatBox.GetComponent<RectTransform>().localPosition = new Vector2(0, posY);

            //Create new Chat Messag to display
            chatTextList.Last().name = "ChatTextLabel " + chatTextList.Count;
            chatTextList.Last().text = anObjectIn.GetUtfString("ChatText");
            chatTextList.Last().rectTransform.SetParent(chatBox.GetComponent<RectTransform>());

            //Update position of all chat messages
            for(int i = 0; i < chatTextList.Count; i++)
            {
                chatTextList[i].rectTransform.offsetMin = new Vector2(9, -25 + (chatTextList.Count-i) * 20);
                chatTextList[i].rectTransform.offsetMax = new Vector2(0, -5 + (chatTextList.Count-i) * 20);
            }
        }
    }
}
