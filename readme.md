# FileBrowsa

A simple Windows GUI app to browse files in a folder. Supports command line parameters when launching the app so you can pass the initial starting folder, and a filter or filemask expression to apply to the file list. You can also launch the default app for any file by double-clicking on the filename.

Command line example:
```dos
FileBrowsa "C:\MyPath" "*.pdf"
```
![](file:///FileBrowsa_screenshot.png)

## Change Log

* Updated 2021-03-16 by Matt Slay
* Added Command Line Parameters to accept a Path and file mask (filter)
* Added a textbox on the GUI form for the Filter string.


## ToDo (planned updates:)
* Add a textbox for the Path so user can enter/edit from keyboard.
* Add feature to rename or delete a file.
* Add feature to launch Windows Explorer for the current folder.



## Credits

> Original Author: Russell Mangel (2002-05-01) 
>
> Original Program:		TV-LV-Basic Version 4.1
>
> Original code downloaded from: https://www.codeproject.com/Articles/2316/Windows-Explorer-in-C
>
> Designed initially to demonstrate TreeView & ListView Control, but this is also a good example of processing folders and files.

## Helpful links of coding used in this app:

* Command Line parameters: 
 https://stackoverflow.com/questions/1179532/how-do-i-pass-command-line-arguments-to-a-winforms-application


* Simple databinding in WinForms:
 https://www.codeproject.com/Articles/11530/Understanding-Simple-Data-Binding