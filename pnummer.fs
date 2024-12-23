\ luhn-algorithm

9 constant CHECK_DIGIT_POS

: ten-mod 10 mod ;

\ TODO better name
: luhn ( sum -- n ) ten-mod negate 10 + ten-mod ; \ (10 - (sum mod 10)) mod 10

: ascii2digit ( addr - n ) c@ 0x30 - ;

: double ( n -- 2n ) 2 * ;

: even ( n -- f ) 1 and 0= ;

: one-digit ( u -- u2 ) dup 9 > if 9 - then ;

variable sum

: iter ( addr u -- sum ) \ luhn-digit sum
    1 - \ ignore check digit
    0 do dup i + ascii2digit
    i even if \ double every second digit
        double one-digit
    then
    sum +! loop
drop sum @
;

: last-digit ( addr u -- n ) drop CHECK_DIGIT_POS + ascii2digit ;


: main
    \ TODO validate argc
    next-arg 2dup 
    iter luhn
    >r last-digit r>
    = \ compare calculated digit to actual
    invert
\    .s \ debug
    (bye)
;

 main

\ (bye) ( n -- ) - exit code to OS
\ argc ( -- addr ) c@ 
