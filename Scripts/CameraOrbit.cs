using Godot;
using System;

public partial class CameraOrbit : Camera3D
{

	private Vector2 movement;
	private double elapsed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		elapsed += delta;
		Position += this.GlobalTransform.Basis.Z *(0.25f * (float)Mathf.Sin(elapsed));
	}

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

		if (@event is InputEventKey eventKey)
        {
			int x = 0;

			switch (eventKey.Keycode)
			{
				case Key.W:
					{
						movement.X += Convert.ToInt32(eventKey.Pressed);

					}
					break;
				case Key.S:
					{
						movement.X -= Convert.ToInt32(eventKey.Pressed);
					}
					break;
				default:
					break;
			}
			movement.X = x;
		}
		
  
    }
}
