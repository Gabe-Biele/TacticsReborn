using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class HexTileController : MonoBehaviour
    {
        private Color baseHexColor;
        private Renderer tileRenderer;

        public HexTileController()
        {
            tileRenderer = GetComponent<Renderer>();
        }

        void OnMouseEnter()
        {
            baseHexColor = tileRenderer.material.color;
            tileRenderer.material.color = Color.cyan;
        }
        void OnMouseExit()
        {
            tileRenderer.material.color = baseHexColor;
        }
    }
}
