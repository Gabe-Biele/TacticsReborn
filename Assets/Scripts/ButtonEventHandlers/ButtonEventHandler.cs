using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.Scripts.ButtonEventHandlers
{
    public interface ButtonEventHandler
    {
        void performClickAction(GameLobbyManager ourGLM, Button clickedButton);
    }
}
