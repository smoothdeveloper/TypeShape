#I "../tests/TypeShape.Tests/bin/Release/net461"
#r "TypeShape.dll"
#r "FsCheck.dll"
#r "TypeShape.Tests.dll"

open FsCheck

// Provides facility for testing generic programs:
// uses FsCheck to auto-generate types from a fixed algebra,
// then uses TypeShape to run nested checks for values of each type.
open TypeShape.Tests.GenericTests

// test the setup

#load "equality-comparer.fsx"
open ``Equality-comparer``

// check if our equality comparer satisfies reflexivivity
Check.GenericPredicate true false 100 100 
    { new Predicate with 
        member __.Invoke (t : 'T) =
            let cmp = comparer<'T>
            cmp.Equals(t,t) }