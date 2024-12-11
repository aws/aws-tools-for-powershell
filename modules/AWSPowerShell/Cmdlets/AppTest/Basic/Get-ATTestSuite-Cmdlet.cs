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
    /// Gets a test suite.
    /// </summary>
    [Cmdlet("Get", "ATTestSuite")]
    [OutputType("Amazon.AppTest.Model.GetTestSuiteResponse")]
    [AWSCmdlet("Calls the AWS Mainframe Modernization Application Testing GetTestSuite API operation.", Operation = new[] {"GetTestSuite"}, SelectReturnType = typeof(Amazon.AppTest.Model.GetTestSuiteResponse))]
    [AWSCmdletOutput("Amazon.AppTest.Model.GetTestSuiteResponse",
        "This cmdlet returns an Amazon.AppTest.Model.GetTestSuiteResponse object containing multiple properties."
    )]
    public partial class GetATTestSuiteCmdlet : AmazonAppTestClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TestSuiteId
        /// <summary>
        /// <para>
        /// <para>The ID of the test suite.</para>
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
        
        #region Parameter TestSuiteVersion
        /// <summary>
        /// <para>
        /// <para>The version of the test suite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TestSuiteVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppTest.Model.GetTestSuiteResponse).
        /// Specifying the name of a property of type Amazon.AppTest.Model.GetTestSuiteResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.AppTest.Model.GetTestSuiteResponse, GetATTestSuiteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TestSuiteId = this.TestSuiteId;
            #if MODULAR
            if (this.TestSuiteId == null && ParameterWasBound(nameof(this.TestSuiteId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestSuiteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestSuiteVersion = this.TestSuiteVersion;
            
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
            var request = new Amazon.AppTest.Model.GetTestSuiteRequest();
            
            if (cmdletContext.TestSuiteId != null)
            {
                request.TestSuiteId = cmdletContext.TestSuiteId;
            }
            if (cmdletContext.TestSuiteVersion != null)
            {
                request.TestSuiteVersion = cmdletContext.TestSuiteVersion.Value;
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
        
        private Amazon.AppTest.Model.GetTestSuiteResponse CallAWSServiceOperation(IAmazonAppTest client, Amazon.AppTest.Model.GetTestSuiteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mainframe Modernization Application Testing", "GetTestSuite");
            try
            {
                #if DESKTOP
                return client.GetTestSuite(request);
                #elif CORECLR
                return client.GetTestSuiteAsync(request).GetAwaiter().GetResult();
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
            public System.String TestSuiteId { get; set; }
            public System.Int32? TestSuiteVersion { get; set; }
            public System.Func<Amazon.AppTest.Model.GetTestSuiteResponse, GetATTestSuiteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
