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

