# Throwing project for Oculus Quest (Port) 

Unity Version: 2019.1.1f1
If you want to make any changes you will most likely use these three scripts.

- LevelDifficuly.cs
- Gameplay.cs
- TutorialManager.cs

Most changes you will want to make are in the inspector window. Such as:

- total practice throws
- Target distance modifier
- Target size modifier
- total throws allowed per level

Saved Data will be located at:<br/> 
*PC\Quest\Internal shared storage\Android\data\com.regamevrlab.ThrowAtTargetClassroomNovemberBuildNew\files*

Remember to restart your Oculus Quest after a session otherwise the data will not display in the file folder.

If for any reason you want to reset the participant ID count on the data sheet, go to GlobalControl.cs and call the method FlushIDSystem() in awake/start.
This will clear out the player preferences and restart the count. Make sure you have a copy of your data before you do this just in case.

Color hex codes used for each level:

Blue (level 1) - #0020FF
Green (level 2) - #56FF00
Red (level 3) - #FF0000
Yellow (level 4) - #FCFF00
Orange (level 5) - #FFA500
