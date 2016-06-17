using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonEventHandlers
{
    class EditFormationButtonHandler : ButtonEventHandler
    {
        public void performClickAction(GameLobbyManager ourGLM)
        {
            ourGLM.getSFServer().Send(new ExtensionRequest("EditFormation", new SFSObject()));
        }
    }
}
