function degreesToRadians(degree)
    return degree * math.pi / 180
end

function circleSpawn(radius, object)
    for angle = 30, 360, 30 do
        local radians = degreesToRadians(angle)
        local x = radius * math.cos(radians)
        local y = radius * math.sin(radians)
        SpawnLevelPiece(object, Vector3(x, 1.0, y), Quaternion.Euler(0, 0, 0))
    end
end

circleSpawn(10, 'Goal')