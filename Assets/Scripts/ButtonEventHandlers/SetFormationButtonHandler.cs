using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonEventHandlers
{
    class SetFormationButtonHandler : ButtonEventHandler
    {
        public void performClickAction(GameLobbyManager ourGLM)
        {
            ourGLM.getGameManager().drawHexGrid(5);
        }
    }
}
