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
using Amazon.CodeConnections;
using Amazon.CodeConnections.Model;

namespace Amazon.PowerShell.Cmdlets.CCON
{
    /// <summary>
    /// Returns the connection ARN and details such as status, owner, and provider type.
    /// </summary>
    [Cmdlet("Get", "CCONConnection")]
    [OutputType("Amazon.CodeConnections.Model.Connection")]
    [AWSCmdlet("Calls the AWS CodeConnections GetConnection API operation.", Operation = new[] {"GetConnection"}, SelectReturnType = typeof(Amazon.CodeConnections.Model.GetConnectionResponse))]
    [AWSCmdletOutput("Amazon.CodeConnections.Model.Connection or Amazon.CodeConnections.Model.GetConnectionResponse",
        "This cmdlet returns an Amazon.CodeConnections.Model.Connection object.",
        "The service call response (type Amazon.CodeConnections.Model.GetConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCCONConnectionCmdlet : AmazonCodeConnectionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a connection.</para>
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
        public System.String ConnectionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeConnections.Model.GetConnectionResponse).
        /// Specifying the name of a property of type Amazon.CodeConnections.Model.GetConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connection";
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
                context.Select = CreateSelectDelegate<Amazon.CodeConnections.Model.GetConnectionResponse, GetCCONConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionArn = this.ConnectionArn;
            #if MODULAR
            if (this.ConnectionArn == null && ParameterWasBound(nameof(this.ConnectionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeConnections.Model.GetConnectionRequest();
            
            if (cmdletContext.ConnectionArn != null)
            {
                request.ConnectionArn = cmdletContext.ConnectionArn;
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
        
        private Amazon.CodeConnections.Model.GetConnectionResponse CallAWSServiceOperation(IAmazonCodeConnections client, Amazon.CodeConnections.Model.GetConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeConnections", "GetConnection");
            try
            {
                return client.GetConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectionArn { get; set; }
            public System.Func<Amazon.CodeConnections.Model.GetConnectionResponse, GetCCONConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connection;
        }
        
    }
}
