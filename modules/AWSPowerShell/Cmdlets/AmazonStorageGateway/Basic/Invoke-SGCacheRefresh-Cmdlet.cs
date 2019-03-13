/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Refreshes the cache for the specified file share. This operation finds objects in
    /// the Amazon S3 bucket that were added, removed or replaced since the gateway last listed
    /// the bucket's contents and cached the results. This operation is only supported in
    /// the file gateway type. You can subscribe to be notified through an Amazon CloudWatch
    /// event when your RefreshCache operation completes. For more information, see <a href="https://docs.aws.amazon.com/storagegateway/latest/userguide/monitoring-file-gateway.html#get-notification">Getting
    /// Notified About File Operations</a>.
    /// </summary>
    [Cmdlet("Invoke", "SGCacheRefresh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.RefreshCacheResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway RefreshCache API operation.", Operation = new[] {"RefreshCache"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.RefreshCacheResponse",
        "This cmdlet returns a Amazon.StorageGateway.Model.RefreshCacheResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeSGCacheRefreshCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter FileShareARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the file share you want to refresh.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FileShareARN { get; set; }
        #endregion
        
        #region Parameter FolderList
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of the paths of folders to refresh in the cache. The default
        /// is [<code>"/"</code>]. The default refreshes objects and folders at the root of the
        /// Amazon S3 bucket. If <code>Recursive</code> is set to "true", the entire S3 bucket
        /// that the file share has access to is refreshed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] FolderList { get; set; }
        #endregion
        
        #region Parameter Recursive
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether to recursively refresh folders in the cache. The refresh
        /// includes folders that were in the cache the last time the gateway listed the folder's
        /// contents. If this value set to "true", each folder that is listed in <code>FolderList</code>
        /// is recursively updated. Otherwise, subfolders listed in <code>FolderList</code> are
        /// not refreshed. Only objects that are in folders listed directly under <code>FolderList</code>
        /// are found and used for the update. The default is "true".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Recursive { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FileShareARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SGCacheRefresh (RefreshCache)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.FileShareARN = this.FileShareARN;
            if (this.FolderList != null)
            {
                context.FolderList = new List<System.String>(this.FolderList);
            }
            if (ParameterWasBound("Recursive"))
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        }
        
    }
}
