# EBAC Repositories

1. [EBAC Unity Modules 0 to 8 - Unity initial](https://github.com/TonGarcia/EBAC-Unity)
2. [EBAC Unity Modules 9 to 19 - Platform 2D](https://github.com/TonGarcia/Platform2D-EBAC-Unity)
3. [EBAC Unity Modules 20 to 26 - HyperCasual Mobile](https://github.com/TonGarcia/HyperCasual)
4. [EBAC Unity Module 27 - Editor PlugIns](https://github.com/TonGarcia/UnityEditorUIPlugins-EBAC)


## Unity Extensions
1. **WHAT**: plugins that may change IDE/Editor or just helper methods to help on dev workflow
2. **WHY**: development may need to reproduce many steps, the goal is to get a less effortful workflow
3. **HOW**: creating scripts, Steps to create extensions:
   1. Create a class that does not inherit anything (no MonoBehavior...): `public static class CoreUtil`, like the Singleton
   2. The **method** must be **static** as the **class** is
   3. By adding `this` keyword means **what class would be modified when calling this method** (including this method as part of the existing class): `public static void Scale(this Transform t, float size = 1.2f)`
   4. To call this method should be like: `transform.Scale(2)` where 2 means the `size`, due the first is the obj itself
   5. Sample for GameObject: `public static void Scale(this GameObject go, float size = 1.2f)` --> `gameObject.Scale(2)`
   6. using generics for the Lists: `public static T GetRandom<T>(this List<T> list)`
4. `Editor Extensions`: check the classes: `Car` and `CarEditor`
   1. Check editor **tooltip** setup on the `CarEditor.cs`
   2. creating a non hover "bootstrap alert": `EditorGUILayout.HelpBox("message", MessageType.Info);`
5. **CHECKING**:
   1. `Assets/Scripts/Core` = Core helpers like `Singleton` & `ExtensionUtil`
   2. `Assets/Scripts/Editors` = Scripts that change the Editor behavior --> **as example check**: `CarEditor.cs`
      1. instead of `using UnityEngine` it will be `using UnityEditor` and instead of ` : MonoBehavior` (extend) use ` : Editor`
      2. add modifier to the class Header to be a **CustomEditor**: `[CustomEditor(typeof(Car))]` 
      3. to become an Editor **Inspector** Section override it method: `public override void OnInspectorGUI()` 
         1. the `OnInspectorGUI` lines work like StreamLit UI creation and it display these lines on a Inspector section
6. Creating new **Menu Item** (**menu bar**):
   1. Check `AtypicalUtils.cs` UnityEditor MenuItem modifier
      1. *it is not necessary to add the script to any scene or anything else as it is an editor changer
      2. *just by save the file the Editor already loads the option and created MenuItem Atypical/EditorMenuItem
      3. *add if Editor to avoid the script to be executed while building the game
   2. Hotkeys (shortcut to menu items)
      1. "%" means CTRL Windows / CMD MacOS
      2. "#" means Shift
      3. "&" means Alt
      4. --> Check `AtypicalUtils.cs` MenuItem name which defined a hotkey CTRL+G


# Unity Tips
*Free Assets used:
1. Dark UI
2. NaughtyAttributes

*Editor Tips:
1. On list attributes: select all elements on the Hierarchy and drag & drop into the list attr name


## C#
1. Check the `Scripts/Screen/ScreenBase.cs` [button] statement which create editor button to call and test the method directly on Editor (**it even works if Play if off, BUT AVOID ID!**);
2. Check the `Scripts/Button/ButtonScale.cs`. Check the **Hover** event by Implementing Interfaces and check Tween `Kill()` to avoid animation **"crashes"**

## UI/HUD
1. The screens GameObjects need to be Active to get their Scripts working. So to do that, follow the steps:
   1. inactive all children GameObjects
   2. active the **"ScreenBase"** GameObject
   3. set the ScreenBase image and the C# script gonna enable/disable just the image, not the GameObject
2. Each **screen** should get a component `ScreenBase` and each **button** should get components: 1. `ButtonScale` (animate gameobject), 2. `ScreenHelper` (switch screens), 3. add click to button component and the target will be `ScreenHelper.onclick`.
3. **`Particle System`**:
   1. As it is (UI Canvas default camera) the particle won't be displayed/rendered. Steps to fix it:
      1. Render Mode: **Screen Space - Camera**
      2. Set (Drag & Drop) the MainCamera into it
      3. Drag & Drop the Particle System inside the MainCamera GameObject
      4. 


# UnityTemplate
1. [Unity GitHub Repo Template](https://github.com/TonGarcia/UnityTemplate)
2. [Unity GitLab GBaaS (Firebase+PlayFab+GBaas) Template Sample](https://gitlab.com/kpihunters/GBaaS/unity-gbaas-template)

*Remember to copy and paste `.gitattributes` & `.gitignore` into it project sub folder.    
**Remember to protect it new repository branchs

# Branches Strategy
1. Develop: used to `programming` updates
2. Art: used to `art experiments like scenes concepts` and others `arts` stuff
3. Each new task should be a fork of it branch type like `develop_mobile_35` or `art_character_34`
4. The workflow should be: `task branch` like `develop_mobile_35` merged into `develop`, once ok the develop should be merged into `main` and `art` and `develop` should be updated from that new stable `main` branch

# Errors HotFix

## IF Unity incompatible version
1. IF on MacOS:
   1. install LFS command globally: `brew install git-lfs`
   2. install git lfs to repo: `git lfs install`
   3. pull LFS files: `git lfs pull`
1. If plastic error:
   1. Unity > Version Control (icon) > LogIn
   2. Unity > Project Settings > Version Control > Unity Version Control Settings > DISABLE

# Rider <> Unity tips
1. Video for more information: https://www.youtube.com/watch?v=O1oOAM-AdbE
2. If Rider did not tagged the project as Unity Project, so it is necessary to open the root project folder on Rider, so Rider will set it up correctly

# Git Large Files

1. Duplicate the .gitignore from root dir to inside the Game Project dir
2. Install: 
   1. download and run the installer
   2. `git lfs install`
3. Add large files extension: 
   1. `git lfs track "*.psd" "*.png" "*.jpg" "*.jpg" "*.gif" "*.mp4" "*.mp3" "*.fbx"`
   2. `git lfs track "**.psd" "**.png" "**.jpg" "**.jpg" "**.gif" "**.mp4" "**.mp3" "**.fbx" "**.dll"`
4. Attributes tracker: `git add .gitattributes`
5. If git not tracking any extension run it: `git lfs migrate import --include="*.extension"`

# Unity Tips
1. Switch graphic manipulation: **QWERTY**
2. Lock Tab: lock Inspector tab to be able to select many Hierarchy elements without switching it Inspector visualization
3. Use Unity DOTs and ECS instead of GameObject instantiations that replicate same C# code at runtime: https://www.youtube.com/watch?v=18f2LeIXGo4

# Unity VR

## Google Cardboard

1. Link to Video: https://www.youtube.com/watch?v=O9NCXV88gPI
2. Remember to import the asset after cloning at the PackageManager
