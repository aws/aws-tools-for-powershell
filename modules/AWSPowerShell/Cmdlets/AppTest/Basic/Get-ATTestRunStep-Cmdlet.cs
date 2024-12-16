/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Gets a test run step.
    /// </summary>
    [Cmdlet("Get", "ATTestRunStep")]
    [OutputType("Amazon.AppTest.Model.GetTestRunStepResponse")]
    [AWSCmdlet("Calls the AWS Mainframe Modernization Application Testing GetTestRunStep API operation.", Operation = new[] {"GetTestRunStep"}, SelectReturnType = typeof(Amazon.AppTest.Model.GetTestRunStepResponse))]
    [AWSCmdletOutput("Amazon.AppTest.Model.GetTestRunStepResponse",
        "This cmdlet returns an Amazon.AppTest.Model.GetTestRunStepResponse object containing multiple properties."
    )]
    public partial class GetATTestRunStepCmdlet : AmazonAppTestClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StepName
        /// <summary>
        /// <para>
        /// <para>The step name of the test run step.</para>
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
        public System.String StepName { get; set; }
        #endregion
        
        #region Parameter TestCaseId
        /// <summary>
        /// <para>
        /// <para>The test case ID of a test run step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestCaseId { get; set; }
        #endregion
        
        #region Parameter TestRunId
        /// <summary>
        /// <para>
        /// <para>The test run ID of the test run step.</para>
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
        /// <para>The test suite ID of a test run step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestSuiteId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppTest.Model.GetTestRunStepResponse).
        /// Specifying the name of a property of type Amazon.AppTest.Model.GetTestRunStepResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.AppTest.Model.GetTestRunStepResponse, GetATTestRunStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StepName = this.StepName;
            #if MODULAR
            if (this.StepName == null && ParameterWasBound(nameof(this.StepName)))
            {
                WriteWarning("You are passing $null as a value for parameter StepName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.AppTest.Model.GetTestRunStepRequest();
            
            if (cmdletContext.StepName != null)
            {
                request.StepName = cmdletContext.StepName;
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
        
        private Amazon.AppTest.Model.GetTestRunStepResponse CallAWSServiceOperation(IAmazonAppTest client, Amazon.AppTest.Model.GetTestRunStepRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mainframe Modernization Application Testing", "GetTestRunStep");
            try
            {
                #if DESKTOP
                return client.GetTestRunStep(request);
                #elif CORECLR
                return client.GetTestRunStepAsync(request).GetAwaiter().GetResult();
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
            public System.String StepName { get; set; }
            public System.String TestCaseId { get; set; }
            public System.String TestRunId { get; set; }
            public System.String TestSuiteId { get; set; }
            public System.Func<Amazon.AppTest.Model.GetTestRunStepResponse, GetATTestRunStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
