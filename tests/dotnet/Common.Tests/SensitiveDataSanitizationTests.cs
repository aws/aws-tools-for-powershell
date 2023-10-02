using Common.Tests.TestHelpers;
using System.Reflection;

namespace Common.Tests;

[TestClass]
public class SensitiveDataSanitizationTests
{

    [TestMethod]
    public void TestSensitiveSanitizedData()
    {
        // Excluding Request/Response classes that are abstract or have no public default constructor
        // These are not being used in PowerShell
        List<string> exludeTypes = new List<string>
            {
                "Amazon.S3.Model.GetPreSignedUrlResponse",
                "Amazon.S3.Model.StreamResponse",
                "Amazon.S3.Model.PutWithACLRequest",
            };

        SensitiveDataSanitization.TestSensitiveSanitizedData(excludeTypes: exludeTypes);
    }

    [TestMethod]
    public void TestSanitizedDataDoesntThrowError()
    {
        // excluding Request/Response classes that are abstract or have no public default constructor
        // These are not being used in PowerShell
        List<string> exludeTypes = new List<string>
            {
                "Amazon.S3.Model.GetPreSignedUrlResponse",
                "Amazon.S3.Model.StreamResponse",
                "Amazon.S3.Model.PutWithACLRequest",
            };

        SensitiveDataSanitization.TestSanitizedDataDoesntThrowError(excludeTypes: exludeTypes);
    }

    [TestMethod]
    public void ValidateObjectsFullyInstantiated()
    {
        // excluding Request/Response classes that are abstract or have no public default constructor
        // These are not being used in PowerShell
        List<string> exludeTypes = new List<string>
            {
                "Amazon.S3.Model.GetPreSignedUrlResponse",
                "Amazon.S3.Model.StreamResponse",
                "Amazon.S3.Model.PutWithACLRequest",
            };

        SensitiveDataSanitization.ValidateObjectsFullyInstantiated(excludeTypes: exludeTypes);
    }


}