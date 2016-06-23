using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.Scripts.ButtonEventHandlers
{
    class EnterChatButtonHandler : ButtonEventHandler
    {
        public void performClickAction(GameLobbyManager ourGLM, Button clickedButton)
        {
            ourGLM.getPlayerActionDictionary()["EnterChat"].performAction(ourGLM);
        }
    }
}
