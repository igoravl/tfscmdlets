. "$(Split-Path -Parent $MyInvocation.MyCommand.Path)\..\_TestSetup.ps1"

InModuleScope 'TfsCmdlets' {

    Describe 'Disconnect-TfsTeamProject' {

        Context 'When invoking cmdlet' {

            [TfsCmdlets.CurrentConnections]::Server = 'server'
            [TfsCmdlets.CurrentConnections]::Collection = 'collection'
            [TfsCmdlets.CurrentConnections]::Project = 'project'
            [TfsCmdlets.CurrentConnections]::Team = 'team'

            Disconnect-TfsTeamProject

            It 'Should clear Project and Team objects' {
                [TfsCmdlets.CurrentConnections]::Server | Should Be 'server'
                [TfsCmdlets.CurrentConnections]::Collection | Should Be 'collection'
                [TfsCmdlets.CurrentConnections]::Project | Should BeNullOrEmpty
                [TfsCmdlets.CurrentConnections]::Team | Should BeNullOrEmpty
            }
        }
    }
}