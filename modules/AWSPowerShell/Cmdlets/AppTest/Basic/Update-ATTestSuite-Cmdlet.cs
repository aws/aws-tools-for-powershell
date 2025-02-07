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
    /// Updates a test suite.
    /// </summary>
    [Cmdlet("Update", "ATTestSuite", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppTest.Model.UpdateTestSuiteResponse")]
    [AWSCmdlet("Calls the AWS Mainframe Modernization Application Testing UpdateTestSuite API operation.", Operation = new[] {"UpdateTestSuite"}, SelectReturnType = typeof(Amazon.AppTest.Model.UpdateTestSuiteResponse))]
    [AWSCmdletOutput("Amazon.AppTest.Model.UpdateTestSuiteResponse",
        "This cmdlet returns an Amazon.AppTest.Model.UpdateTestSuiteResponse object containing multiple properties."
    )]
    public partial class UpdateATTestSuiteCmdlet : AmazonAppTestClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AfterStep
        /// <summary>
        /// <para>
        /// <para>The after steps of the test suite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AfterSteps")]
        public Amazon.AppTest.Model.Step[] AfterStep { get; set; }
        #endregion
        
        #region Parameter BeforeStep
        /// <summary>
        /// <para>
        /// <para>The before steps for the test suite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BeforeSteps")]
        public Amazon.AppTest.Model.Step[] BeforeStep { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the test suite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TestCases_Sequential
        /// <summary>
        /// <para>
        /// <para>The sequential of the test case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TestCases_Sequential { get; set; }
        #endregion
        
        #region Parameter TestSuiteId
        /// <summary>
        /// <para>
        /// <para>The test suite ID of the test suite.</para>
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
        public System.String TestSuiteId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppTest.Model.UpdateTestSuiteResponse).
        /// Specifying the name of a property of type Amazon.AppTest.Model.UpdateTestSuiteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TestSuiteId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ATTestSuite (UpdateTestSuite)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppTest.Model.UpdateTestSuiteResponse, UpdateATTestSuiteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AfterStep != null)
            {
                context.AfterStep = new List<Amazon.AppTest.Model.Step>(this.AfterStep);
            }
            if (this.BeforeStep != null)
            {
                context.BeforeStep = new List<Amazon.AppTest.Model.Step>(this.BeforeStep);
            }
            context.Description = this.Description;
            if (this.TestCases_Sequential != null)
            {
                context.TestCases_Sequential = new List<System.String>(this.TestCases_Sequential);
            }
            context.TestSuiteId = this.TestSuiteId;
            #if MODULAR
            if (this.TestSuiteId == null && ParameterWasBound(nameof(this.TestSuiteId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestSuiteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppTest.Model.UpdateTestSuiteRequest();
            
            if (cmdletContext.AfterStep != null)
            {
                request.AfterSteps = cmdletContext.AfterStep;
            }
            if (cmdletContext.BeforeStep != null)
            {
                request.BeforeSteps = cmdletContext.BeforeStep;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate TestCases
            var requestTestCasesIsNull = true;
            request.TestCases = new Amazon.AppTest.Model.TestCases();
            List<System.String> requestTestCases_testCases_Sequential = null;
            if (cmdletContext.TestCases_Sequential != null)
            {
                requestTestCases_testCases_Sequential = cmdletContext.TestCases_Sequential;
            }
            if (requestTestCases_testCases_Sequential != null)
            {
                request.TestCases.Sequential = requestTestCases_testCases_Sequential;
                requestTestCasesIsNull = false;
            }
             // determine if request.TestCases should be set to null
            if (requestTestCasesIsNull)
            {
                request.TestCases = null;
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
        
        private Amazon.AppTest.Model.UpdateTestSuiteResponse CallAWSServiceOperation(IAmazonAppTest client, Amazon.AppTest.Model.UpdateTestSuiteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mainframe Modernization Application Testing", "UpdateTestSuite");
            try
            {
                #if DESKTOP
                return client.UpdateTestSuite(request);
                #elif CORECLR
                return client.UpdateTestSuiteAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.AppTest.Model.Step> AfterStep { get; set; }
            public List<Amazon.AppTest.Model.Step> BeforeStep { get; set; }
            public System.String Description { get; set; }
            public List<System.String> TestCases_Sequential { get; set; }
            public System.String TestSuiteId { get; set; }
            public System.Func<Amazon.AppTest.Model.UpdateTestSuiteResponse, UpdateATTestSuiteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
