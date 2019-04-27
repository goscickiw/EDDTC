# EDDTC
A simple GUI tool for translating EDDiscovery

It looks like this:
![4](https://user-images.githubusercontent.com/39399945/56851009-66651200-690a-11e9-8179-75439a856ae4.PNG)

## How to use
### Editing existing translation
If you want to set file paths manually, go to step 3.

1. Select your EDDiscovery repository (Press <kbd>...</kbd>):<br />
![step1](https://user-images.githubusercontent.com/39399945/56852561-1c395c00-691d-11e9-8286-2a0dd26c48de.PNG)<br />
![step1a](https://user-images.githubusercontent.com/39399945/56852577-4428bf80-691d-11e9-8714-e603dd04c210.PNG)

2. Press <kbd>Get Paths</kbd> to load TLF file names from repository directory, then choose your language and the file you want to edit (`tlf` - main file, `uc` - User Controls, `je` - Journal Events, `ed` - Elite Dangerous):<br />
![step2](https://user-images.githubusercontent.com/39399945/56852597-7fc38980-691d-11e9-9115-3eb6c0ce98f1.png)
![step2a](https://user-images.githubusercontent.com/39399945/56852646-08422a00-691e-11e9-9e10-394d08820ef3.png)
![step2b](https://user-images.githubusercontent.com/39399945/56852654-2019ae00-691e-11e9-9ca0-45ffa3254e26.png)

3. Press <kbd>Get Paths</kbd> again to automatically set paths to example and translation files (in this case they would be `translation-example-je.tlp` and `translation-polski-je.tlp`). You can also set the paths manually by pressing the <kbd>...</kbd> buttons:<br />
![step3](https://user-images.githubusercontent.com/39399945/56852692-b2ba4d00-691e-11e9-92a2-6dce4426014b.PNG)

4. Press <kbd>Load and Compare Files</kbd>. The program will load the files and compare the example file to the translation file. If there are **added** IDs existing in the example file but missing in the translation file, or **removed** IDs existing in the translation file but missing in the example file, they will be listed in the **Differences** tab. The **Differences** tab will be automatically selected if any differences are found. Otherwise, the **Translation File** tab will be selected (Go to step 6).<br />
Before loading the file, I removed some IDs to demonstrate:<br />
![step4](https://user-images.githubusercontent.com/39399945/56852970-0712fc00-6922-11e9-898d-e4fba0fcbac3.PNG)<br />
You can fill in the cells in the **Translation Text (editable)** column. If you want to preserve any spaces or special characters from example, you can click the corresponding cell in the **Example Text** column. If the translation cell is not empty, you can double click the example to copy anyway.

5. After you're done with the differences, press <kbd>Apply to Translation</kbd> in the **Differences View Options (D)** tab. This will move the differences (with your changes, if you made any) to the table in **Translation File** tab. It will not save to the file yet.<br />
![step5](https://user-images.githubusercontent.com/39399945/56853246-645c7c80-6925-11e9-9381-de9948608295.png)<br />
(The View Options tabs and the main tabs are linked in such a way that if the main tab is changed, the View Options tab will be changed accordingly. It works the same the other way around)

6. Go to the **Translation File** tab. The added IDs will be highlighted in gray.<br />
As you can see, the IDs were added in the correct section. If an entire new section was added, it will be placed on the bottom of the table.<br />
![step6](https://user-images.githubusercontent.com/39399945/56853356-c8337500-6926-11e9-88af-210f8f3e9481.PNG)<br />
You can edit the translations and copy the examples the same way as in step 4.
