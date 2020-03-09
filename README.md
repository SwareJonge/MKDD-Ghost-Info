# MKDD-Ghost-Info
Opens and converts a MKDD ghost file to a format that's readable by a lua script called MKDD_Input Reader.lua, use this with [Doplhin 5.0 Lua Core](https://github.com/SwareJonge/Dolphin-Lua-Core/releases)

## Usage for Dolphin
Drop the executable and the Sys folder in the .exe directory of Dolphin Lua core so Dolphin can read the script.
Run the program and open your ghost, the program automatically outputs this to mkdd_input_reader_output.lua.
Make sure that no controller is plugged in when booting up the game, when booting up the game the stick has to be in it's neutral position(128,128) otherwise the script will desync at some point.
