using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonEventHandlers
{
    class EnterChatButtonHandler : ButtonEventHandler
    {
        public void performClickAction(GameLobbyManager ourGLM)
        {
            ourGLM.getPlayerActionDictionary()["EnterChat"].performAction(ourGLM);
        }
    }
}
