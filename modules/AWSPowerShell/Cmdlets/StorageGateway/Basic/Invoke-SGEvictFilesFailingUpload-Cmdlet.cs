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
    /// Starts a process that cleans the specified file share's cache of file entries that
    /// are failing upload to Amazon S3. This API operation reports success if the request
    /// is received with valid arguments, and there are no other cache clean operations currently
    /// in-progress for the specified file share. After a successful request, the cache clean
    /// operation occurs asynchronously and reports progress using CloudWatch logs and notifications.
    /// 
    ///  <important><para>
    /// If <c>ForceRemove</c> is set to <c>True</c>, the cache clean operation will delete
    /// file data from the gateway which might otherwise be recoverable. We recommend using
    /// this operation only after all other methods to clear files failing upload have been
    /// exhausted, and if your business need outweighs the potential data loss.
    /// </para></important>
    /// </summary>
    [Cmdlet("Invoke", "SGEvictFilesFailingUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway EvictFilesFailingUpload API operation.", Operation = new[] {"EvictFilesFailingUpload"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeSGEvictFilesFailingUploadCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FileShareARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the file share for which you want to start the cache
        /// clean operation.</para>
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
        public System.String FileShareARN { get; set; }
        #endregion
        
        #region Parameter ForceRemove
        /// <summary>
        /// <para>
        /// <para>Specifies whether cache entries with full or partial file data currently stored on
        /// the gateway will be forcibly removed by the cache clean operation.</para><para>Valid arguments:</para><ul><li><para><c>False</c> - The cache clean operation skips cache entries failing upload if they
        /// are associated with data currently stored on the gateway. This preserves the cached
        /// data.</para></li><li><para><c>True</c> - The cache clean operation removes cache entries failing upload even
        /// if they are associated with data currently stored on the gateway. This deletes the
        /// cached data.</para><important><para>If <c>ForceRemove</c> is set to <c>True</c>, the cache clean operation will delete
        /// file data from the gateway which might otherwise be recoverable.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceRemove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotificationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotificationId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileShareARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SGEvictFilesFailingUpload (EvictFilesFailingUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse, InvokeSGEvictFilesFailingUploadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileShareARN = this.FileShareARN;
            #if MODULAR
            if (this.FileShareARN == null && ParameterWasBound(nameof(this.FileShareARN)))
            {
                WriteWarning("You are passing $null as a value for parameter FileShareARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForceRemove = this.ForceRemove;
            
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
            var request = new Amazon.StorageGateway.Model.EvictFilesFailingUploadRequest();
            
            if (cmdletContext.FileShareARN != null)
            {
                request.FileShareARN = cmdletContext.FileShareARN;
            }
            if (cmdletContext.ForceRemove != null)
            {
                request.ForceRemove = cmdletContext.ForceRemove.Value;
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
        
        private Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.EvictFilesFailingUploadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "EvictFilesFailingUpload");
            try
            {
                return client.EvictFilesFailingUploadAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FileShareARN { get; set; }
            public System.Boolean? ForceRemove { get; set; }
            public System.Func<Amazon.StorageGateway.Model.EvictFilesFailingUploadResponse, InvokeSGEvictFilesFailingUploadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotificationId;
        }
        
    }
}
