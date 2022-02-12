using FantasyCiv;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

//Retrieved from https://community.monogame.net/t/simple-2d-camera/9135
public class Camera
{

    public float Zoom { get; set; }
    public Vector2 Position { get; set; }
    public Rectangle Bounds { get; protected set; }
    public Rectangle VisibleArea { get; protected set; }
    public Matrix Transform { get; protected set; }

    private Viewport viewport;

    private float currentMouseWheelValue, previousMouseWheelValue, zoom, previousZoom;

    private float MAXVER = 1500;

    private float MAXHOR = 1500;

    public Camera(Viewport viewport)
    {
        Bounds = viewport.Bounds;
        Zoom = 1f;
        Position = new Vector2(400,260);
        viewport = viewport;
    }



    private void UpdateVisibleArea()
    {
        var inverseViewMatrix = Matrix.Invert(Transform);

        var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
        var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
        var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
        var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);

        var min = new Vector2(
            MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
            MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
        var max = new Vector2(
            MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
            MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
        VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
    }

    private void UpdateMatrix()
    {
        Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateScale(Zoom) *
                Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
        UpdateVisibleArea();
    }

    public void MoveCamera(Vector2 movePosition)
    {
        Vector2 newPosition = Position + movePosition;

        if( newPosition.X > MAXHOR)
        {
            newPosition.X = MAXHOR;
        }
        if (newPosition.X < 0)
        {
            newPosition.X = 0;
        }
        if (newPosition.Y > MAXVER)            //TODO maak afhankelijk
        {
            newPosition.Y = MAXVER;
        }
        else if(newPosition.Y < 0)
        {
            newPosition.Y = 0;
        }
        Position = newPosition;
    }

    public void AdjustZoom(float zoomAmount)
    {
        Zoom += zoomAmount;
        if (Zoom < .4f)
        {
            Zoom = .4f;
        }
        if (Zoom > 2f)
        {
            Zoom = 2f;
        }
    }

    public void UpdateCamera(Viewport bounds)
    {
        Bounds = bounds.Bounds;
        UpdateMatrix();

        int moveSpeed;
        cameraMove();
        cameraZoom();
    }

    private void cameraMove()
    {

        // mouse state logic (get the current state of the mouse)
        MouseState mouseState = Mouse.GetState();
        Vector2 cameraMovement = Vector2.Zero;
        int middleX = this.Bounds.Width / 2 ;
        int middleY = this.Bounds.Height / 2;
        if (Math.Abs((mouseState.X - middleX)) > 200 || Math.Abs((mouseState.Y - middleY)) > 200)
        {
            cameraMovement.X = (mouseState.X - middleX) / 50;
            cameraMovement.Y = (mouseState.Y - middleY) / 30;
        }
        MoveCamera(cameraMovement);

    }

    private void cameraZoom()
    {
        //scroll zoom
        previousMouseWheelValue = currentMouseWheelValue;
        currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;
        if (currentMouseWheelValue > previousMouseWheelValue)
        {
            AdjustZoom(.05f);
        }

        if (currentMouseWheelValue < previousMouseWheelValue)
        {
            AdjustZoom(-.05f);
        }
    }

    public Vector2 ScreenToWorldSpace(Vector2 point)
    {
        Matrix invertedMatrix = Matrix.Invert(Transform);
        return Vector2.Transform(point, invertedMatrix);
    }
}