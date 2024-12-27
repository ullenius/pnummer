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

declare -a invalid_arr=(
"202508242382"
"202510022384"
"202503312380"
"202509012385"
"202512232387"
"202504182390"
"189506299819"
"189002099812"
"189103179800"
"190006129805"
"190704019802"
"190108219818"
"200306062382"
"200802122391"
"000000000000"
"199502291116" # invalid date, not leap-year
"199313241235" # invalid month number
"199300121234" # month zeroed
"199312001234" # days zeroed
"199301321239" # invalid day number
)

function assertTrue() {
    echo -n "Validating ${1} "
    validate "${1}" && echo OK || echo FAIL
}

function assertFalse() {
    echo -n "Validating (invalid) ${1} "
    validate $1 && echo FAIL || echo OK
}

function validate() {
    gforth main.fs "${1}" -e bye
}

for p in "${valid_arr[@]}"
    do
        assertTrue $p
done

for p in "${invalid_arr[@]}"
    do
        assertFalse $p
done
