#!/bin/sh

# 202503082386
PNUMMER=2503082386

gforth pnummer.fs $PNUMMER -e bye 
echo $?
