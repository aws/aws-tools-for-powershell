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
using Amazon.SageMakerGeospatial;
using Amazon.SageMakerGeospatial.Model;

namespace Amazon.PowerShell.Cmdlets.SMGS
{
    /// <summary>
    /// Creates a Vector Enrichment job for the supplied job type. Currently, there are two
    /// supported job types: reverse geocoding and map matching.
    /// </summary>
    [Cmdlet("Start", "SMGSVectorEnrichmentJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse")]
    [AWSCmdlet("Calls the SageMaker Geospatial StartVectorEnrichmentJob API operation.", Operation = new[] {"StartVectorEnrichmentJob"}, SelectReturnType = typeof(Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse))]
    [AWSCmdletOutput("Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse",
        "This cmdlet returns an Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse object containing multiple properties."
    )]
    public partial class StartSMGSVectorEnrichmentJobCmdlet : AmazonSageMakerGeospatialClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputConfig_DocumentType
        /// <summary>
        /// <para>
        /// <para>The input structure that defines the data source file type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.VectorEnrichmentJobDocumentType")]
        public Amazon.SageMakerGeospatial.VectorEnrichmentJobDocumentType InputConfig_DocumentType { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that you specified for the job.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter MapMatchingConfig_IdAttributeName
        /// <summary>
        /// <para>
        /// <para>The field name for the data that describes the identifier representing a collection
        /// of GPS points belonging to an individual trace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_MapMatchingConfig_IdAttributeName")]
        public System.String MapMatchingConfig_IdAttributeName { get; set; }
        #endregion
        
        #region Parameter S3Data_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service key ID for server-side encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_DataSourceConfig_S3Data_KmsKeyId")]
        public System.String S3Data_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service key ID for server-side encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Vector Enrichment job.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3Data_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URL to the Amazon S3 data for the Vector Enrichment job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_DataSourceConfig_S3Data_S3Uri")]
        public System.String S3Data_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Each tag consists of a key and a value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MapMatchingConfig_TimestampAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the timestamp attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_MapMatchingConfig_TimestampAttributeName")]
        public System.String MapMatchingConfig_TimestampAttributeName { get; set; }
        #endregion
        
        #region Parameter MapMatchingConfig_XAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the X-attribute</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_MapMatchingConfig_XAttributeName")]
        public System.String MapMatchingConfig_XAttributeName { get; set; }
        #endregion
        
        #region Parameter ReverseGeocodingConfig_XAttributeName
        /// <summary>
        /// <para>
        /// <para>The field name for the data that describes x-axis coordinate, eg. longitude of a point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ReverseGeocodingConfig_XAttributeName")]
        public System.String ReverseGeocodingConfig_XAttributeName { get; set; }
        #endregion
        
        #region Parameter MapMatchingConfig_YAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the Y-attribute</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_MapMatchingConfig_YAttributeName")]
        public System.String MapMatchingConfig_YAttributeName { get; set; }
        #endregion
        
        #region Parameter ReverseGeocodingConfig_YAttributeName
        /// <summary>
        /// <para>
        /// <para>The field name for the data that describes y-axis coordinate, eg. latitude of a point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ReverseGeocodingConfig_YAttributeName")]
        public System.String ReverseGeocodingConfig_YAttributeName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that guarantees that the call to this API is idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExecutionRoleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExecutionRoleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExecutionRoleArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SMGSVectorEnrichmentJob (StartVectorEnrichmentJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse, StartSMGSVectorEnrichmentJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExecutionRoleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Data_KmsKeyId = this.S3Data_KmsKeyId;
            context.S3Data_S3Uri = this.S3Data_S3Uri;
            context.InputConfig_DocumentType = this.InputConfig_DocumentType;
            #if MODULAR
            if (this.InputConfig_DocumentType == null && ParameterWasBound(nameof(this.InputConfig_DocumentType)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfig_DocumentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MapMatchingConfig_IdAttributeName = this.MapMatchingConfig_IdAttributeName;
            context.MapMatchingConfig_TimestampAttributeName = this.MapMatchingConfig_TimestampAttributeName;
            context.MapMatchingConfig_XAttributeName = this.MapMatchingConfig_XAttributeName;
            context.MapMatchingConfig_YAttributeName = this.MapMatchingConfig_YAttributeName;
            context.ReverseGeocodingConfig_XAttributeName = this.ReverseGeocodingConfig_XAttributeName;
            context.ReverseGeocodingConfig_YAttributeName = this.ReverseGeocodingConfig_YAttributeName;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate InputConfig
            var requestInputConfigIsNull = true;
            request.InputConfig = new Amazon.SageMakerGeospatial.Model.VectorEnrichmentJobInputConfig();
            Amazon.SageMakerGeospatial.VectorEnrichmentJobDocumentType requestInputConfig_inputConfig_DocumentType = null;
            if (cmdletContext.InputConfig_DocumentType != null)
            {
                requestInputConfig_inputConfig_DocumentType = cmdletContext.InputConfig_DocumentType;
            }
            if (requestInputConfig_inputConfig_DocumentType != null)
            {
                request.InputConfig.DocumentType = requestInputConfig_inputConfig_DocumentType;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.VectorEnrichmentJobDataSourceConfigInput requestInputConfig_inputConfig_DataSourceConfig = null;
            
             // populate DataSourceConfig
            var requestInputConfig_inputConfig_DataSourceConfigIsNull = true;
            requestInputConfig_inputConfig_DataSourceConfig = new Amazon.SageMakerGeospatial.Model.VectorEnrichmentJobDataSourceConfigInput();
            Amazon.SageMakerGeospatial.Model.VectorEnrichmentJobS3Data requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data = null;
            
             // populate S3Data
            var requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3DataIsNull = true;
            requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data = new Amazon.SageMakerGeospatial.Model.VectorEnrichmentJobS3Data();
            System.String requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_KmsKeyId = null;
            if (cmdletContext.S3Data_KmsKeyId != null)
            {
                requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_KmsKeyId = cmdletContext.S3Data_KmsKeyId;
            }
            if (requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_KmsKeyId != null)
            {
                requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data.KmsKeyId = requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_KmsKeyId;
                requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3DataIsNull = false;
            }
            System.String requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_S3Uri = null;
            if (cmdletContext.S3Data_S3Uri != null)
            {
                requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_S3Uri = cmdletContext.S3Data_S3Uri;
            }
            if (requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_S3Uri != null)
            {
                requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data.S3Uri = requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data_s3Data_S3Uri;
                requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3DataIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data should be set to null
            if (requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3DataIsNull)
            {
                requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data = null;
            }
            if (requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data != null)
            {
                requestInputConfig_inputConfig_DataSourceConfig.S3Data = requestInputConfig_inputConfig_DataSourceConfig_inputConfig_DataSourceConfig_S3Data;
                requestInputConfig_inputConfig_DataSourceConfigIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_DataSourceConfig should be set to null
            if (requestInputConfig_inputConfig_DataSourceConfigIsNull)
            {
                requestInputConfig_inputConfig_DataSourceConfig = null;
            }
            if (requestInputConfig_inputConfig_DataSourceConfig != null)
            {
                request.InputConfig.DataSourceConfig = requestInputConfig_inputConfig_DataSourceConfig;
                requestInputConfigIsNull = false;
            }
             // determine if request.InputConfig should be set to null
            if (requestInputConfigIsNull)
            {
                request.InputConfig = null;
            }
            
             // populate JobConfig
            var requestJobConfigIsNull = true;
            request.JobConfig = new Amazon.SageMakerGeospatial.Model.VectorEnrichmentJobConfig();
            Amazon.SageMakerGeospatial.Model.ReverseGeocodingConfig requestJobConfig_jobConfig_ReverseGeocodingConfig = null;
            
             // populate ReverseGeocodingConfig
            var requestJobConfig_jobConfig_ReverseGeocodingConfigIsNull = true;
            requestJobConfig_jobConfig_ReverseGeocodingConfig = new Amazon.SageMakerGeospatial.Model.ReverseGeocodingConfig();
            System.String requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_XAttributeName = null;
            if (cmdletContext.ReverseGeocodingConfig_XAttributeName != null)
            {
                requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_XAttributeName = cmdletContext.ReverseGeocodingConfig_XAttributeName;
            }
            if (requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_XAttributeName != null)
            {
                requestJobConfig_jobConfig_ReverseGeocodingConfig.XAttributeName = requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_XAttributeName;
                requestJobConfig_jobConfig_ReverseGeocodingConfigIsNull = false;
            }
            System.String requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_YAttributeName = null;
            if (cmdletContext.ReverseGeocodingConfig_YAttributeName != null)
            {
                requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_YAttributeName = cmdletContext.ReverseGeocodingConfig_YAttributeName;
            }
            if (requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_YAttributeName != null)
            {
                requestJobConfig_jobConfig_ReverseGeocodingConfig.YAttributeName = requestJobConfig_jobConfig_ReverseGeocodingConfig_reverseGeocodingConfig_YAttributeName;
                requestJobConfig_jobConfig_ReverseGeocodingConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_ReverseGeocodingConfig should be set to null
            if (requestJobConfig_jobConfig_ReverseGeocodingConfigIsNull)
            {
                requestJobConfig_jobConfig_ReverseGeocodingConfig = null;
            }
            if (requestJobConfig_jobConfig_ReverseGeocodingConfig != null)
            {
                request.JobConfig.ReverseGeocodingConfig = requestJobConfig_jobConfig_ReverseGeocodingConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.MapMatchingConfig requestJobConfig_jobConfig_MapMatchingConfig = null;
            
             // populate MapMatchingConfig
            var requestJobConfig_jobConfig_MapMatchingConfigIsNull = true;
            requestJobConfig_jobConfig_MapMatchingConfig = new Amazon.SageMakerGeospatial.Model.MapMatchingConfig();
            System.String requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_IdAttributeName = null;
            if (cmdletContext.MapMatchingConfig_IdAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_IdAttributeName = cmdletContext.MapMatchingConfig_IdAttributeName;
            }
            if (requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_IdAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig.IdAttributeName = requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_IdAttributeName;
                requestJobConfig_jobConfig_MapMatchingConfigIsNull = false;
            }
            System.String requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_TimestampAttributeName = null;
            if (cmdletContext.MapMatchingConfig_TimestampAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_TimestampAttributeName = cmdletContext.MapMatchingConfig_TimestampAttributeName;
            }
            if (requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_TimestampAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig.TimestampAttributeName = requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_TimestampAttributeName;
                requestJobConfig_jobConfig_MapMatchingConfigIsNull = false;
            }
            System.String requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_XAttributeName = null;
            if (cmdletContext.MapMatchingConfig_XAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_XAttributeName = cmdletContext.MapMatchingConfig_XAttributeName;
            }
            if (requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_XAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig.XAttributeName = requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_XAttributeName;
                requestJobConfig_jobConfig_MapMatchingConfigIsNull = false;
            }
            System.String requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_YAttributeName = null;
            if (cmdletContext.MapMatchingConfig_YAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_YAttributeName = cmdletContext.MapMatchingConfig_YAttributeName;
            }
            if (requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_YAttributeName != null)
            {
                requestJobConfig_jobConfig_MapMatchingConfig.YAttributeName = requestJobConfig_jobConfig_MapMatchingConfig_mapMatchingConfig_YAttributeName;
                requestJobConfig_jobConfig_MapMatchingConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_MapMatchingConfig should be set to null
            if (requestJobConfig_jobConfig_MapMatchingConfigIsNull)
            {
                requestJobConfig_jobConfig_MapMatchingConfig = null;
            }
            if (requestJobConfig_jobConfig_MapMatchingConfig != null)
            {
                request.JobConfig.MapMatchingConfig = requestJobConfig_jobConfig_MapMatchingConfig;
                requestJobConfigIsNull = false;
            }
             // determine if request.JobConfig should be set to null
            if (requestJobConfigIsNull)
            {
                request.JobConfig = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse CallAWSServiceOperation(IAmazonSageMakerGeospatial client, Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Geospatial", "StartVectorEnrichmentJob");
            try
            {
                #if DESKTOP
                return client.StartVectorEnrichmentJob(request);
                #elif CORECLR
                return client.StartVectorEnrichmentJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String S3Data_KmsKeyId { get; set; }
            public System.String S3Data_S3Uri { get; set; }
            public Amazon.SageMakerGeospatial.VectorEnrichmentJobDocumentType InputConfig_DocumentType { get; set; }
            public System.String MapMatchingConfig_IdAttributeName { get; set; }
            public System.String MapMatchingConfig_TimestampAttributeName { get; set; }
            public System.String MapMatchingConfig_XAttributeName { get; set; }
            public System.String MapMatchingConfig_YAttributeName { get; set; }
            public System.String ReverseGeocodingConfig_XAttributeName { get; set; }
            public System.String ReverseGeocodingConfig_YAttributeName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SageMakerGeospatial.Model.StartVectorEnrichmentJobResponse, StartSMGSVectorEnrichmentJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
