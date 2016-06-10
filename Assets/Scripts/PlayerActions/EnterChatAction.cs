using Assets.Scripts.GameWorld.PlayerActions;
using Sfs2X.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Sfs2X.Entities.Data;

namespace Assets.Scripts.PlayerActions
{
    class EnterChatAction : PlayerAction
    {
        private ISFSObject objectOut;

        public void performAction(GameLobbyManager ourGLM)
        {
            objectOut = new SFSObject();
            InputField chatField = GameObject.Find("EnterChatField").GetComponent<InputField>();

            string chatText = chatField.text;

            //Build and send request to Game Server
            objectOut.PutUtfString("ChatText", chatText);
            ourGLM.getSFServer().Send(new ExtensionRequest("EnterChat", objectOut));
            
            //Blank out ChatTextField
            chatField.text = "";

        }
    }
}
