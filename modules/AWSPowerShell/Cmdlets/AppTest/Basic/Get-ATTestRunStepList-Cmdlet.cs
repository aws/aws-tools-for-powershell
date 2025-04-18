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
using Amazon.AppTest;
using Amazon.AppTest.Model;

namespace Amazon.PowerShell.Cmdlets.AT
{
    /// <summary>
    /// Lists test run steps.
    /// </summary>
    [Cmdlet("Get", "ATTestRunStepList")]
    [OutputType("Amazon.AppTest.Model.TestRunStepSummary")]
    [AWSCmdlet("Calls the AWS Mainframe Modernization Application Testing ListTestRunSteps API operation.", Operation = new[] {"ListTestRunSteps"}, SelectReturnType = typeof(Amazon.AppTest.Model.ListTestRunStepsResponse))]
    [AWSCmdletOutput("Amazon.AppTest.Model.TestRunStepSummary or Amazon.AppTest.Model.ListTestRunStepsResponse",
        "This cmdlet returns a collection of Amazon.AppTest.Model.TestRunStepSummary objects.",
        "The service call response (type Amazon.AppTest.Model.ListTestRunStepsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetATTestRunStepListCmdlet : AmazonAppTestClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TestCaseId
        /// <summary>
        /// <para>
        /// <para>The test case ID of the test run steps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestCaseId { get; set; }
        #endregion
        
        #region Parameter TestRunId
        /// <summary>
        /// <para>
        /// <para>The test run ID of the test run steps.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TestRunId { get; set; }
        #endregion
        
        #region Parameter TestSuiteId
        /// <summary>
        /// <para>
        /// <para>The test suite ID of the test run steps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestSuiteId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of test run steps to return in one page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token from a previous step to retrieve the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TestRunSteps'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppTest.Model.ListTestRunStepsResponse).
        /// Specifying the name of a property of type Amazon.AppTest.Model.ListTestRunStepsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TestRunSteps";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TestRunId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TestRunId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TestRunId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppTest.Model.ListTestRunStepsResponse, GetATTestRunStepListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TestRunId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TestCaseId = this.TestCaseId;
            context.TestRunId = this.TestRunId;
            #if MODULAR
            if (this.TestRunId == null && ParameterWasBound(nameof(this.TestRunId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestRunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestSuiteId = this.TestSuiteId;
            
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
            var request = new Amazon.AppTest.Model.ListTestRunStepsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TestCaseId != null)
            {
                request.TestCaseId = cmdletContext.TestCaseId;
            }
            if (cmdletContext.TestRunId != null)
            {
                request.TestRunId = cmdletContext.TestRunId;
            }
            if (cmdletContext.TestSuiteId != null)
            {
                request.TestSuiteId = cmdletContext.TestSuiteId;
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
        
        private Amazon.AppTest.Model.ListTestRunStepsResponse CallAWSServiceOperation(IAmazonAppTest client, Amazon.AppTest.Model.ListTestRunStepsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mainframe Modernization Application Testing", "ListTestRunSteps");
            try
            {
                #if DESKTOP
                return client.ListTestRunSteps(request);
                #elif CORECLR
                return client.ListTestRunStepsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String TestCaseId { get; set; }
            public System.String TestRunId { get; set; }
            public System.String TestSuiteId { get; set; }
            public System.Func<Amazon.AppTest.Model.ListTestRunStepsResponse, GetATTestRunStepListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TestRunSteps;
        }
        
    }
}
