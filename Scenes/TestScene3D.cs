using Godot;
using System;

public partial class TestScene3D : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (@event is InputEventKey eventKey)
		{
            if (eventKey.Keycode == Key.Space)
            {
				GD.Print("AAAAA");
				AudioStreamPlayer player = (AudioStreamPlayer)GetNode("ASP");
				player.Play();
            }
		}


	}
}

