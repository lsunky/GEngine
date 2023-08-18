set WORKSPACE=..

set GEN_CLIENT=%WORKSPACE%\Tools\Luban\Luban.dll
set CONF_ROOT=%WORKSPACE%\Configs

dotnet %GEN_CLIENT% ^
    -t all ^
    -c cs-simple-json ^
    -d json  ^
    --schemaPath %CONF_ROOT%\Defines\__root__.xml ^
    -x inputDataDir=%CONF_ROOT%\Excels ^
    -x outputCodeDir=%WORKSPACE%\Assets\Script\GameLogic\Gen\Configs ^
    -x outputDataDir=%CONF_ROOT%\Content

pause