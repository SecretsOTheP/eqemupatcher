# EQEmuPatcher

EQEmu File Comparison and Patcher

![alt tag](http://i.imgur.com/FSVgkzh.png)
---

There are two ways to set up eqemupatcher:
The easier but limited is the [Quick Guide](#quick-guide) steps.
The more custom but advanced is the [Advanced Build](#advanced-build) steps.

# Quick Guide

[![EQEmu Patcher Video](http://img.youtube.com/vi/oS2V0BABNvk/0.jpg)](http://www.youtube.com/watch?v=oS2V0BABNvk "Want Your Own EQ Patcher? Quick Guide")

click above to watch a step by step video

# Advanced Build

* eqemupatcher.exe is the client side patcher. Read Client Setup for more information on how to use it.
* filelistbuilder.exe is the server side patch prepper. Read Server Setup for more information on how to use it.

### Client Setup

After finishing the Server Setup process, simply distribute eqemupatcher.exe to your players. There are no additional dependencies for modern Windows users. They will need to place it in the same directory as eqgame.exe (Your Everquest directory).
* It is recommended to advise players that if they copy this file into Program Files for their EQ dir, it will need to run with administrator privileges.

### Server Setup

There are two parts to getting eqemupatcher working. First is getting filelistbuilder configured, second is configuring and compiling the eqemupatcher client.

* Fork this repository, so you can modify and version your own changes. If you are unfamiliar with forking, I suggest checking out https://help.github.com/articles/fork-a-repo/ to learn more. When I refer to the EQemu Patcher\ directory, I am referring to your forked copy of the source code here.
* Enable CICD actions

#### Filelistbuilder setup - Building the patch data.

Theere are two ways to generate the patch data. If you don't have large patches, you can host it on github, by copying the content to the repo's rof/ folder. You can do this on the website if no files exceed 25mb. If they exceed 25mb, I recommend using Github Desktop.

* *Optional:* If you have golang installed, you can compile filelistbuilder.go yourself by going using [this repo](https://github.com/xackery/filelistbuilder).
* Download the filelistbuilder binary version that fits your server operating system here: https://github.com/xackery/filelistbuilder/releases
* *Note:* It is important that your server generates the filelist.yml file, as an md5 can change when being hosted and cause challenges.
* Copy the filelistbuilder binary from releases to your server into a fresh directory, for now on we'll call it filelistbuilder\. Note that this should be set in a PATH directory so it can be referred to from anywhere. Or if you're lazy, copy it in the SAME directory you have any filelistbuilder.yml files.
* Make a subdirectory representing clients you plan to support, e.g. filelistbuilder\rof\ and filelistbuilder\und\
* By default, all versiontypes are not supported except rof, you can edit this during client configuration if you plan to use another client.
A list of supported types by default are: 
```
VersionTypes.Unknown, //unk
VersionTypes.Titanium, //tit
VersionTypes.Underfoot, //und
VersionTypes.Secrets_Of_Feydwer, //sof
VersionTypes.Seeds_Of_Destruction, //sod
VersionTypes.Rain_Of_Fear, //rof
VersionTypes.Rain_Of_Fear_2 //rof
VersionTypes.Broken_Mirror, //bro
```
* Copy EQEmu Patcher\filelistbuilder.yml to filelistbuilder\rof\ and any other clients.
* Copy the files that need to be patched into filelistbuilder\rof\ and any other clients.
* Edit filelistbuilder\rof\filelistbuilder.yml and change the downloadprefix line to match where the patches will be hosted. (For the example, it will be http://example.com/rof/). 
* Run the filelistbuilder binary. If all succeeds, it will generate 2 new files: filelist_rof.yml and patch.zip. (the _rof suffix will change if you modify the client)
* Patch.zip is a fully encompassed zip you can link players to who do not trust your patcher. Open it and you should see all patch contents.
* You can take a peek at filelist_rof.yml to verify the files expected to be patched are located correctly, and if the prefixdownload url looks correct.
* You can now copy all contents, except the filelistbuilder binary and filelistbuilder.yml, to your patch URL with a subdir of your client.. e.g. copy all files for a rof patch to http://example.com/rof/ so that if you access http://example.com/rof/filelist_rof.yml it will succeed to find the file
* *Note:* eqemupatcher supports deleting files by adding a delete.txt file to filelistbuilder\rof\. Inside it, simply list all files to be deleted in a different line, e.g.: (Be careful with this feature)
```
nektulos.eqg
anotherfile.txt
```
* *Note:* You can make a custom splash screen by creating a 400x450 png file named eqemupatcher.png and including it in your patcher.
* You're done! Any time you run the filelistbuilder binary in future, it will regenerate the filelist_rof.yml and patch.zip. It stores md5 checksums so that eqemupatcher.exe can compare existing files and decide to download and patch or not.

#### Visual Studio Setup - Building the Client
* Get Visual Studio if you don't have it already. You can obtain the latest copy of Visual Studio for free from Microsoft here: https://www.visualstudio.com/downloads/ Click the Community Edition.

* Navigate into the EQEmu Patcher directory and open EQEmu Patcher.sln. It will open in Visual Studio.
* On the Debug dropdown on the top center of screen, change it to Release.
* Click play. It should prompt a message box noting you must run this patcher in your Everquest directory.
* Go to your Everquest directory, and copy eqgame.exe from your EQ directory to the EQEmu Patcher\EQEmu Patcher\bin\Release directory. 
* Click play again. This time, it should detect your client and start the patcher. (By default, it is configured to use rebuildeq and may not work as desired.).
* Right click MainForm.cs on the right side of Visual Studio and click View Code.
* On the header section of this file, you will see options to configure. Change serverName, fileListUrl (set it to the ROOT URL, e.g. http://example.com/, etc to the directory you have planned to prep everything.
* In your EQEmu Patcher\EQEmu Patcher\bin\Release\ folder should be an eqemupatcher.exe file. Copy this to your server to be downloaded by clients.
* You can also verify all is ok by copying eqemupatcher.exe to your Everquest directory. 

That's it!


