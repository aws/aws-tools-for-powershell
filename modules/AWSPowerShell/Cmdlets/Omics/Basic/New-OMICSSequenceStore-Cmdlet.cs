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
    /// Creates a sequence store and returns its metadata. Sequence stores are used to store
    /// sequence data files called read sets that are saved in FASTQ, BAM, uBAM, or CRAM formats.
    /// For aligned formats (BAM and CRAM), a sequence store can only use one reference genome.
    /// For unaligned formats (FASTQ and uBAM), a reference genome is not required. You can
    /// create multiple sequence stores per region per account. 
    /// 
    ///  
    /// <para>
    /// The following are optional parameters you can specify for your sequence store:
    /// </para><ul><li><para>
    /// Use <c>s3AccessConfig</c> to configure your sequence store with S3 access logs (recommended).
    /// </para></li><li><para>
    /// Use <c>sseConfig</c> to define your own KMS key for encryption.
    /// </para></li><li><para>
    /// Use <c>eTagAlgorithmFamily</c> to define which algorithm to use for the HealthOmics
    /// eTag on objects.
    /// </para></li><li><para>
    /// Use <c>fallbackLocation</c> to define a backup location for storing files that have
    /// failed a direct upload.
    /// </para></li><li><para>
    /// Use <c>propagatedSetLevelTags</c> to configure tags that propagate to all objects
    /// in your store.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/create-sequence-store.html">Creating
    /// a HealthOmics sequence store</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OMICSSequenceStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateSequenceStoreResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateSequenceStore API operation.", Operation = new[] {"CreateSequenceStore"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateSequenceStoreResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateSequenceStoreResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateSequenceStoreResponse object containing multiple properties."
    )]
    public partial class NewOMICSSequenceStoreCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3AccessConfig_AccessLogLocation
        /// <summary>
        /// <para>
        /// <para>Location of the access logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3AccessConfig_AccessLogLocation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ETagAlgorithmFamily
        /// <summary>
        /// <para>
        /// <para>The ETag algorithm family to use for ingested read sets. The default value is MD5up.
        /// For more information on ETags, see <a href="https://docs.aws.amazon.com/omics/latest/dev/etags-and-provenance.html">ETags
        /// and data provenance</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.ETagAlgorithmFamily")]
        public Amazon.Omics.ETagAlgorithmFamily ETagAlgorithmFamily { get; set; }
        #endregion
        
        #region Parameter FallbackLocation
        /// <summary>
        /// <para>
        /// <para>An S3 location that is used to store files that have failed a direct upload. You can
        /// add or change the <c>fallbackLocation</c> after creating a sequence store. This is
        /// not required if you are uploading files from a different S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FallbackLocation { get; set; }
        #endregion
        
        #region Parameter SseConfig_KeyArn
        /// <summary>
        /// <para>
        /// <para>An encryption key ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SseConfig_KeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the store.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PropagatedSetLevelTag
        /// <summary>
        /// <para>
        /// <para>The tags keys to propagate to the S3 objects associated with read sets in the sequence
        /// store. These tags can be used as input to add metadata to your read sets.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagatedSetLevelTags")]
        public System.String[] PropagatedSetLevelTag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the store. You can configure up to 50 tags.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter SseConfig_Type
        /// <summary>
        /// <para>
        /// <para>The encryption type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.EncryptionType")]
        public Amazon.Omics.EncryptionType SseConfig_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token used to dedupe retry requests so that duplicate runs are not
        /// created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateSequenceStoreResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateSequenceStoreResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSSequenceStore (CreateSequenceStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateSequenceStoreResponse, NewOMICSSequenceStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ETagAlgorithmFamily = this.ETagAlgorithmFamily;
            context.FallbackLocation = this.FallbackLocation;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PropagatedSetLevelTag != null)
            {
                context.PropagatedSetLevelTag = new List<System.String>(this.PropagatedSetLevelTag);
            }
            context.S3AccessConfig_AccessLogLocation = this.S3AccessConfig_AccessLogLocation;
            context.SseConfig_KeyArn = this.SseConfig_KeyArn;
            context.SseConfig_Type = this.SseConfig_Type;
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
            var request = new Amazon.Omics.Model.CreateSequenceStoreRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ETagAlgorithmFamily != null)
            {
                request.ETagAlgorithmFamily = cmdletContext.ETagAlgorithmFamily;
            }
            if (cmdletContext.FallbackLocation != null)
            {
                request.FallbackLocation = cmdletContext.FallbackLocation;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PropagatedSetLevelTag != null)
            {
                request.PropagatedSetLevelTags = cmdletContext.PropagatedSetLevelTag;
            }
            
             // populate S3AccessConfig
            var requestS3AccessConfigIsNull = true;
            request.S3AccessConfig = new Amazon.Omics.Model.S3AccessConfig();
            System.String requestS3AccessConfig_s3AccessConfig_AccessLogLocation = null;
            if (cmdletContext.S3AccessConfig_AccessLogLocation != null)
            {
                requestS3AccessConfig_s3AccessConfig_AccessLogLocation = cmdletContext.S3AccessConfig_AccessLogLocation;
            }
            if (requestS3AccessConfig_s3AccessConfig_AccessLogLocation != null)
            {
                request.S3AccessConfig.AccessLogLocation = requestS3AccessConfig_s3AccessConfig_AccessLogLocation;
                requestS3AccessConfigIsNull = false;
            }
             // determine if request.S3AccessConfig should be set to null
            if (requestS3AccessConfigIsNull)
            {
                request.S3AccessConfig = null;
            }
            
             // populate SseConfig
            var requestSseConfigIsNull = true;
            request.SseConfig = new Amazon.Omics.Model.SseConfig();
            System.String requestSseConfig_sseConfig_KeyArn = null;
            if (cmdletContext.SseConfig_KeyArn != null)
            {
                requestSseConfig_sseConfig_KeyArn = cmdletContext.SseConfig_KeyArn;
            }
            if (requestSseConfig_sseConfig_KeyArn != null)
            {
                request.SseConfig.KeyArn = requestSseConfig_sseConfig_KeyArn;
                requestSseConfigIsNull = false;
            }
            Amazon.Omics.EncryptionType requestSseConfig_sseConfig_Type = null;
            if (cmdletContext.SseConfig_Type != null)
            {
                requestSseConfig_sseConfig_Type = cmdletContext.SseConfig_Type;
            }
            if (requestSseConfig_sseConfig_Type != null)
            {
                request.SseConfig.Type = requestSseConfig_sseConfig_Type;
                requestSseConfigIsNull = false;
            }
             // determine if request.SseConfig should be set to null
            if (requestSseConfigIsNull)
            {
                request.SseConfig = null;
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
        
        private Amazon.Omics.Model.CreateSequenceStoreResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateSequenceStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateSequenceStore");
            try
            {
                return client.CreateSequenceStoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Amazon.Omics.ETagAlgorithmFamily ETagAlgorithmFamily { get; set; }
            public System.String FallbackLocation { get; set; }
            public System.String Name { get; set; }
            public List<System.String> PropagatedSetLevelTag { get; set; }
            public System.String S3AccessConfig_AccessLogLocation { get; set; }
            public System.String SseConfig_KeyArn { get; set; }
            public Amazon.Omics.EncryptionType SseConfig_Type { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Omics.Model.CreateSequenceStoreResponse, NewOMICSSequenceStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
