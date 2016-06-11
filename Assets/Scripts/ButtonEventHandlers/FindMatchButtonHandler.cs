using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonEventHandlers
{
    class FindMatchButtonHandler : ButtonEventHandler
    {
        public void performClickAction(GameLobbyManager ourGLM)
        {
            ourGLM.getGameManager().drawHexGrid(12);
        }
    }
}
