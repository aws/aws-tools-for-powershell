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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates an <i>artifact</i>. An artifact is a lineage tracking entity that represents
    /// a URI addressable object or data. Some examples are the S3 URI of a dataset and the
    /// ECR registry path of an image. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/lineage-tracking.html">Amazon
    /// SageMaker ML Lineage Tracking</a>.
    /// </summary>
    [Cmdlet("New", "SMArtifact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateArtifact API operation.", Operation = new[] {"CreateArtifact"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateArtifactResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateArtifactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateArtifactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMArtifactCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArtifactName
        /// <summary>
        /// <para>
        /// <para>The name of the artifact. Must be unique to your account in an Amazon Web Services
        /// Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArtifactName { get; set; }
        #endregion
        
        #region Parameter ArtifactType
        /// <summary>
        /// <para>
        /// <para>The artifact type.</para>
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
        public System.String ArtifactType { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_CommitId
        /// <summary>
        /// <para>
        /// <para>The commit ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_CommitId { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_GeneratedBy
        /// <summary>
        /// <para>
        /// <para>The entity this entity was generated by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_GeneratedBy { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_ProjectId
        /// <summary>
        /// <para>
        /// <para>The project ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_ProjectId { get; set; }
        #endregion
        
        #region Parameter Property
        /// <summary>
        /// <para>
        /// <para>A list of properties to add to the artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Properties")]
        public System.Collections.Hashtable Property { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_Repository
        /// <summary>
        /// <para>
        /// <para>The repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_Repository { get; set; }
        #endregion
        
        #region Parameter Source_SourceType
        /// <summary>
        /// <para>
        /// <para>A list of source types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SourceTypes")]
        public Amazon.SageMaker.Model.ArtifactSourceType[] Source_SourceType { get; set; }
        #endregion
        
        #region Parameter Source_SourceUri
        /// <summary>
        /// <para>
        /// <para>The URI of the source.</para>
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
        public System.String Source_SourceUri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to apply to the artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ArtifactArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateArtifactResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateArtifactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ArtifactArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Source_SourceUri), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMArtifact (CreateArtifact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateArtifactResponse, NewSMArtifactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArtifactName = this.ArtifactName;
            context.ArtifactType = this.ArtifactType;
            #if MODULAR
            if (this.ArtifactType == null && ParameterWasBound(nameof(this.ArtifactType)))
            {
                WriteWarning("You are passing $null as a value for parameter ArtifactType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetadataProperties_CommitId = this.MetadataProperties_CommitId;
            context.MetadataProperties_GeneratedBy = this.MetadataProperties_GeneratedBy;
            context.MetadataProperties_ProjectId = this.MetadataProperties_ProjectId;
            context.MetadataProperties_Repository = this.MetadataProperties_Repository;
            if (this.Property != null)
            {
                context.Property = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Property.Keys)
                {
                    context.Property.Add((String)hashKey, (System.String)(this.Property[hashKey]));
                }
            }
            if (this.Source_SourceType != null)
            {
                context.Source_SourceType = new List<Amazon.SageMaker.Model.ArtifactSourceType>(this.Source_SourceType);
            }
            context.Source_SourceUri = this.Source_SourceUri;
            #if MODULAR
            if (this.Source_SourceUri == null && ParameterWasBound(nameof(this.Source_SourceUri)))
            {
                WriteWarning("You are passing $null as a value for parameter Source_SourceUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateArtifactRequest();
            
            if (cmdletContext.ArtifactName != null)
            {
                request.ArtifactName = cmdletContext.ArtifactName;
            }
            if (cmdletContext.ArtifactType != null)
            {
                request.ArtifactType = cmdletContext.ArtifactType;
            }
            
             // populate MetadataProperties
            var requestMetadataPropertiesIsNull = true;
            request.MetadataProperties = new Amazon.SageMaker.Model.MetadataProperties();
            System.String requestMetadataProperties_metadataProperties_CommitId = null;
            if (cmdletContext.MetadataProperties_CommitId != null)
            {
                requestMetadataProperties_metadataProperties_CommitId = cmdletContext.MetadataProperties_CommitId;
            }
            if (requestMetadataProperties_metadataProperties_CommitId != null)
            {
                request.MetadataProperties.CommitId = requestMetadataProperties_metadataProperties_CommitId;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_GeneratedBy = null;
            if (cmdletContext.MetadataProperties_GeneratedBy != null)
            {
                requestMetadataProperties_metadataProperties_GeneratedBy = cmdletContext.MetadataProperties_GeneratedBy;
            }
            if (requestMetadataProperties_metadataProperties_GeneratedBy != null)
            {
                request.MetadataProperties.GeneratedBy = requestMetadataProperties_metadataProperties_GeneratedBy;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_ProjectId = null;
            if (cmdletContext.MetadataProperties_ProjectId != null)
            {
                requestMetadataProperties_metadataProperties_ProjectId = cmdletContext.MetadataProperties_ProjectId;
            }
            if (requestMetadataProperties_metadataProperties_ProjectId != null)
            {
                request.MetadataProperties.ProjectId = requestMetadataProperties_metadataProperties_ProjectId;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_Repository = null;
            if (cmdletContext.MetadataProperties_Repository != null)
            {
                requestMetadataProperties_metadataProperties_Repository = cmdletContext.MetadataProperties_Repository;
            }
            if (requestMetadataProperties_metadataProperties_Repository != null)
            {
                request.MetadataProperties.Repository = requestMetadataProperties_metadataProperties_Repository;
                requestMetadataPropertiesIsNull = false;
            }
             // determine if request.MetadataProperties should be set to null
            if (requestMetadataPropertiesIsNull)
            {
                request.MetadataProperties = null;
            }
            if (cmdletContext.Property != null)
            {
                request.Properties = cmdletContext.Property;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.SageMaker.Model.ArtifactSource();
            List<Amazon.SageMaker.Model.ArtifactSourceType> requestSource_source_SourceType = null;
            if (cmdletContext.Source_SourceType != null)
            {
                requestSource_source_SourceType = cmdletContext.Source_SourceType;
            }
            if (requestSource_source_SourceType != null)
            {
                request.Source.SourceTypes = requestSource_source_SourceType;
                requestSourceIsNull = false;
            }
            System.String requestSource_source_SourceUri = null;
            if (cmdletContext.Source_SourceUri != null)
            {
                requestSource_source_SourceUri = cmdletContext.Source_SourceUri;
            }
            if (requestSource_source_SourceUri != null)
            {
                request.Source.SourceUri = requestSource_source_SourceUri;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.SageMaker.Model.CreateArtifactResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateArtifact");
            try
            {
                return client.CreateArtifactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ArtifactName { get; set; }
            public System.String ArtifactType { get; set; }
            public System.String MetadataProperties_CommitId { get; set; }
            public System.String MetadataProperties_GeneratedBy { get; set; }
            public System.String MetadataProperties_ProjectId { get; set; }
            public System.String MetadataProperties_Repository { get; set; }
            public Dictionary<System.String, System.String> Property { get; set; }
            public List<Amazon.SageMaker.Model.ArtifactSourceType> Source_SourceType { get; set; }
            public System.String Source_SourceUri { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateArtifactResponse, NewSMArtifactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ArtifactArn;
        }
        
    }
}
