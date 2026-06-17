#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`

dotnet build -c release
#vbpack -i bin/Release/net462/my-player.exe -o my-player-pack.exe
exepack -i bin/Release/net462/my-player.exe -o my-player-pack.exe
