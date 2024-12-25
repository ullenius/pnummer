s" pnummer.fs" included
s" date.fs" included

: substring ( addr u n -- addr2 u2 )
    2dup
    <
    if
        ." string too short"
        abort
    then
        \ increase start pos by + n
    dup >r - swap r> + swap
;

: main
    \ TODO validate argc
    next-arg 2dup
    drop valid-century
    if
        2 substring \ remove century digits
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
