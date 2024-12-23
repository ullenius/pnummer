# personnummer-forth

Validerar svenska personnummer.

Usage: gforth pnummer.fs PERSONNUMMER -e bye


## Format
Format på personnummer: ÅÅMMDDXXXC

* ÅÅ = År (till exempel 00)
* MM = Måndag 01-12

* XXX - födelsenummer

* C - kontrollsiffra (luhn-algoritm)
