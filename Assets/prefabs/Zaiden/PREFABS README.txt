PREFABS README
#GameManager 
	updates hero position in scene
	calls create_new_chunk from chunk manager
	handles user clicks to make new platforms
	communicates with platform manager and chunk manager
#UserPlatformManager
	receives and processes user input related to platform creation.
	creates and managers all platforms in the game.
	will undergo massive overhauls soon
#fallPlatform
	is what is instantiated for a falling platform
	will have Falling.cs script attached soon
#floatPlatform
	is what is instantiated for a floating platform
	no rigid body
	will have Floating.cs script attached soon
#PreviewPlatform
	is what is instantiated for a preview platform
	no rigid body
	will have Preview.cs attached soon
	