\ date words
\  s" common.fs" included

create months 
0 c, \ filler
31 c, 28 c, 31 c, \ jan, feb, mars
30 c, 31 c, 30 c, \ april, may, june
31 c, 31 c, 30 c, \ july, august, september
31 c, 30 c, 31 c, \ october, november, december

: month ( month -- n ) months + c@ ;

: parseYear ( addr -- year )
    dup 0 + ascii2digit 1000 * swap
    dup 1 + ascii2digit 100 * swap
    dup 2 + ascii2digit 10 * swap
    3 + ascii2digit
    + + +
;

: parseMonth ( addr -- month )
    dup 
    0 + ascii2digit 10 * swap
    1 + ascii2digit
    +
;

: parseDay ( addr - days ) parseMonth ;

: parseDate ( addr u - year month day ) \ YYYYmmDD
    dup parseYear
    swap
    4 + dup parseMonth
    swap
    2 + parseDay
;

: valid-month ( n -- f ) dup 0> swap 13 < and ;

\ TODO check leap year
: valid-monthday ( month day -- f ) swap month 1 + < ;

: valid-century ( addr -- f )
    parseYear
    100 /
    case
        20 of true endof
        19 of true endof
        18 of true endof
        >r false r>
    endcase
;

: assertEquals ( actual, expected -- ) = 0= if abort then ;

1 month 31 assertEquals
2 month 28 assertEquals
3 month 31 assertEquals
4 month 30 assertEquals
5 month 31 assertEquals
6 month 30 assertEquals
7 month 31 assertEquals
8 month 31 assertEquals
9 month 30 assertEquals
10 month 31 assertEquals
11 month 30 assertEquals
12 month 31 assertEquals

