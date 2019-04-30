# EDDTT
EDD Translation Tool - automated GUI tool for translating [EDDiscovery](https://github.com/EDDiscovery/EDDiscovery)

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)

It looks like this:  
![EDDTT_preview](https://user-images.githubusercontent.com/39399945/56984094-881dfd80-6b85-11e9-93d6-9d2f930ce6f5.PNG)

## How to use
### Preparations
You can use EDDTT in two ways:
* Select the example and translation file manually in <kbd>File Paths</kbd> menu, or
* Select the directory of your local EDDiscovery repository in <kbd>EDD repository</kbd> menu and automatically detect the paths to every file using the <kbd>Auto-Set Paths</kbd> menu. This option also allows you to create an entirely new translation file set from the example files by pressing the <kbd>New Language</kbd> button.

**The first way** doesn't need much explaining. Just go to the <kbd>File Paths</kbd> menu and set the paths using the <kbd>Set the ... file path manually</kbd> buttons. Then, press the <kbd>Load and Compare Files</kbd> button to, well, load and compare the files.

**The second (better) way** uses your local EDDiscovery repository path to automatically detect present languages and set the paths to them. It's much easier and faster than setting the paths manually every time.  
In order to use it, you need to set the repository directory first.
1. Go to the <kbd>EDD repository</kbd> menu and press <kbd>Set EDD repository directory</kbd>.
2. Select the path to your local EDDiscovery repository (It should be the folder with `EDDiscovery.sln` in it).
3. The path is stored in program settings, so you don't have to set it every time you start EDDTT.

When you set the path properly, the language selection, the <kbd>Auto-Set Paths</kbd> menu and the <kbd>New Language</kbd> button will be unlocked.  
EDDTT will automatically detect all languages present in the repository. It will also do it on startup, and automatically select previously used language.

Select the language you want to edit from the drop-down list, or press <kbd>New Language</kbd> to create a new file set from example files (For more on how to use the <kbd>New Language</kbd> option, go to [Creating New Translation](#creating-new-translation)).  
![EDDTT_select_language](https://user-images.githubusercontent.com/39399945/56984277-f2cf3900-6b85-11e9-9bfb-f483d4a20e45.png)

At this point, the only thing you need to do to load the files is to go to the <kbd>Auto-Set Paths</kbd> menu and choose which file you want to edit:  
![EDDTT_autoset_menu](https://user-images.githubusercontent.com/39399945/56982613-02e51980-6b82-11e9-9e17-fb806c9868bc.png)  
(Unless you don't use the <kbd>Load and Compare on Auto-Set Paths</kbd> option, in this case you have to press <kbd>Load and Compare Files</kbd> as well)

### Editing the Translation
##### 1. Editing
You can edit the translation in the `Translation Text (editable)` column of the *Translation* and *Differences* tables.

If you want to preserve the format, hidden spaces, special characters etc. from example, you can click on the corresponding cell in the `Example Text` column to copy its contents into the `Translation Text (editable)` column. If the translation cell is not empty, you need to double click instead.
##### 2. Differences
If there were new IDs added to the example file and they are not present in the translation file, they will be listed in the *Differences* tab.  
Before loading the file, I removed some IDs to demonstrate. It looks like this:  
![EDDTT_differences_view](https://user-images.githubusercontent.com/39399945/56984856-4f7f2380-6b87-11e9-9b5c-4d03d1383ec9.PNG)

You can add the translation text. When you're done, press <kbd>Apply Differences to Translation</kbd> to move the IDs to the *Translation* table.


### Creating New Translation
You can create a new set of translation files from the example files by using the <kbd>New Language</kbd> option.

Press the <kbd>New Language</kbd> button.  
This window should show up:  
![EDDTT_new_language](https://user-images.githubusercontent.com/39399945/56985909-be5d7c00-6b89-11e9-9048-5b06b0463063.PNG)

Enter the name for the new language, as in the example. Then press <kbd>OK</kbd>.  
(Anuluj means Cancel in Polish, but I don't want to install English OS just to make this picture)

EDDTT will create a new set of language files from example files. In the main file, the inclusions for other files will be changed accordingly.

Also, if you have the <kbd>Auto-Set Paths after creating new language</kbd> option enabled, EDDTT will set the paths to the example and newly created translation main files. If you have <kbd>Load and Compare on Auto-Set Paths</kbd> enabled as well, these files will be automatically loaded.
