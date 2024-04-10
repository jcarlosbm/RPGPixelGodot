using System;
using Godot;

public partial class Player : CharacterBody2D
{
	//private int speed = 3;
	private const int MAXSPEED = 80;
	private const int ACCELERATION = 400;
	private const int FRICTION = 500; 
	Vector2 velocity = new Vector2(0,0);
	private AnimationPlayer animationPlayer;
	private AnimationTree animationTree;
	private AnimationNodeStateMachinePlayback animationNodeStateMachinePlayback;


    public override void _Ready()
    {
        base._Ready();
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationTree = GetNode<AnimationTree>("AnimationTree");
		animationNodeStateMachinePlayback = (AnimationNodeStateMachinePlayback) animationTree.Get("parameters/playback");

		GD.Print("Player listo");
    }
    public override void _PhysicsProcess(double delta)
    {

        Vector2 inputVector = new Vector2(0, 0)
        {
            X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"),
            Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up")
        };
		inputVector = inputVector.Normalized();

		if (inputVector != Vector2.Zero){

			animationTree.Set("parameters/Idle/blend_position", inputVector);
			animationTree.Set("parameters/Run/blend_position", inputVector);

			animationNodeStateMachinePlayback.Travel("Run");
			velocity = velocity.MoveToward(inputVector * MAXSPEED, ACCELERATION * (float)delta);
			Velocity = velocity;

		}else{
			animationNodeStateMachinePlayback.Travel("Idle");
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION * (float)delta);
			Velocity = velocity;

		}

		 MoveAndSlide();
    
	}
}


