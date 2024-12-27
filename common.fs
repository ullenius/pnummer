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

: ascii2digit ( addr - n ) c@ 0x30 - ;

