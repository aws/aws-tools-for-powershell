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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Refreshes the cached inventory of objects for the specified file share. This operation
    /// finds objects in the Amazon S3 bucket that were added, removed, or replaced since
    /// the gateway last listed the bucket's contents and cached the results. This operation
    /// does not import files into the S3 File Gateway cache storage. It only updates the
    /// cached inventory to reflect changes in the inventory of the objects in the S3 bucket.
    /// This operation is only supported in the S3 File Gateway types.
    /// 
    ///  
    /// <para>
    /// You can subscribe to be notified through an Amazon CloudWatch event when your <code>RefreshCache</code>
    /// operation completes. For more information, see <a href="https://docs.aws.amazon.com/storagegateway/latest/userguide/monitoring-file-gateway.html#get-notification">Getting
    /// notified about file operations</a> in the <i>Storage Gateway User Guide</i>. This
    /// operation is Only supported for S3 File Gateways.
    /// </para><para>
    /// When this API is called, it only initiates the refresh operation. When the API call
    /// completes and returns a success code, it doesn't necessarily mean that the file refresh
    /// has completed. You should use the refresh-complete notification to determine that
    /// the operation has completed before you check for new files on the gateway file share.
    /// You can subscribe to be notified through a CloudWatch event when your <code>RefreshCache</code>
    /// operation completes.
    /// </para><para>
    /// Throttle limit: This API is asynchronous, so the gateway will accept no more than
    /// two refreshes at any time. We recommend using the refresh-complete CloudWatch event
    /// notification before issuing additional requests. For more information, see <a href="https://docs.aws.amazon.com/storagegateway/latest/userguide/monitoring-file-gateway.html#get-notification">Getting
    /// notified about file operations</a> in the <i>Storage Gateway User Guide</i>.
    /// </para><important><ul><li><para>
    /// Wait at least 60 seconds between consecutive RefreshCache API requests.
    /// </para></li><li><para>
    /// If you invoke the RefreshCache API when two requests are already being processed,
    /// any new request will cause an <code>InvalidGatewayRequestException</code> error because
    /// too many requests were sent to the server.
    /// </para></li></ul></important><note><para>
    /// The S3 bucket name does not need to be included when entering the list of folders
    /// in the FolderList parameter.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/storagegateway/latest/userguide/monitoring-file-gateway.html#get-notification">Getting
    /// notified about file operations</a> in the <i>Storage Gateway User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "SGCacheRefresh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.RefreshCacheResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway RefreshCache API operation.", Operation = new[] {"RefreshCache"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.RefreshCacheResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.RefreshCacheResponse",
        "This cmdlet returns an Amazon.StorageGateway.Model.RefreshCacheResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeSGCacheRefreshCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileShareARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the file share you want to refresh.</para>
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
        
        #region Parameter FolderList
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of the paths of folders to refresh in the cache. The default
        /// is [<code>"/"</code>]. The default refreshes objects and folders at the root of the
        /// Amazon S3 bucket. If <code>Recursive</code> is set to <code>true</code>, the entire
        /// S3 bucket that the file share has access to is refreshed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] FolderList { get; set; }
        #endregion
        
        #region Parameter Recursive
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether to recursively refresh folders in the cache. The refresh
        /// includes folders that were in the cache the last time the gateway listed the folder's
        /// contents. If this value set to <code>true</code>, each folder that is listed in <code>FolderList</code>
        /// is recursively updated. Otherwise, subfolders listed in <code>FolderList</code> are
        /// not refreshed. Only objects that are in folders listed directly under <code>FolderList</code>
        /// are found and used for the update. The default is <code>true</code>.</para><para>Valid Values: <code>true</code> | <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Recursive { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.RefreshCacheResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.RefreshCacheResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileShareARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileShareARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileShareARN' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileShareARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SGCacheRefresh (RefreshCache)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.RefreshCacheResponse, InvokeSGCacheRefreshCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileShareARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FileShareARN = this.FileShareARN;
            #if MODULAR
            if (this.FileShareARN == null && ParameterWasBound(nameof(this.FileShareARN)))
            {
                WriteWarning("You are passing $null as a value for parameter FileShareARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FolderList != null)
            {
                context.FolderList = new List<System.String>(this.FolderList);
            }
            context.Recursive = this.Recursive;
            
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
            var request = new Amazon.StorageGateway.Model.RefreshCacheRequest();
            
            if (cmdletContext.FileShareARN != null)
            {
                request.FileShareARN = cmdletContext.FileShareARN;
            }
            if (cmdletContext.FolderList != null)
            {
                request.FolderList = cmdletContext.FolderList;
            }
            if (cmdletContext.Recursive != null)
            {
                request.Recursive = cmdletContext.Recursive.Value;
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
        
        private Amazon.StorageGateway.Model.RefreshCacheResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.RefreshCacheRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "RefreshCache");
            try
            {
                #if DESKTOP
                return client.RefreshCache(request);
                #elif CORECLR
                return client.RefreshCacheAsync(request).GetAwaiter().GetResult();
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
            public System.String FileShareARN { get; set; }
            public List<System.String> FolderList { get; set; }
            public System.Boolean? Recursive { get; set; }
            public System.Func<Amazon.StorageGateway.Model.RefreshCacheResponse, InvokeSGCacheRefreshCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
