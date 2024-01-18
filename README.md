# PangGame
==============================

# TUTORIAL:
	Setup Boot scene ..\PangGame\Assets\Project\AppFrontendDomain\Scenes and play.
	1 On the desktop LeftArrow button for moving left, RightArrow button for moving right
	2 On mobile use a joystick

# You can build your own levels using the Editor scene.
	
	1 Go to ..\PangGame\Assets\Project\AppFrontendDomain\Prefabs\Levels.
	2 Duplicate one of the levels.
	3 Change name.
	4 Set the exact name of the prefab to the Id field of the LevelBase component that is already attached to it.
	5 Open Editor scene.
	6 You can grab the level prefab to the Editor scene and do your level design. 
 	(You can also change parameters of each obstacle or enemy like Lives, Speed, etc)
	7 Attach the new prefab to the list of LevelsPrefabs in the LevelsModuleSettings asset, 
 	that is located on ..\PangGame\Assets\Project\AppFrontendDomain\Settings
