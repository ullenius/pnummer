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
