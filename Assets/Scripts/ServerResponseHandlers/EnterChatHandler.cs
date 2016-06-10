using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using UnityEngine;

namespace Assets.Scripts.ServerResponseHandlers
{
    class EnterChatHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            Debug.Log(anObjectIn.GetUtfString("ChatText"));
        }
    }
}
