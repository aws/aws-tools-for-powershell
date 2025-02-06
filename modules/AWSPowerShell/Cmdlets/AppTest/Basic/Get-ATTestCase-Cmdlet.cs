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
    /// Gets a test case.
    /// </summary>
    [Cmdlet("Get", "ATTestCase")]
    [OutputType("Amazon.AppTest.Model.GetTestCaseResponse")]
    [AWSCmdlet("Calls the AWS Mainframe Modernization Application Testing GetTestCase API operation.", Operation = new[] {"GetTestCase"}, SelectReturnType = typeof(Amazon.AppTest.Model.GetTestCaseResponse))]
    [AWSCmdletOutput("Amazon.AppTest.Model.GetTestCaseResponse",
        "This cmdlet returns an Amazon.AppTest.Model.GetTestCaseResponse object containing multiple properties."
    )]
    public partial class GetATTestCaseCmdlet : AmazonAppTestClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TestCaseId
        /// <summary>
        /// <para>
        /// <para>The request test ID of the test case.</para>
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
        public System.String TestCaseId { get; set; }
        #endregion
        
        #region Parameter TestCaseVersion
        /// <summary>
        /// <para>
        /// <para>The test case version of the test case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TestCaseVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppTest.Model.GetTestCaseResponse).
        /// Specifying the name of a property of type Amazon.AppTest.Model.GetTestCaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppTest.Model.GetTestCaseResponse, GetATTestCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TestCaseId = this.TestCaseId;
            #if MODULAR
            if (this.TestCaseId == null && ParameterWasBound(nameof(this.TestCaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestCaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestCaseVersion = this.TestCaseVersion;
            
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
            var request = new Amazon.AppTest.Model.GetTestCaseRequest();
            
            if (cmdletContext.TestCaseId != null)
            {
                request.TestCaseId = cmdletContext.TestCaseId;
            }
            if (cmdletContext.TestCaseVersion != null)
            {
                request.TestCaseVersion = cmdletContext.TestCaseVersion.Value;
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
        
        private Amazon.AppTest.Model.GetTestCaseResponse CallAWSServiceOperation(IAmazonAppTest client, Amazon.AppTest.Model.GetTestCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mainframe Modernization Application Testing", "GetTestCase");
            try
            {
                #if DESKTOP
                return client.GetTestCase(request);
                #elif CORECLR
                return client.GetTestCaseAsync(request).GetAwaiter().GetResult();
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
            public System.String TestCaseId { get; set; }
            public System.Int32? TestCaseVersion { get; set; }
            public System.Func<Amazon.AppTest.Model.GetTestCaseResponse, GetATTestCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
