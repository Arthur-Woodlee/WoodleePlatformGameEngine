using System;

namespace Woodlee_Platform_Game_Engine
{
    public class Camera
    {
        // A Camera points at a Scene Object. A Camera follows a SceneObject as it moves around the scene.
        // A focus box is contained within a lens. A Scene Object is always contained in the focus box.
        private Microsoft.Xna.Framework.Rectangle _lens;
        private Microsoft.Xna.Framework.Rectangle _focusBox;
        private IRectangleSceneObject _subject;
        private Vector2 _endScene;
        public Camera(Microsoft.Xna.Framework.Rectangle lens, Microsoft.Xna.Framework.Rectangle focusBox, Vector2 endScene)
        {
            if (!lens.Contains(focusBox))
            {
                throw new Exception("Focus area must be contained within the Lens.");
            }
            _lens = lens;
            _focusBox = focusBox;
            _endScene = endScene;
        }
        public void Update()
        {
            if (_subject.GetPosition().Width > _focusBox.Width || _subject.GetPosition().Height > _focusBox.Height)
            {
                throw new Exception("Subject area must not exceed Focus Box Area.");
            }
            Rectangle positionToConvert = _subject.GetPosition();
            Microsoft.Xna.Framework.Rectangle position = new Microsoft.Xna.Framework.Rectangle(positionToConvert.X, positionToConvert.Y, positionToConvert.Width, positionToConvert.Height);
            if (!_focusBox.Contains(position))
            {
                if ((position.X + position.Width) > (_focusBox.X + _focusBox.Width))
                {
                    int cameraShiftX = (position.X + position.Width) - (_focusBox.X + _focusBox.Width);
                    ShiftLensPosition(cameraShiftX, 0);
                }
                if (position.X < _focusBox.X)
                {
                    int cameraShiftX = position.X - _focusBox.X;
                    ShiftLensPosition(cameraShiftX, 0);
                }
                if ((position.Y + position.Height) > (_focusBox.Y + _focusBox.Height))
                {
                    int cameraShiftY = (position.Y + position.Height) - (_focusBox.Y + _focusBox.Height);
                    ShiftLensPosition(0, cameraShiftY);
                }
                if (position.Y < _focusBox.Y)
                {
                    int cameraShiftY = position.Y - _focusBox.Y;
                    ShiftLensPosition(0, cameraShiftY);
                }
            }
        }
        private void ShiftLensPosition(int x, int y)
        {
            // TODO - the if only checks if the lens can be moved in the positive direction. There is no check as to whether it can be moved in the negative. The check is probably not neccessary.
            if ((_focusBox.X + _focusBox.Width) > (_endScene.X - (_focusBox.X - _lens.X)) || (_focusBox.Y + _focusBox.Height) > (_endScene.Y - (_focusBox.Y - _lens.Y)))
            {
                _focusBox = new Microsoft.Xna.Framework.Rectangle(_focusBox.X + x, _focusBox.Y + y, _focusBox.Width, _focusBox.Height);
            }
            else
            {
                _lens = new Microsoft.Xna.Framework.Rectangle(_lens.X + x, _lens.Y + y, _lens.Width, _lens.Height);
                _focusBox = new Microsoft.Xna.Framework.Rectangle(_focusBox.X + x, _focusBox.Y + y, _focusBox.Width, _focusBox.Height);
            }

        }
        public Microsoft.Xna.Framework.Rectangle GetDrawingPosition(Rectangle position)
        {
            int subjectLensPositionX;
            int subjectLensPositionY;
            Rectangle subjectPosition = _subject.GetPosition();
            if (_lens.X < 0)
            {
                subjectLensPositionX = subjectPosition.X;
            }
            else
            {
                subjectLensPositionX = subjectPosition.X - _lens.X;
            }
            if (_lens.Y < 0)
            {
                subjectLensPositionY = subjectPosition.Y;
            }
            else
            {
                subjectLensPositionY = subjectPosition.Y - _lens.Y;
            }
            int mapDistanceFromSubjectX = position.X - subjectPosition.X;
            int mapDistanceFromSubjectY = position.Y - subjectPosition.Y;

            int inputLensPositionX = subjectLensPositionX + mapDistanceFromSubjectX;
            int inputLensPositionY = subjectLensPositionY + mapDistanceFromSubjectY;

            return new Microsoft.Xna.Framework.Rectangle(inputLensPositionX, inputLensPositionY, position.Width, position.Height);
        }
        public Microsoft.Xna.Framework.Vector2 GetDrawingPosition(Vector2 point)
        {
            int subjectLensPositionX;
            int subjectLensPositionY;
            Rectangle subjectPosition = _subject.GetPosition();
            if (_lens.X < 0)
            {
                subjectLensPositionX = subjectPosition.X;
            }
            else
            {
                subjectLensPositionX = subjectPosition.X - _lens.X;
            }
            if (_lens.Y < 0)
            {
                subjectLensPositionY = subjectPosition.Y;
            }
            else
            {
                subjectLensPositionY = subjectPosition.Y - _lens.Y;
            }
            int mapDistanceFromSubjectX = point.X - subjectPosition.X;
            int mapDistanceFromSubjectY = point.Y - subjectPosition.Y;

            int inputLensPositionX = subjectLensPositionX + mapDistanceFromSubjectX;
            int inputLensPositionY = subjectLensPositionY + mapDistanceFromSubjectY;

            return new Microsoft.Xna.Framework.Vector2(inputLensPositionX, inputLensPositionY);
        }
        public void SetSubject(IRectangleSceneObject subject)
        {
            Rectangle position = subject.GetPosition();
            if (!_focusBox.Contains(new Microsoft.Xna.Framework.Rectangle(position.X, position.Y, position.Width, position.Height)))
            {
                throw new Exception("Subject must be contained within the Focus Area.");
            }
            if (position.Width > _focusBox.Width || position.Height > _focusBox.Height)
            {
                throw new Exception("Subject area must not exceed Focus Box Area.");
            }
            _subject = subject;
        }
    }
}
