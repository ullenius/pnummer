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

: main \ argv: YYYYmmDDXXXC
    \ TODO validate argc
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
