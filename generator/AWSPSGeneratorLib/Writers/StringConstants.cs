namespace AWSPowerShellGenerator.Writers
{
    internal abstract class StringConstants
    {
        public const string NoCmdletOutputText 
            = "By default, this cmdlet does not generate any output.";
        public const string ServiceResponseFormatText 
            = "The service response (type {0}) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.";
        public const string MultipleOutputPropertiesFormatText 
            = "This cmdlet returns a {0} object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.";

    }
}
