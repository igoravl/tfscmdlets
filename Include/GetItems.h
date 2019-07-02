#define GET_TEAM_PROJECT(TP,TPC) TP = Get-TfsTeamProject -Project $Project -Collection $Collection; if (-not TP -or (TP.Count -ne 1)) {throw "Invalid or non-existent team project $Project."}; TPC = TP.Store.TeamProjectCollection
#define CHECK_ITEM(ITEM_NAME,ITEM_TYPE) if (ITEM_NAME -is ITEM_TYPE) { _Log "Input item '$(ITEM_NAME)' is of type ITEM_TYPE; returning input item immediately, without further processing."; return ITEM_NAME }