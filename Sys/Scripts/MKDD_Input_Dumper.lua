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
  if getGameID() == "GM4P01" then currentFrame = ReadValue32(0x810E2790) InputTableStartAddress = 0x810E2950
  elseif getGameID() == "GM4E01" then currentFrame = ReadValue32(0x810A3250) InputTableStartAddress = 0x810A3410
  elseif getGameID() == "GM4J01" then currentFrame = ReadValue32(0x810BD870) InputTableStartAddress = 0x810BDA30
  else onScriptCancel()
  end
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
