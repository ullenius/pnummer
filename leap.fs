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

: div-400 400 mod 0= ;
: div-100 100 mod 0= ;
: not-div-100 div-100 invert ;
: div-4 4 mod 0= ;

( not divisible by 100 or divisible by 400 )
: not-100-or-400 ( n -- n )
    dup not-div-100 swap div-400 or ;

: leap dup div-4 swap not-100-or-400 and ;

: print dup ." year " . ;

\ 1900 print leap . cr
\ 2000 print leap . cr
\ 1999 print leap . cr
\ 2024 print leap . cr

