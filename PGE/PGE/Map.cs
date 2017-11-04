﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// 
    /// </summary>
    class Map
    {
        /// <summary>
        /// Height (tiles).
        /// </summary>
        private int _height;

        /// <summary>
        /// Graphics context to draw to.
        /// </summary>
        private Graphics canvas;

        /// <summary>
        /// 
        /// </summary>
        private int[,] map;

        /// <summary>
        /// Width (tiles).
        /// </summary>
        private int _width;

        /// <summary>
        /// Accessor to `_height`.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Accessor to `_width`.
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="ts">Source TileSet</param>
        public Map(Graphics g, int[,] tiles, int mapSize)
        {
            _height = mapSize;
            _width = mapSize;
            canvas = g;
            map = tiles;
        }

        public void Draw()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    Color cellColor = GetCellColor(column, row);
                    SolidBrush cellBrush = new SolidBrush(cellColor);
                    canvas.FillRectangle(cellBrush, column, row, 4, 4);
                }
            }
        }

        public Color GetCellColor(int column, int row)
        {
            if (column >= Width)
            {
                column -= Width;
            }

            if (column < 0)
            {
                column += Width;
            }

            if (row >= Height)
            {
                row -= Height;
            }

            if (row < 0)
            {
                row += Height;
            }

            int tileType = map[row, column];
            int red = 0;
            int green = 0;
            int blue = 0;

            int steps = 15;
            int max = 255;
            int stepSize = max / steps;

            int g = tileType / stepSize;
            g *= steps;
            red = g;
            green = g;
            blue = g;

            if (tileType < 32)
            {
                blue = 127 + (tileType * 2);
                green = 127 + (tileType * 2);
            }

            Color cellColor = Color.FromArgb(255, red, green, blue);

            return cellColor;
        }
    }
}