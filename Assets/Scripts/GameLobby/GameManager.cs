using Assets.Scripts.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameLobby
{
    public class GameManager
    {
        GameLobbyManager ourGLM;

        public GameManager(GameLobbyManager gLM)
        {
            ourGLM = gLM;
        }
        public Vector3 getLocation(int x, int y)
        {
            //Setup x and y position variabes
            float xPos = 0;
            float yPos = 0;

            //Calculate Basic Offsets
            xPos = 1.73f * x;
            yPos = 1.5f * y;

            //Determine Row Shift
            if(y % 2 != 0) xPos += 0.866f;

            return new Vector3(xPos, 0, yPos);
        }
        public void drawHexGrid(int maxHeight)
        {

            float xPos = 0;
            float yPos = 0;
            for(int y = 0; y < maxHeight; y++)
            {
                //Determine the shift
                if(y % 2 != 0) xPos = 0.866f;
                else xPos = 0;

                for(int x = 0; x < 12; x++)
                {
                    GameObject aDumHex = ourGLM.createObject("hexagon");
                    aDumHex.transform.localPosition = new Vector3(xPos, 0, yPos);
                    aDumHex.transform.SetParent(GameObject.Find("HexGrid").transform);
                    aDumHex.transform.GetChild(0).gameObject.AddComponent<HexTileController>();
                    aDumHex.name = "Hex " + x + "-" + y;

                    xPos += 1.73f;
                }
                yPos += 1.5f;
            }
        }
    }
}
