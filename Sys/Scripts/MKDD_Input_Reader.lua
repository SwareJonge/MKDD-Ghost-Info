local input_runner = {}

local function getGameID()
    return ReadValueString(0x0, 6)
end

local runner_loaded = false

local frameCount = 0

function tableLength(tableInput)
	local count = 0
	for _ in pairs(tableInput) do count = count + 1 end
	return count
end

function runInputs()

end

-- ##################################

function onScriptStart()
	MsgBox("Script started.")
	runner_loaded, input_runner = pcall(require, "mkdd_input_reader_ghost")

	if(runner_loaded) then
		frameCount = tableLength(input_runner)
	end
end

function onScriptCancel()
	MsgBox("Script ended.")
end

function onScriptUpdate()
  local currentFrame = 0
	if getGameID() == "GM4P01" then currentFrame = ReadValue32(0x810E2790)
	elseif getGameID() == "GM4E01"then currentFrame = ReadValue32(0x810A3250)
	elseif getGameID() == "GM4J01"then currentFrame = ReadValue32(0x810BD870)
  else onScriptCancel()
	end
	currentFrame = currentFrame + 1

	if currentFrame <= frameCount then

		local inputs = input_runner[currentFrame]

		local horizontalInput = inputs[1]
		local verticalInput = inputs[2]
		local aButton = inputs[3]
		local bButton = inputs[4]
		local rButton = inputs[5]
		local lButton = inputs[6]
		local shroomButton = inputs[7]
		local zButton = inputs[8]
		SetMainStickX(horizontalInput)
		SetMainStickY(verticalInput)

		if aButton == 1 then PressButton("A") end
		if bButton == 1 then PressButton("B") end
		if rButton == 1 then PressButton("R") end
		if lButton == 1 then PressButton("L") end
		if shroomButton == 1 then PressButton("X") end
		if zButton == 1 then PressButton("Z") end

	end
end

function onStateLoaded()

end

function onStateSaved()

end
