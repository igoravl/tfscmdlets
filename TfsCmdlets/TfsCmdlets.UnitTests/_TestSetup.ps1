$projectDir = Join-Path (Split-Path $MyInvocation.MyCommand.Path -Parent) '..\TfsCmdlets' -Resolve
$modulePath = Join-Path $projectDir 'bin\Release\TfsCmdlets\TfsCmdlets.psd1'
$hasBuild = Test-Path $modulePath

if (-not $hasBuild) {
    throw "Module TfsCmdlets not found at $modulePath. Build project TfsCmdlets.Build prior to running tests."
}

Get-Module TfsCmdlets | Remove-Module
Import-Module $modulePath 
