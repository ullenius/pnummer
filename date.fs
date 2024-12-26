\ date words
  s" common.fs" included
s" leap.fs" included

create months 
0 c, \ filler
31 c, 28 c, 31 c, \ jan, feb, mars
30 c, 31 c, 30 c, \ april, may, june
31 c, 31 c, 30 c, \ july, august, september
31 c, 30 c, 31 c, \ october, november, december

: february 2 = ;

: month ( year month -- n )
    dup >r \ save month
    months + c@
    r> february if
        swap leap - \ 28 - (-1) == 29
    else
        swap drop \ drop unused year
    then
;

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

: valid-monthday ( year month day -- f )
    swap month \ get number of days for month
    0 swap .s within \ day 0 days-per-month
;

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

2000 constant LEAP_YEAR
LEAP_YEAR 1 - constant NON_LEAP_YEAR

LEAP_YEAR 1 month 31 assertEquals
NON_LEAP_YEAR 2 month 28 assertEquals
LEAP_YEAR 2 month 29 assertEquals \ leap year
LEAP_YEAR 3 month 31 assertEquals
LEAP_YEAR 4 month 30 assertEquals
LEAP_YEAR 5 month 31 assertEquals
LEAP_YEAR 6 month 30 assertEquals
LEAP_YEAR 7 month 31 assertEquals
LEAP_YEAR 8 month 31 assertEquals
LEAP_YEAR 9 month 30 assertEquals
LEAP_YEAR 10 month 31 assertEquals
LEAP_YEAR 11 month 30 assertEquals
LEAP_YEAR 12 month 31 assertEquals

