using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;

namespace Assets.Scripts.ServerResponseHandlers
{
    class PlayerConnectedHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            ourGLM.getUserInterface().alterOnlinePlayerText(anObjectIn.GetUtfString("PlayerName"));
        }
    }
}
