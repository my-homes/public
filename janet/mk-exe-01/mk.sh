#! /usr/bin/env -S bash -e
# -*- mode: sh -*-
script_dir="$(realpath `dirname "$0"`)"
cd "$script_dir"
#set -uvx
set -e
cwd=$(pwd)
ts=$(date "+%Y.%m%d.%H%M.%S")
ver=$(echo $ts | sed -e "s/[.]0/./g")
source ~/.emacs.d/snippets/sh-mode/color-defs.inc.sh

green script_dir=$script_dir
green cwd=$cwd
green ts=$ts
green ver=$ver

color "${GREEN}Hello${NC} ${RED}World!${NC}"
my-echo "[green]Hello2[/] [red]World2![/]"

echo "Hello no color!"

my-echo "[blue][link=https://www.youtube.com/]Click to visit YouTube[/][/]!" "[yellow](?°□°)?[/]? [blue]┻━┻[/]"

#jpm build
jpm quickbin main.janet main.exe
