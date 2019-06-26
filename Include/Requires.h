#define REQUIRES_PS_WINDOWS if ($PSVersionTable.PSEdition -ne 'Desktop') { throw "This cmdlet requires does not work in PowerShell Core. It uses TFS Client Object Model, which only works in Windows PowerShell" }
#define REQUIRES(assemblyName) Import-RequiredAssembly -AssemblyName 'assemblyName'
#define USE_PSCORE_ALTERNATIVE(altCmdlet) if ($PSVersionTable.PSEdition -ne 'Desktop') { throw "This cmdlet requires does not work in PowerShell Core. It uses TFS Client Object Model, which only works in Windows PowerShell" }