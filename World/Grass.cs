using Godot;
using Microsoft.VisualBasic;
using System;

public partial class Grass : Node2D
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Attack")){
			
			PackedScene grassEffect = GD.Load<PackedScene>("res://Effects/grass_effect.tscn");
			Node2D effectInstance = (Node2D)grassEffect.Instantiate();
			Node world = GetTree().CurrentScene;
       		world.AddChild(effectInstance);
			effectInstance.GlobalPosition = GlobalPosition;
			QueueFree();
		}
	}


	
}


