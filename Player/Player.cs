using System;
using Godot;

public partial class Player : CharacterBody2D
{
	//private int speed = 3;
	private const int MAXSPEED = 100;
	private const int ACCELERATION = 400;
	private const int FRICTION = 400; 
	Vector2 velocity = new Vector2(0,0);

    public override void _PhysicsProcess(double delta)
    {

        Vector2 inputVector = new Vector2(0, 0)
        {
            X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"),
            Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up")
        };
		inputVector = inputVector.Normalized();

		if (inputVector != Vector2.Zero){
			
			velocity = velocity.MoveToward(inputVector * MAXSPEED, ACCELERATION * (float)delta);
			Velocity = velocity;

		}else{
			//velocity = Vector2.Zero;
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION * (float)delta);
			Velocity = velocity;

		}

		 MoveAndSlide();
    
	}
}


