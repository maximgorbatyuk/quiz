# Findings

## General C# 

1. Synchronous calls of async methods (on sqlDbRepository, HttpClient)
2.Missed usage of disposable pattern for HttpClient (Here we can ask about HttpClientusing best practices: HttpClientFactory etc.)

## CLEAN CODE

1. Method length and readability
2. Variables naming (value1, value2 etc)
3. Magic strings and numbers 
4. Hardcoded id's and URL's
5. Comments style
6. Code duplication ((value1 + value2) / 2)
7. Exception handling and throwing (return -1, no try..catch)

## OOD

1. Static class
2. General size, testability + cyclomatic complexity
3. Violation of dependency inversion principle (Explicit creation of SqlDbRepository)
4. Use of Singleton(UserRatingCache.GetInstance())
5. Single responsibility principle violation. How to refactor? Strategy pattern?
6. Get method has side effects (saveToDb)

## SECURITY

1. Storing connection string with password in code
2. Sending password via http with Basic Authorization

## General logic

1. Missed caching after calculation
