Function _TfsCmdletsPrompt
{
    $promptPrefix = '[Not connected]'
    $defaultPsPrompt = " $($ExecutionContext.SessionState.Path.CurrentLocation)$('>' * ($NestedPromptLevel + 1)) "
    $backColor = 'DarkGray'
    $foreColor = 'White'

    $server = (Get-TfsConfigurationServer -Current)

    if($server)
    {
        $tpc = (Get-TfsTeamProjectCollection -Current)
        $tp = (Get-TfsTeamProject -Current)
        $serverName = $server.Name
        $userName = $server.AuthorizedIdentity.UniqueName

        if ($serverName -like '*.visualstudio.com')
        {
            $tpcName = $serverName.SubString(0, $serverName.IndexOf('.'))
            $promptPrefix = "[AzDev:/$tpcName"
            $backColor = 'DarkBlue'
            $foreColor = 'White'
        }
        elseif ($serverName -eq 'dev.azure.com')
        {
            $tpcName = $server.Uri.Segments[1]
            $promptPrefix = "[AzDev:/$tpcName"
            $backColor = 'DarkBlue'
            $foreColor = 'White'
        }
        else
        {
            $promptPrefix = "[TFS:/$($server.Uri.Host)/"
            $backColor = 'DarkMagenta'
            $foreColor = 'White'

            if ($tpc)
            {
                $promptPrefix += "$($tpc.Name)"
            }
        }

        if ($tp)
        {
            $promptPrefix += "/$($tp.Name)"
        }

        if($userName)
        {
            $promptPrefix += " ($userName)"
        }

        $promptPrefix += ']'

    }
 
    Write-Host -Object $promptPrefix -NoNewline -ForegroundColor $foreColor -BackgroundColor $backColor

    return $defaultPsPrompt
}
