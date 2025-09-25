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
using Amazon.Textract;
using Amazon.Textract.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Creates a new version of an adapter. Operates on a provided AdapterId and a specified
    /// dataset provided via the DatasetConfig argument. Requires that you specify an Amazon
    /// S3 bucket with the OutputConfig argument. You can provide an optional KMSKeyId, an
    /// optional ClientRequestToken, and optional tags.
    /// </summary>
    [Cmdlet("New", "TXTAdapterVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Textract.Model.CreateAdapterVersionResponse")]
    [AWSCmdlet("Calls the Amazon Textract CreateAdapterVersion API operation.", Operation = new[] {"CreateAdapterVersion"}, SelectReturnType = typeof(Amazon.Textract.Model.CreateAdapterVersionResponse))]
    [AWSCmdletOutput("Amazon.Textract.Model.CreateAdapterVersionResponse",
        "This cmdlet returns an Amazon.Textract.Model.CreateAdapterVersionResponse object containing multiple properties."
    )]
    public partial class NewTXTAdapterVersionCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdapterId
        /// <summary>
        /// <para>
        /// <para>A string containing a unique ID for the adapter that will receive a new version.</para>
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
        public System.String AdapterId { get; set; }
        #endregion
        
        #region Parameter ManifestS3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket. Note that the # character is not valid in the file name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetConfig_ManifestS3Object_Bucket")]
        public System.String ManifestS3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotent token is used to recognize the request. If the same token is used with
        /// multiple CreateAdapterVersion requests, the same session is returned. This token is
        /// employed to avoid unintentionally creating the same session multiple times.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter KMSKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier for your AWS Key Management Service key (AWS KMS key). Used to encrypt
        /// your documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyId { get; set; }
        #endregion
        
        #region Parameter ManifestS3Object_Name
        /// <summary>
        /// <para>
        /// <para>The file name of the input document. Image files may be in PDF, TIFF, JPEG, or PNG
        /// format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetConfig_ManifestS3Object_Name")]
        public System.String ManifestS3Object_Name { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the bucket your output will go to.</para>
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
        public System.String OutputConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the object key that the output will be saved to. When not enabled, the
        /// prefix will be “textract_output".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3Prefix { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags (key-value pairs) that you want to attach to the adapter version. </para><para />
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
        
        #region Parameter ManifestS3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket has versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetConfig_ManifestS3Object_Version")]
        public System.String ManifestS3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.CreateAdapterVersionResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.CreateAdapterVersionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AdapterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TXTAdapterVersion (CreateAdapterVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.CreateAdapterVersionResponse, NewTXTAdapterVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdapterId = this.AdapterId;
            #if MODULAR
            if (this.AdapterId == null && ParameterWasBound(nameof(this.AdapterId)))
            {
                WriteWarning("You are passing $null as a value for parameter AdapterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ManifestS3Object_Bucket = this.ManifestS3Object_Bucket;
            context.ManifestS3Object_Name = this.ManifestS3Object_Name;
            context.ManifestS3Object_Version = this.ManifestS3Object_Version;
            context.KMSKeyId = this.KMSKeyId;
            context.OutputConfig_S3Bucket = this.OutputConfig_S3Bucket;
            #if MODULAR
            if (this.OutputConfig_S3Bucket == null && ParameterWasBound(nameof(this.OutputConfig_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_S3Prefix = this.OutputConfig_S3Prefix;
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
            var request = new Amazon.Textract.Model.CreateAdapterVersionRequest();
            
            if (cmdletContext.AdapterId != null)
            {
                request.AdapterId = cmdletContext.AdapterId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate DatasetConfig
            var requestDatasetConfigIsNull = true;
            request.DatasetConfig = new Amazon.Textract.Model.AdapterVersionDatasetConfig();
            Amazon.Textract.Model.S3Object requestDatasetConfig_datasetConfig_ManifestS3Object = null;
            
             // populate ManifestS3Object
            var requestDatasetConfig_datasetConfig_ManifestS3ObjectIsNull = true;
            requestDatasetConfig_datasetConfig_ManifestS3Object = new Amazon.Textract.Model.S3Object();
            System.String requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Bucket = null;
            if (cmdletContext.ManifestS3Object_Bucket != null)
            {
                requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Bucket = cmdletContext.ManifestS3Object_Bucket;
            }
            if (requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Bucket != null)
            {
                requestDatasetConfig_datasetConfig_ManifestS3Object.Bucket = requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Bucket;
                requestDatasetConfig_datasetConfig_ManifestS3ObjectIsNull = false;
            }
            System.String requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Name = null;
            if (cmdletContext.ManifestS3Object_Name != null)
            {
                requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Name = cmdletContext.ManifestS3Object_Name;
            }
            if (requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Name != null)
            {
                requestDatasetConfig_datasetConfig_ManifestS3Object.Name = requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Name;
                requestDatasetConfig_datasetConfig_ManifestS3ObjectIsNull = false;
            }
            System.String requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Version = null;
            if (cmdletContext.ManifestS3Object_Version != null)
            {
                requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Version = cmdletContext.ManifestS3Object_Version;
            }
            if (requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Version != null)
            {
                requestDatasetConfig_datasetConfig_ManifestS3Object.Version = requestDatasetConfig_datasetConfig_ManifestS3Object_manifestS3Object_Version;
                requestDatasetConfig_datasetConfig_ManifestS3ObjectIsNull = false;
            }
             // determine if requestDatasetConfig_datasetConfig_ManifestS3Object should be set to null
            if (requestDatasetConfig_datasetConfig_ManifestS3ObjectIsNull)
            {
                requestDatasetConfig_datasetConfig_ManifestS3Object = null;
            }
            if (requestDatasetConfig_datasetConfig_ManifestS3Object != null)
            {
                request.DatasetConfig.ManifestS3Object = requestDatasetConfig_datasetConfig_ManifestS3Object;
                requestDatasetConfigIsNull = false;
            }
             // determine if request.DatasetConfig should be set to null
            if (requestDatasetConfigIsNull)
            {
                request.DatasetConfig = null;
            }
            if (cmdletContext.KMSKeyId != null)
            {
                request.KMSKeyId = cmdletContext.KMSKeyId;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.Textract.Model.OutputConfig();
            System.String requestOutputConfig_outputConfig_S3Bucket = null;
            if (cmdletContext.OutputConfig_S3Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Bucket = cmdletContext.OutputConfig_S3Bucket;
            }
            if (requestOutputConfig_outputConfig_S3Bucket != null)
            {
                request.OutputConfig.S3Bucket = requestOutputConfig_outputConfig_S3Bucket;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3Prefix = null;
            if (cmdletContext.OutputConfig_S3Prefix != null)
            {
                requestOutputConfig_outputConfig_S3Prefix = cmdletContext.OutputConfig_S3Prefix;
            }
            if (requestOutputConfig_outputConfig_S3Prefix != null)
            {
                request.OutputConfig.S3Prefix = requestOutputConfig_outputConfig_S3Prefix;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
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
        
        private Amazon.Textract.Model.CreateAdapterVersionResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.CreateAdapterVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "CreateAdapterVersion");
            try
            {
                return client.CreateAdapterVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AdapterId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ManifestS3Object_Bucket { get; set; }
            public System.String ManifestS3Object_Name { get; set; }
            public System.String ManifestS3Object_Version { get; set; }
            public System.String KMSKeyId { get; set; }
            public System.String OutputConfig_S3Bucket { get; set; }
            public System.String OutputConfig_S3Prefix { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Textract.Model.CreateAdapterVersionResponse, NewTXTAdapterVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
