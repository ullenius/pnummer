\ personnummer-forth
\ Copyright (C) 2024 Anosh D. Ullenius

\ GPL-3.0-only

\ This file is part of personnummer-forth

\ personnummer-forth is free software: you can redistribute it and/or modify
\ it under the terms of the GNU General Public License as published by
\ the Free Software Foundation version 3.0.

\ personnummer-forth is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
\ GNU General Public License for more details.

\ You should have received a copy of the GNU General Public License
\ along with this program. If not, see <https://www.gnu.org/licenses/>.

s" pnummer.fs" included
s" date.fs" included

: substring ( addr u n -- addr2 u2 )
    2dup
    <
    if
        ." string too short"
        abort
    then
    dup >r - \ subtract length by n
    swap r> + swap \ add n to start pos
;

: remove-century-digits 2 substring ;

: main
    argc c@ 2 < if
        ." usage: gforth main.fs [personnummer]..." cr
        -1 (bye)
    then
    next-arg 2dup
    drop valid-century
    >r \ store result
    2dup drop 
    parseDate
    valid-monthday
    r> and \ and results
    if
        remove-century-digits
        2dup
        iter luhn
        >r last-digit r>
        = \ compare calculated digit to actual
    else
        false
    then
    invert
    (bye)
;

 main

