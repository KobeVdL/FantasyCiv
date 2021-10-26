﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.MainComponents
{
    static class Camera
    {




        // Centered Position of the Camera in pixels.
        public static Vector2 Position { get; private set; }
        // Current Zoom level with 1.0f being standard
        public static float Zoom { get; private set; } = 1f;
        // Current Rotation amount with 0.0f being standard orientation
        public static float Rotation { get; private set; }

        // Height and width of the viewport window which we need to adjust
        // any time the player resizes the game window.
        public static int ViewportWidth { get; set; }
        public static int ViewportHeight { get; set; }

        // Center of the Viewport which does not account for scale
        public static Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f);
            }
        }

        // Create a matrix for the camera to offset everything we draw,
        // the map and our objects. since the camera coordinates are where
        // the camera is, we offset everything by the negative of that to simulate
        // a camera moving. We also cast to integers to avoid filtering artifacts.
        public static Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-(int)Position.X,
                   -(int)Position.Y, 0) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                   Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
            }
        }

        // Call this method with negative values to zoom out
        // or positive values to zoom in. It looks at the current zoom
        // and adjusts it by the specified amount. If we were at a 1.0f
        // zoom level and specified -0.5f amount it would leave us with
        // 1.0f - 0.5f = 0.5f so everything would be drawn at half size.
        public static void AdjustZoom(float amount)
        {
            Zoom += amount;
            if (Zoom < 0.25f)
            {
                Zoom = 0.25f;
            }
        }

        public static Rectangle ViewportWorldBoundry()
        {
            Vector2 viewPortCorner = ScreenToWorld(new Vector2(0, 0));
            Vector2 viewPortBottomCorner =
               ScreenToWorld(new Vector2(ViewportWidth, ViewportHeight));

            return new Rectangle((int)viewPortCorner.X,
               (int)viewPortCorner.Y,
               (int)(viewPortBottomCorner.X - viewPortCorner.X),
               (int)(viewPortBottomCorner.Y - viewPortCorner.Y));
        }

        // Center the camera on specific pixel coordinates
        public static void CenterOn(Vector2 position)
        {
            Position = position;
        }



        public static Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, TranslationMatrix);
        }

        public static Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition,
                Matrix.Invert(TranslationMatrix));
        }

        // Move the camera's position based on input
        public static void HandleInput(KeyboardState inputState)
        {
            Vector2 cameraMovement = Vector2.Zero;


            if (inputState.IsKeyDown(Keys.Z))
            {
                AdjustZoom(0.01f);
            }
            else if (inputState.IsKeyDown(Keys.S))
            {
                AdjustZoom(-0.01f);
            }

            // When using a controller, to match the thumbstick behavior,
            // we need to normalize non-zero vectors in case the user
            // is pressing a diagonal direction.
            if (cameraMovement != Vector2.Zero)
            {
                cameraMovement.Normalize();
            }

            // scale our movement to move 25 pixels per second
            cameraMovement *= 25f;

        }

        public static float getScale()
        {
            return Camera.Zoom;
        }

    }


}
