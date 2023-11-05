using Godot;
using System;

public partial class ghost : Node3D
{
	private ShaderMaterial shaderMaterial;
	private double elapsed = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shaderMaterial = (ShaderMaterial)((MeshInstance3D)FindChild("Cube")).Mesh.SurfaceGetMaterial(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		elapsed += delta;
		shaderMaterial.SetShaderParameter("transparency", (float)Math.Abs(Math.Sin(elapsed)));
		//GD.Print((float)Math.Sin(elapsed));
	}
}
