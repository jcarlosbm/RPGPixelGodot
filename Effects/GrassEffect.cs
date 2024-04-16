using Godot;
using System;

public partial class GrassEffect : Node2D
{
	AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite.Play("Animated");
	}


private void _on_animated_sprite_2d_animation_finished()
{
		QueueFree();
}
}
