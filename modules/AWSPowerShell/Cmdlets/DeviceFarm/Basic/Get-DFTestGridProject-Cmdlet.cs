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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Retrieves information about a Selenium testing project.
    /// </summary>
    [Cmdlet("Get", "DFTestGridProject")]
    [OutputType("Amazon.DeviceFarm.Model.TestGridProject")]
    [AWSCmdlet("Calls the AWS Device Farm GetTestGridProject API operation.", Operation = new[] {"GetTestGridProject"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.GetTestGridProjectResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.TestGridProject or Amazon.DeviceFarm.Model.GetTestGridProjectResponse",
        "This cmdlet returns an Amazon.DeviceFarm.Model.TestGridProject object.",
        "The service call response (type Amazon.DeviceFarm.Model.GetTestGridProjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDFTestGridProjectCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Selenium testing project, from either <a>CreateTestGridProject</a>
        /// or <a>ListTestGridProjects</a>.</para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TestGridProject'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.GetTestGridProjectResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.GetTestGridProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TestGridProject";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.GetTestGridProjectResponse, GetDFTestGridProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DeviceFarm.Model.GetTestGridProjectRequest();
            
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
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
        
        private Amazon.DeviceFarm.Model.GetTestGridProjectResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.GetTestGridProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "GetTestGridProject");
            try
            {
                return client.GetTestGridProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProjectArn { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.GetTestGridProjectResponse, GetDFTestGridProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TestGridProject;
        }
        
    }
}
