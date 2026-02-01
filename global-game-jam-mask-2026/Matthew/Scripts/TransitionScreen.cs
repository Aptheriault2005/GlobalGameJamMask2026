using Godot;
using System.Threading.Tasks;

public partial class TransitionScreen : CanvasLayer
{
	
	private AnimationPlayer ap;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ap = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public async Task Transition(string scene){
		ap.Play("FadeOut");
		await ToSignal(ap, AnimationPlayer.SignalName.AnimationFinished);
		GetTree().ChangeSceneToFile(scene);
		ap.Play("FadeIn");
	}
	
}
