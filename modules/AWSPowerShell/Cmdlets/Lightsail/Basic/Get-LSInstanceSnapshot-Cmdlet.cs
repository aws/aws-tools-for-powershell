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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns information about a specific instance snapshot.
    /// </summary>
    [Cmdlet("Get", "LSInstanceSnapshot")]
    [OutputType("Amazon.Lightsail.Model.InstanceSnapshot")]
    [AWSCmdlet("Calls the Amazon Lightsail GetInstanceSnapshot API operation.", Operation = new[] {"GetInstanceSnapshot"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetInstanceSnapshotResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.InstanceSnapshot or Amazon.Lightsail.Model.GetInstanceSnapshotResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.InstanceSnapshot object.",
        "The service call response (type Amazon.Lightsail.Model.GetInstanceSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLSInstanceSnapshotCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the snapshot for which you are requesting information.</para>
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
        public System.String InstanceSnapshotName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceSnapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetInstanceSnapshotResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetInstanceSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceSnapshot";
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
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetInstanceSnapshotResponse, GetLSInstanceSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceSnapshotName = this.InstanceSnapshotName;
            #if MODULAR
            if (this.InstanceSnapshotName == null && ParameterWasBound(nameof(this.InstanceSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.GetInstanceSnapshotRequest();
            
            if (cmdletContext.InstanceSnapshotName != null)
            {
                request.InstanceSnapshotName = cmdletContext.InstanceSnapshotName;
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
        
        private Amazon.Lightsail.Model.GetInstanceSnapshotResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetInstanceSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetInstanceSnapshot");
            try
            {
                return client.GetInstanceSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceSnapshotName { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetInstanceSnapshotResponse, GetLSInstanceSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceSnapshot;
        }
        
    }
}
