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
using Amazon.Omics;
using Amazon.Omics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// You can create a run cache to save the task outputs from completed tasks in a run
    /// for a private workflow. Subsequent runs use the task outputs from the cache, rather
    /// than computing the task outputs again. You specify an Amazon S3 location where Amazon
    /// Web Services HealthOmics saves the cached data. This data must be immediately accessible
    /// (not in an archived state).
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/workflow-cache-create.html">Creating
    /// a run cache</a> in the Amazon Web Services HealthOmics User Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OMICSRunCache", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateRunCacheResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateRunCache API operation.", Operation = new[] {"CreateRunCache"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateRunCacheResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateRunCacheResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateRunCacheResponse object containing multiple properties."
    )]
    public partial class NewOMICSRunCacheCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CacheBehavior
        /// <summary>
        /// <para>
        /// <para>Default cache behavior for runs that use this cache. Supported values are:</para><para><c>CACHE_ON_FAILURE</c>: Caches task outputs from completed tasks for runs that fail.
        /// This setting is useful if you're debugging a workflow that fails after several tasks
        /// completed successfully. The subsequent run uses the cache outputs for previously-completed
        /// tasks if the task definition, inputs, and container in ECR are identical to the prior
        /// run.</para><para><c>CACHE_ALWAYS</c>: Caches task outputs from completed tasks for all runs. This
        /// setting is useful in development mode, but do not use it in a production setting.</para><para>If you don't specify a value, the default behavior is CACHE_ON_FAILURE. When you start
        /// a run that uses this cache, you can override the default cache behavior.</para><para>For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/how-run-cache.html#run-cache-behavior">Run
        /// cache behavior</a> in the Amazon Web Services HealthOmics User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.CacheBehavior")]
        public Amazon.Omics.CacheBehavior CacheBehavior { get; set; }
        #endregion
        
        #region Parameter CacheBucketOwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the expected owner of the S3 bucket for the
        /// run cache. If not provided, your account ID is set as the owner of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheBucketOwnerId { get; set; }
        #endregion
        
        #region Parameter CacheS3Location
        /// <summary>
        /// <para>
        /// <para>Specify the S3 location for storing the cached task outputs. This data must be immediately
        /// accessible (not in an archived state).</para>
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
        public System.String CacheS3Location { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Enter a description of the run cache.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Enter a user-friendly name for the run cache.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>A unique request token, to ensure idempotency. If you don't specify a token, Amazon
        /// Web Services HealthOmics automatically generates a universally unique identifier (UUID)
        /// for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specify one or more tags to associate with this run cache.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateRunCacheResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateRunCacheResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSRunCache (CreateRunCache)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateRunCacheResponse, NewOMICSRunCacheCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CacheBehavior = this.CacheBehavior;
            context.CacheBucketOwnerId = this.CacheBucketOwnerId;
            context.CacheS3Location = this.CacheS3Location;
            #if MODULAR
            if (this.CacheS3Location == null && ParameterWasBound(nameof(this.CacheS3Location)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheS3Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            context.RequestId = this.RequestId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Omics.Model.CreateRunCacheRequest();
            
            if (cmdletContext.CacheBehavior != null)
            {
                request.CacheBehavior = cmdletContext.CacheBehavior;
            }
            if (cmdletContext.CacheBucketOwnerId != null)
            {
                request.CacheBucketOwnerId = cmdletContext.CacheBucketOwnerId;
            }
            if (cmdletContext.CacheS3Location != null)
            {
                request.CacheS3Location = cmdletContext.CacheS3Location;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Omics.Model.CreateRunCacheResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateRunCacheRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateRunCache");
            try
            {
                return client.CreateRunCacheAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Omics.CacheBehavior CacheBehavior { get; set; }
            public System.String CacheBucketOwnerId { get; set; }
            public System.String CacheS3Location { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Omics.Model.CreateRunCacheResponse, NewOMICSRunCacheCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
