$inputFile = "C:\Proyectos\SIGENFirmador\SIGENFirmador.csproj"
$lines = Get-Content $inputFile

Write-Host "Original file has $($lines.Length) lines"

$newLines = @()

for($i = 0; $i -lt $lines.Length; $i++) {
    # Skip line 453 (Error tag outside Target - original index)
    # Skip line 454 (Error tag outside Target - original index)  
    # Skip line 455 (Duplicate </Target> - original index)
    # These are now at different indices due to previous fixes
    
    # Let's identify them by content instead of line number
    $line = $lines[$i]
    
    # Skip these specific orphaned Error tags and duplicate </Target>
    if($i -ge 453 -and $i -le 455) {
        if($line -match '^\s*<Error Condition="!Exists\(''packages\\itext7\.pdfocr\.tesseract4\.2\.0\.2\\' -or
           $line -match '^\s*<Error Condition="!Exists\(''packages\\itext\.pdfocr\.tesseract4\.3\.0\.2\\' -or
           ($line -match '^\s*</Target>\s*$' -and $i -eq 455)) {
            Write-Host "Skipping problematic line $($i+1): $line"
            continue
        }
    }
    
    $newLines += $line
}

Write-Host "New file has $($newLines.Length) lines"

# Write the fixed content
$newLines | Out-File -FilePath $inputFile -Encoding UTF8

Write-Host "File fixed successfully!"
