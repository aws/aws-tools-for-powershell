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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Retrieves an archived virtual tape from the virtual tape shelf (VTS) to a tape gateway.
    /// Virtual tapes archived in the VTS are not associated with any gateway. However after
    /// a tape is retrieved, it is associated with a gateway, even though it is also listed
    /// in the VTS, that is, archive. This operation is only supported in the tape gateway
    /// type.
    /// 
    ///  
    /// <para>
    /// Once a tape is successfully retrieved to a gateway, it cannot be retrieved again to
    /// another gateway. You must archive the tape again before you can retrieve it to another
    /// gateway. This operation is only supported in the tape gateway type.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SGTapeArchive")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway RetrieveTapeArchive API operation.", Operation = new[] {"RetrieveTapeArchive"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSGTapeArchiveCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway you want to retrieve the virtual tape
        /// to. Use the <a>ListGateways</a> operation to return a list of gateways for your account
        /// and Amazon Web Services Region.</para><para>You retrieve archived virtual tapes to only one gateway and the gateway must be a
        /// tape gateway.</para>
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter TapeARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the virtual tape you want to retrieve from the virtual
        /// tape shelf (VTS).</para>
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
        public System.String TapeARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TapeARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TapeARN";
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
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse, GetSGTapeArchiveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TapeARN = this.TapeARN;
            #if MODULAR
            if (this.TapeARN == null && ParameterWasBound(nameof(this.TapeARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TapeARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.RetrieveTapeArchiveRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.TapeARN != null)
            {
                request.TapeARN = cmdletContext.TapeARN;
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
        
        private Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.RetrieveTapeArchiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "RetrieveTapeArchive");
            try
            {
                return client.RetrieveTapeArchiveAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GatewayARN { get; set; }
            public System.String TapeARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.RetrieveTapeArchiveResponse, GetSGTapeArchiveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TapeARN;
        }
        
    }
}
