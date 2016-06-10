using Sfs2X.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ServerResponseHandlers
{
    public interface ServerResponseHandler
    {
        void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM);
    }
}
