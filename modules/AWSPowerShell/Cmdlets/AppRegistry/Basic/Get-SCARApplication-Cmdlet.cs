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
using Amazon.AppRegistry;
using Amazon.AppRegistry.Model;

namespace Amazon.PowerShell.Cmdlets.SCAR
{
    /// <summary>
    /// Retrieves metadata information about one of your applications. The application can
    /// be specified by its ARN, ID, or name (which is unique within one account in one region
    /// at a given point in time). Specify by ARN or ID in automated workflows if you want
    /// to make sure that the exact same application is returned or a <c>ResourceNotFoundException</c>
    /// is thrown, avoiding the ABA addressing problem.
    /// </summary>
    [Cmdlet("Get", "SCARApplication")]
    [OutputType("Amazon.AppRegistry.Model.GetApplicationResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog App Registry GetApplication API operation.", Operation = new[] {"GetApplication"}, SelectReturnType = typeof(Amazon.AppRegistry.Model.GetApplicationResponse))]
    [AWSCmdletOutput("Amazon.AppRegistry.Model.GetApplicationResponse",
        "This cmdlet returns an Amazon.AppRegistry.Model.GetApplicationResponse object containing multiple properties."
    )]
    public partial class GetSCARApplicationCmdlet : AmazonAppRegistryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para> The name, ID, or ARN of the application. </para>
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
        public System.String Application { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRegistry.Model.GetApplicationResponse).
        /// Specifying the name of a property of type Amazon.AppRegistry.Model.GetApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.AppRegistry.Model.GetApplicationResponse, GetSCARApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Application = this.Application;
            #if MODULAR
            if (this.Application == null && ParameterWasBound(nameof(this.Application)))
            {
                WriteWarning("You are passing $null as a value for parameter Application which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRegistry.Model.GetApplicationRequest();
            
            if (cmdletContext.Application != null)
            {
                request.Application = cmdletContext.Application;
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
        
        private Amazon.AppRegistry.Model.GetApplicationResponse CallAWSServiceOperation(IAmazonAppRegistry client, Amazon.AppRegistry.Model.GetApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog App Registry", "GetApplication");
            try
            {
                return client.GetApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Application { get; set; }
            public System.Func<Amazon.AppRegistry.Model.GetApplicationResponse, GetSCARApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
