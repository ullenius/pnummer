s" pnummer.fs" included

: main
    \ TODO validate argc
    next-arg 2dup
    iter luhn
    >r last-digit r>
    = \ compare calculated digit to actual
    invert
    (bye)
;

main
