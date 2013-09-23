
function Kill-EveryLocalDb {
    #clear file locks on db
    ps | where { $_.processname -like "iisexpress*" } | Stop-Process 
    
    #clear reference to database in the secret localdb registry
    & sqllocaldb.exe stop v11.0 2>&1>$null
    & sqllocaldb.exe delete v11.0 2>&1>$null

    #clear out MDF/LDF files
    rm "src\MonopolyWeb\App_Data\*.*" -force
}

