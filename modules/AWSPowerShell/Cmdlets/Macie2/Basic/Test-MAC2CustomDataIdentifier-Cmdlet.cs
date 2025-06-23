/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.Macie2;
using Amazon.Macie2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Tests criteria for a custom data identifier.
    /// </summary>
    [Cmdlet("Test", "MAC2CustomDataIdentifier")]
    [OutputType("System.Int32")]
    [AWSCmdlet("Calls the Amazon Macie 2 TestCustomDataIdentifier API operation.", Operation = new[] {"TestCustomDataIdentifier"}, SelectReturnType = typeof(Amazon.Macie2.Model.TestCustomDataIdentifierResponse))]
    [AWSCmdletOutput("System.Int32 or Amazon.Macie2.Model.TestCustomDataIdentifierResponse",
        "This cmdlet returns a collection of System.Int32 objects.",
        "The service call response (type Amazon.Macie2.Model.TestCustomDataIdentifierResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestMAC2CustomDataIdentifierCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IgnoreWord
        /// <summary>
        /// <para>
        /// <para>An array that lists specific character sequences (<i>ignore words</i>) to exclude
        /// from the results. If the text matched by the regular expression contains any string
        /// in this array, Amazon Macie ignores it. The array can contain as many as 10 ignore
        /// words. Each ignore word can contain 4-90 UTF-8 characters. Ignore words are case sensitive.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IgnoreWords")]
        public System.String[] IgnoreWord { get; set; }
        #endregion
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para>An array that lists specific character sequences (<i>keywords</i>), one of which must
        /// precede and be within proximity (maximumMatchDistance) of the regular expression to
        /// match. The array can contain as many as 50 keywords. Each keyword can contain 3-90
        /// UTF-8 characters. Keywords aren't case sensitive.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Keywords")]
        public System.String[] Keyword { get; set; }
        #endregion
        
        #region Parameter MaximumMatchDistance
        /// <summary>
        /// <para>
        /// <para>The maximum number of characters that can exist between the end of at least one complete
        /// character sequence specified by the keywords array and the end of the text that matches
        /// the regex pattern. If a complete keyword precedes all the text that matches the pattern
        /// and the keyword is within the specified distance, Amazon Macie includes the result.
        /// The distance can be 1-300 characters. The default value is 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaximumMatchDistance { get; set; }
        #endregion
        
        #region Parameter Regex
        /// <summary>
        /// <para>
        /// <para>The regular expression (<i>regex</i>) that defines the pattern to match. The expression
        /// can contain as many as 512 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Regex { get; set; }
        #endregion
        
        #region Parameter SampleText
        /// <summary>
        /// <para>
        /// <para>The sample text to inspect by using the custom data identifier. The text can contain
        /// as many as 1,000 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SampleText { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MatchCount'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.TestCustomDataIdentifierResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.TestCustomDataIdentifierResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MatchCount";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.TestCustomDataIdentifierResponse, TestMAC2CustomDataIdentifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.IgnoreWord != null)
            {
                context.IgnoreWord = new List<System.String>(this.IgnoreWord);
            }
            if (this.Keyword != null)
            {
                context.Keyword = new List<System.String>(this.Keyword);
            }
            context.MaximumMatchDistance = this.MaximumMatchDistance;
            context.Regex = this.Regex;
            #if MODULAR
            if (this.Regex == null && ParameterWasBound(nameof(this.Regex)))
            {
                WriteWarning("You are passing $null as a value for parameter Regex which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SampleText = this.SampleText;
            #if MODULAR
            if (this.SampleText == null && ParameterWasBound(nameof(this.SampleText)))
            {
                WriteWarning("You are passing $null as a value for parameter SampleText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Macie2.Model.TestCustomDataIdentifierRequest();
            
            if (cmdletContext.IgnoreWord != null)
            {
                request.IgnoreWords = cmdletContext.IgnoreWord;
            }
            if (cmdletContext.Keyword != null)
            {
                request.Keywords = cmdletContext.Keyword;
            }
            if (cmdletContext.MaximumMatchDistance != null)
            {
                request.MaximumMatchDistance = cmdletContext.MaximumMatchDistance.Value;
            }
            if (cmdletContext.Regex != null)
            {
                request.Regex = cmdletContext.Regex;
            }
            if (cmdletContext.SampleText != null)
            {
                request.SampleText = cmdletContext.SampleText;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Macie2.Model.TestCustomDataIdentifierResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.TestCustomDataIdentifierRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "TestCustomDataIdentifier");
            try
            {
                return client.TestCustomDataIdentifierAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> IgnoreWord { get; set; }
            public List<System.String> Keyword { get; set; }
            public System.Int32? MaximumMatchDistance { get; set; }
            public System.String Regex { get; set; }
            public System.String SampleText { get; set; }
            public System.Func<Amazon.Macie2.Model.TestCustomDataIdentifierResponse, TestMAC2CustomDataIdentifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MatchCount;
        }
        
    }
}
