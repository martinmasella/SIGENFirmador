$inputFile = "C:\Proyectos\SIGENFirmador\SIGENFirmador.csproj"
$lines = Get-Content $inputFile

Write-Host "Original file has $($lines.Length) lines"

# Fix 1: Add missing </Reference> after line 85 (BouncyCastle.Cryptography)
# Line 84 is: <Reference Include="BouncyCastle.Cryptography...">
# Line 85 is: <HintPath>packages\BouncyCastle.Cryptography.2.6.2\lib\net461\BouncyCastle.Cryptography.dll</HintPath>
# Line 86 should be: </Reference> but instead is another <Reference>

# Fix 2: Add missing </Reference> after line 243 (System.Threading.Tasks.Extensions)
# Same pattern

# Fix 3: Remove duplicate </Target> on line 452 and 457
# Line 452 closes the Target correctly
# Lines 454-456 have Error tags outside any Target
# Line 457 has another </Target> that shouldn't be there

$newLines = @()
$skipNext = $false

for($i = 0; $i -lt $lines.Length; $i++) {
    $currentLine = $lines[$i]
    
    # Add the current line
    $newLines += $currentLine
    
    # Fix 1: After line 85 (index 84), add </Reference>
    if($i -eq 84) {
        Write-Host "Fix 1: Adding </Reference> after line 85"
        $newLines += '    </Reference>'
    }
    
    # Fix 2: After line 243 (but now it's 244 because we added one line), add </Reference>
    # We need to account for the previous insertion
    if($i -eq 242) {
        Write-Host "Fix 2: Adding </Reference> after line 243"
        $newLines += '    </Reference>'
    }
    
    # Fix 3: Remove duplicate </Target> on line 452 (original line 451)
    # Since we added 2 lines, it's now at index 453
    # Actually, let's just remove line 452 and 457 from original
    if($i -eq 451) {
        Write-Host "Fix 3a: Skipping duplicate </Target> at original line 452"
        $newLines = $newLines[0..($newLines.Length-2)]  # Remove the line we just added
    }
    
    if($i -eq 456) {
        Write-Host "Fix 3b: Skipping duplicate </Target> at original line 457"
        $newLines = $newLines[0..($newLines.Length-2)]  # Remove the line we just added
    }
}

Write-Host "New file has $($newLines.Length) lines"

# Write the fixed content
$newLines | Out-File -FilePath $inputFile -Encoding UTF8

Write-Host "File fixed successfully!"
