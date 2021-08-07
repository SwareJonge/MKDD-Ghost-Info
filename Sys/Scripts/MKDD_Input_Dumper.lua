local input_runner = {}

local function getGameID()
    return ReadValueString(0x0, 6)
end

function string.fromhex(str)
    return (str:gsub('..', function (cc)
        return string.char(tonumber(cc, 16))
    end))
end

write_file = io.open("MKDD_Output.bin", "w")
io.output(write_file)
-- ##################################

function onScriptStart()
  local InputTableStartAddress = 0
  local currentFrame = 0

  -- with this approach we don't have to worry about incorrect addresses however the pointer to the inputtablestartaddress gets cleared after the race is done
  if GetGameID() == "GM4P01" then mspRecorder = 0x803D5C9C
	elseif GetGameID() == "GM4E01"then mspRecorder = 0x803CBE5C
	elseif GetGameID() == "GM4J01"then mspRecorder = 0x803E647C
  else onScriptCancel()
  end

  local mspRecorderResult = ReadValue32(mspRecorder)
  local currentFrame = 0
	if mspRecorderResult ~= 0 then
			InputTableStartAddress = ReadValue32(mspRecorderResult + 0xD0)
      	currentFrame = ReadValue32(mspRecorderResult) -- Doing it this way because people probably use old versions of Lua core
	end

  MsgBox(string.format("%X", InputTableStartAddress))
  local Length = currentFrame * 2 -1
  for i = 0, Length, 1 do
        --local Array =
        local str = string.format("%02X", ReadValue8(InputTableStartAddress + i)):fromhex()
        io.write(str)
  end


  CancelScript()
end

function onScriptCancel()
	MsgBox("Script ended.")
end

function onScriptUpdate()

end

function onStateLoaded()

end

function onStateSaved()

end
