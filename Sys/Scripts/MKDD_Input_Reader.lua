local input_runner = {}

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
  local mspRecorder = 0
	if GetGameID() == "GM4P01" then mspRecorder = 0x803d5c9c
	elseif GetGameID() == "GM4E01"then mspRecorder = 0x803CBE5C
	elseif GetGameID() == "GM4J01"then mspRecorder = 0x803E647C
  else onScriptCancel()
	end

	local mspRecorderResult = ReadValue32(mspRecorder)
	local currentFrame = 0
	if mspRecorderResult ~= 0 then
			currentFrame = ReadValue32(mspRecorderResult) -- Doing it this way because people probably use old versions of Lua core
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
