﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

using UnityEngine;

namespace Zenject.Asteroids
{
    public class LevelHelper
    {
        readonly Camera _camera;

        public LevelHelper(
            [Inject(Id = "Main")]
            Camera camera)
        {
            _camera = camera;
        }

        public float Bottom
        {
            get { return -ExtentHeight; }
        }

        public float Top
        {
            get { return ExtentHeight; }
        }

        public float Left
        {
            get { return -ExtentWidth; }
        }

        public float Right
        {
            get { return ExtentWidth; }
        }

        public float ExtentHeight
        {
            get { return _camera.orthographicSize; }
        }

        public float Height
        {
            get { return ExtentHeight * 2.0f; }
        }

        public float ExtentWidth
        {
            get { return _camera.aspect * _camera.orthographicSize; }
        }

        public float Width
        {
            get { return ExtentWidth * 2.0f; }
        }
    }
}

