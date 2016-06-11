using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;

namespace Assets.Scripts.ServerResponseHandlers
{
    class OnlinePlayersHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            foreach(string playerName in anObjectIn.GetUtfStringArray("PlayerNameArray"))
            {
                ourGLM.getUserInterface().alterOnlinePlayerText(playerName);
            }
        }
    }
}
