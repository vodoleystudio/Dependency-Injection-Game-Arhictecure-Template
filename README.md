# PangGame
==========

# Setup Boot scene ..\PangGame\Assets\Project\AppFrontendDomain\Scenes and play.
#	1 On desktop LeftArrow button for moving left, RightArrow button for moving right
#	2 On mobile use joystick

# BONUS : Levels with increased difficulty. 
#         I have choosed it, because the system developed with flexable levels infrustructure, that give possibility create quickly amount of variation of levels.

# You can build your own levels using Editor scene.
	
#	1 Go to ..\PangGame\Assets\Project\AppFrontendDomain\Prefabs\Levels.
#	2 Duplicate one of the levels.
#   3 Change name.
#	4 Set the exact name of prefab to Id field of LevelBase component that already attached to it.
#	5 Open Editor scene.
#	6 Grab the level prefab to Editor scene and do your level design. (You can also change paramteres of each obstacle or enemy like : Lives, Speed, etc)
#	7 Attach the new prefab to list of LevelsPrefabs in LevelsModuleSettings asset that located on ..\PangGame\Assets\Project\AppFrontendDomain\Settings