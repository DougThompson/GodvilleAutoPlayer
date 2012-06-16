# Godville Auto-Player #

**Godville Auto-Player** is an auto-playing and logging tool for the zero-player game (ZPG) [Godville](http://godvillegame.com/).  Godville, if you haven't heard of it, is a fantastic ZPG that requires very little input but gives back so much&mdash;an incredible ROI on your time!

This client is designed to capture all the goings on that you may miss when not logged in and has simplified rules to act on your behalf&mdash;taking a ZPG even further in removing you, the player, from any serious involvement!

This is not endorsed by the Godville team and all rights are retained by them including, but not limited to, their copyrights, trademarks, and intellectual property, etc....

## Requirements ##
This has been tested on Windows XP and Windows 7 64-bit, but only with the ActiveX IE control.

## Development Requirements ##
- Visual Studio 2010, C#, .NET Framework 3.5.
- Internet Explorer 8.0 & 9.0 objects
- [System.Data.SQLite](http://sqlite.phxsoftware.com/) v1.0.66.0

## Rules Engine ##
The rules are pretty simple at the moment and follow this pattern:
> {Encorage/Punish} every {n} minutes if {God Power / % Health} is {<,>,=,<=,>=} {threshold}

## Known Issues ##
Okay, there are a number of pitfalls and potential errors with this client as it is parsing the HTML directly.  So here goes (do not consider this the least bit complete):

- English is the only supported language
	- Some bits of info found only by parsing text
- The client assumes **ALL** panels are **visible**
- Any changes in the HTML delivered may cause massive issues and **FAIL**
- Various browser issues may not be caught by the client and **FAIL**
- When viewing the Diary, interface may become unresponsive or sluggish while client is parsing the Hero's page.

## TODO ##
There are many, many things that can be improved, but here are the biggies:

- Arena battles: logging and behavior
- Better error handling on missing or malformed HTML tags

## License ##
Released under the [MIT License](http://www.opensource.org/licenses/mit-license.php)

Copyright (c) 2012 Doug Thompson

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the
"Software"),to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
