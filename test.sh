#!/bin/bash
set -u

# 202503082386
PNUMMER=2503082386 # valid
INVALID=2503082387

declare -a valid_arr=(
"202508242381"
"202510022383"
"202503312387"
"202509012387"
"202512232386"
"202504182391"
"189506299818"
"189002099811"
"189103179801"
"190006129803"
"190704019801"
"190108219817"
"200306062381"
"200802122390"
"200607092384"
)

function assertTrue() {
    echo -n "Validating ${1} "
    validate "${1}" && echo OK || echo FAIL
}

function assertFalse() {
    echo -n "Validating invalid personnummer ${1} "
    validate $1 && echo FAIL || echo OK
}

function validate() {
    gforth pnummer.fs "${1:2}" -e bye # remove 2 first chars from year
}

for p in "${valid_arr[@]}"
    do
        assertTrue $p
done
