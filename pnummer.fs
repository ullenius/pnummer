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

\ luhn-algorithm

s" common.fs" included

9 constant CHECK_DIGIT_POS

: 10mod 10 mod ;

\ TODO better name
: luhn ( sum -- n ) 10mod negate 10 + 10mod ; \ (10 - (sum mod 10)) mod 10

: double ( n -- 2n ) 2 * ;

: even ( n -- f ) 1 and 0= ;

: one-digit ( u -- u2 ) dup 9 > if 9 - then ;

variable sum

: ignore-check-digit ( addr u -- addr u2 ) 1 - ;

: double-if-even ( n -- n2 ) even if double one-digit then ;

: iter ( addr u -- sum ) \ luhn-digit sum
    ignore-check-digit
    0 do dup i + ascii2digit
    i double-if-even
    sum +! loop
drop sum @
;

: last-digit ( addr u -- n ) drop CHECK_DIGIT_POS + ascii2digit ;

