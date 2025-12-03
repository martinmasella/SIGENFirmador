$lines = Get-Content "C:\Proyectos\SIGENFirmador\SIGENFirmador.csproj"
$newLines = New-Object System.Collections.ArrayList

for($i = 0; $i -lt $lines.Length; $i++) {
    [void]$newLines.Add($lines[$i])
    
    # Si encontramos un Reference tag de apertura
    if($lines[$i] -match '^\s*<Reference Include=') {
        $indent = '    '
        if($lines[$i] -match '^(\s+)<Reference') {
            $indent = $Matches[1]
        }
        
        # Buscar si ya tiene un cierre
        $hasClosing = $false
        $j = $i + 1
        
        # Agregar las líneas internas (HintPath, Private, etc.)
        while($j -lt $lines.Length) {
            if($lines[$j] -match '^\s*</Reference>') {
                $hasClosing = $true
                break
            }
            if($lines[$j] -match '^\s*<Reference Include=' -or $lines[$j] -match '^\s*</ItemGroup>') {
                # Encontramos otra Reference o el cierre de ItemGroup sin encontrar cierre
                break
            }
            if($lines[$j] -match '^\s*<(HintPath|Private|SpecificVersion)') {
                $i++
                [void]$newLines.Add($lines[$i])
            }
            $j++
        }
        
        # Si no tiene cierre, agregarlo
        if(-not $hasClosing) {
            [void]$newLines.Add("$indent</Reference>")
        }
    }
}

$newLines | Set-Content "C:\Proyectos\SIGENFirmador\SIGENFirmador.csproj"
Write-Host "Fixed $($newLines.Count) lines!"
