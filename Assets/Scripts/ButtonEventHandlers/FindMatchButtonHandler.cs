using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.Scripts.ButtonEventHandlers
{
    class FindMatchButtonHandler : ButtonEventHandler
    {
        public void performClickAction(GameLobbyManager ourGLM, Button clickedButton)
        {
            ourGLM.getSFServer().Send(new ExtensionRequest("JoinQueue", new SFSObject()));
        }
    }
}
