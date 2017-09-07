AskToni API Testing Approach
============================
Test Projects and File Structure
--------------------------------
Integration Tests:
UnitTests:
TestsCore: This contains useful classes for testing
* TestingObject.cs : A wrapper class for mocks with dependancies, see [1]

References
----------
For unit testing, this is the [main guide][1] initially followed.
For integration testing (though is also references unit testing), this [microsoft docs][2] article was referenced

[1]: https://rushfive.github.io/Start-Unit-Testing-with-xUnit-Moq/   "unit testing with xUnit & Moq"
[2]: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing "MS Docs on controller testing"