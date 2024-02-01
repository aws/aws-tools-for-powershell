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
using Amazon.NeptuneGraph;
using Amazon.NeptuneGraph.Model;

namespace Amazon.PowerShell.Cmdlets.NEPTG
{
    /// <summary>
    /// Creates a new Neptune Analytics graph and imports data into it, either from Amazon
    /// Simple Storage Service (S3) or from a Neptune database or a Neptune database snapshot.
    /// 
    ///  
    /// <para>
    /// The data can be loaded from files in S3 that in either the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-format-gremlin.html">Gremlin
    /// CSV format</a> or the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-format-opencypher.html">openCypher
    /// load format</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NEPTGGraphUsingImportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse")]
    [AWSCmdlet("Calls the Amazon Neptune Graph CreateGraphUsingImportTask API operation.", Operation = new[] {"CreateGraphUsingImportTask"}, SelectReturnType = typeof(Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse))]
    [AWSCmdletOutput("Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse",
        "This cmdlet returns an Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewNEPTGGraphUsingImportTaskCmdlet : AmazonNeptuneGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Indicates whether or not to enable deletion protection on the graph. The graph can’t
        /// be deleted when deletion protection is enabled. (<c>true</c> or <c>false</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_Dimension
        /// <summary>
        /// <para>
        /// <para>The number of dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VectorSearchConfiguration_Dimension { get; set; }
        #endregion
        
        #region Parameter FailOnError
        /// <summary>
        /// <para>
        /// <para>If set to <c>true</c>, the task halts when an import error is encountered. If set
        /// to <c>false</c>, the task skips the data that caused the error and continues if possible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FailOnError { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>Specifies the format of S3 data to be imported. Valid values are <c>CSV</c>, which
        /// identifies the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-format-gremlin.html">Gremlin
        /// CSV format</a> or <c>OPENCYPHER</c>, which identies the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-format-opencypher.html">openCypher
        /// load format</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NeptuneGraph.Format")]
        public Amazon.NeptuneGraph.Format Format { get; set; }
        #endregion
        
        #region Parameter GraphName
        /// <summary>
        /// <para>
        /// <para>A name for the new Neptune Analytics graph to be created.</para><para>The name must contain from 1 to 63 letters, numbers, or hyphens, and its first character
        /// must be a letter. It cannot end with a hyphen or contain two consecutive hyphens.
        /// </para>
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
        public System.String GraphName { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies a KMS key to use to encrypt data imported into the new graph.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxProvisionedMemory
        /// <summary>
        /// <para>
        /// <para>The maximum provisioned memory-optimized Neptune Capacity Units (m-NCUs) to use for
        /// the graph. Default: 1024, or the approved upper limit for your account.</para><para> If both the minimum and maximum values are specified, the max of the <c>min-provisioned-memory</c>
        /// and <c>max-provisioned memory</c> is used to create the graph. If neither value is
        /// specified 128 m-NCUs are used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxProvisionedMemory { get; set; }
        #endregion
        
        #region Parameter MinProvisionedMemory
        /// <summary>
        /// <para>
        /// <para>The minimum provisioned memory-optimized Neptune Capacity Units (m-NCUs) to use for
        /// the graph. Default: 128</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinProvisionedMemory { get; set; }
        #endregion
        
        #region Parameter Neptune_PreserveDefaultVertexLabel
        /// <summary>
        /// <para>
        /// <para>Neptune Analytics supports label-less vertices and no labels are assigned unless one
        /// is explicitly provided. Neptune assigns default labels when none is explicitly provided.
        /// When importing the data into Neptune Analytics, the default vertex labels can be omitted
        /// by setting <i>preserveDefaultVertexLabels</i> to false. Note that if the vertex only
        /// has default labels, and has no other properties or edges, then the vertex will effectively
        /// not get imported into Neptune Analytics when preserveDefaultVertexLabels is set to
        /// false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_Neptune_PreserveDefaultVertexLabels")]
        public System.Boolean? Neptune_PreserveDefaultVertexLabel { get; set; }
        #endregion
        
        #region Parameter Neptune_PreserveEdgeId
        /// <summary>
        /// <para>
        /// <para>Neptune Analytics currently does not support user defined edge ids. The edge ids are
        /// not imported by default. They are imported if <i>preserveEdgeIds</i> is set to true,
        /// and ids are stored as properties on the relationships with the property name <i>neptuneEdgeId</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_Neptune_PreserveEdgeIds")]
        public System.Boolean? Neptune_PreserveEdgeId { get; set; }
        #endregion
        
        #region Parameter PublicConnectivity
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not the graph can be reachable over the internet. All access
        /// to graphs IAM authenticated. (<c>true</c> to enable, or <c>false</c> to disable).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicConnectivity { get; set; }
        #endregion
        
        #region Parameter ReplicaCount
        /// <summary>
        /// <para>
        /// <para>The number of replicas in other AZs to provision on the new graph after import. Default
        /// = 0, Min = 0, Max = 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ReplicaCount { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that will allow access to the data that is to be imported.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Neptune_S3ExportKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key to use to encrypt data in the S3 bucket where the graph data is exported</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_Neptune_S3ExportKmsKeyId")]
        public System.String Neptune_S3ExportKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Neptune_S3ExportPath
        /// <summary>
        /// <para>
        /// <para>The path to an S3 bucket from which to import data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_Neptune_S3ExportPath")]
        public System.String Neptune_S3ExportPath { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>A URL identifying to the location of the data to be imported. This can be an Amazon
        /// S3 path, or can point to a Neptune database endpoint or snapshot.</para>
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
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds metadata tags to the new graph. These tags can also be used with cost allocation
        /// reporting, or used in a Condition statement in an IAM policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse).
        /// Specifying the name of a property of type Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GraphName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NEPTGGraphUsingImportTask (CreateGraphUsingImportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse, NewNEPTGGraphUsingImportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionProtection = this.DeletionProtection;
            context.FailOnError = this.FailOnError;
            context.Format = this.Format;
            context.GraphName = this.GraphName;
            #if MODULAR
            if (this.GraphName == null && ParameterWasBound(nameof(this.GraphName)))
            {
                WriteWarning("You are passing $null as a value for parameter GraphName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Neptune_PreserveDefaultVertexLabel = this.Neptune_PreserveDefaultVertexLabel;
            context.Neptune_PreserveEdgeId = this.Neptune_PreserveEdgeId;
            context.Neptune_S3ExportKmsKeyId = this.Neptune_S3ExportKmsKeyId;
            context.Neptune_S3ExportPath = this.Neptune_S3ExportPath;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.MaxProvisionedMemory = this.MaxProvisionedMemory;
            context.MinProvisionedMemory = this.MinProvisionedMemory;
            context.PublicConnectivity = this.PublicConnectivity;
            context.ReplicaCount = this.ReplicaCount;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.VectorSearchConfiguration_Dimension = this.VectorSearchConfiguration_Dimension;
            
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
            var request = new Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskRequest();
            
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.FailOnError != null)
            {
                request.FailOnError = cmdletContext.FailOnError.Value;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.GraphName != null)
            {
                request.GraphName = cmdletContext.GraphName;
            }
            
             // populate ImportOptions
            var requestImportOptionsIsNull = true;
            request.ImportOptions = new Amazon.NeptuneGraph.Model.ImportOptions();
            Amazon.NeptuneGraph.Model.NeptuneImportOptions requestImportOptions_importOptions_Neptune = null;
            
             // populate Neptune
            var requestImportOptions_importOptions_NeptuneIsNull = true;
            requestImportOptions_importOptions_Neptune = new Amazon.NeptuneGraph.Model.NeptuneImportOptions();
            System.Boolean? requestImportOptions_importOptions_Neptune_neptune_PreserveDefaultVertexLabel = null;
            if (cmdletContext.Neptune_PreserveDefaultVertexLabel != null)
            {
                requestImportOptions_importOptions_Neptune_neptune_PreserveDefaultVertexLabel = cmdletContext.Neptune_PreserveDefaultVertexLabel.Value;
            }
            if (requestImportOptions_importOptions_Neptune_neptune_PreserveDefaultVertexLabel != null)
            {
                requestImportOptions_importOptions_Neptune.PreserveDefaultVertexLabels = requestImportOptions_importOptions_Neptune_neptune_PreserveDefaultVertexLabel.Value;
                requestImportOptions_importOptions_NeptuneIsNull = false;
            }
            System.Boolean? requestImportOptions_importOptions_Neptune_neptune_PreserveEdgeId = null;
            if (cmdletContext.Neptune_PreserveEdgeId != null)
            {
                requestImportOptions_importOptions_Neptune_neptune_PreserveEdgeId = cmdletContext.Neptune_PreserveEdgeId.Value;
            }
            if (requestImportOptions_importOptions_Neptune_neptune_PreserveEdgeId != null)
            {
                requestImportOptions_importOptions_Neptune.PreserveEdgeIds = requestImportOptions_importOptions_Neptune_neptune_PreserveEdgeId.Value;
                requestImportOptions_importOptions_NeptuneIsNull = false;
            }
            System.String requestImportOptions_importOptions_Neptune_neptune_S3ExportKmsKeyId = null;
            if (cmdletContext.Neptune_S3ExportKmsKeyId != null)
            {
                requestImportOptions_importOptions_Neptune_neptune_S3ExportKmsKeyId = cmdletContext.Neptune_S3ExportKmsKeyId;
            }
            if (requestImportOptions_importOptions_Neptune_neptune_S3ExportKmsKeyId != null)
            {
                requestImportOptions_importOptions_Neptune.S3ExportKmsKeyId = requestImportOptions_importOptions_Neptune_neptune_S3ExportKmsKeyId;
                requestImportOptions_importOptions_NeptuneIsNull = false;
            }
            System.String requestImportOptions_importOptions_Neptune_neptune_S3ExportPath = null;
            if (cmdletContext.Neptune_S3ExportPath != null)
            {
                requestImportOptions_importOptions_Neptune_neptune_S3ExportPath = cmdletContext.Neptune_S3ExportPath;
            }
            if (requestImportOptions_importOptions_Neptune_neptune_S3ExportPath != null)
            {
                requestImportOptions_importOptions_Neptune.S3ExportPath = requestImportOptions_importOptions_Neptune_neptune_S3ExportPath;
                requestImportOptions_importOptions_NeptuneIsNull = false;
            }
             // determine if requestImportOptions_importOptions_Neptune should be set to null
            if (requestImportOptions_importOptions_NeptuneIsNull)
            {
                requestImportOptions_importOptions_Neptune = null;
            }
            if (requestImportOptions_importOptions_Neptune != null)
            {
                request.ImportOptions.Neptune = requestImportOptions_importOptions_Neptune;
                requestImportOptionsIsNull = false;
            }
             // determine if request.ImportOptions should be set to null
            if (requestImportOptionsIsNull)
            {
                request.ImportOptions = null;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.MaxProvisionedMemory != null)
            {
                request.MaxProvisionedMemory = cmdletContext.MaxProvisionedMemory.Value;
            }
            if (cmdletContext.MinProvisionedMemory != null)
            {
                request.MinProvisionedMemory = cmdletContext.MinProvisionedMemory.Value;
            }
            if (cmdletContext.PublicConnectivity != null)
            {
                request.PublicConnectivity = cmdletContext.PublicConnectivity.Value;
            }
            if (cmdletContext.ReplicaCount != null)
            {
                request.ReplicaCount = cmdletContext.ReplicaCount.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VectorSearchConfiguration
            var requestVectorSearchConfigurationIsNull = true;
            request.VectorSearchConfiguration = new Amazon.NeptuneGraph.Model.VectorSearchConfiguration();
            System.Int32? requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension = null;
            if (cmdletContext.VectorSearchConfiguration_Dimension != null)
            {
                requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension = cmdletContext.VectorSearchConfiguration_Dimension.Value;
            }
            if (requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension != null)
            {
                request.VectorSearchConfiguration.Dimension = requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension.Value;
                requestVectorSearchConfigurationIsNull = false;
            }
             // determine if request.VectorSearchConfiguration should be set to null
            if (requestVectorSearchConfigurationIsNull)
            {
                request.VectorSearchConfiguration = null;
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
        
        private Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse CallAWSServiceOperation(IAmazonNeptuneGraph client, Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune Graph", "CreateGraphUsingImportTask");
            try
            {
                #if DESKTOP
                return client.CreateGraphUsingImportTask(request);
                #elif CORECLR
                return client.CreateGraphUsingImportTaskAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtection { get; set; }
            public System.Boolean? FailOnError { get; set; }
            public Amazon.NeptuneGraph.Format Format { get; set; }
            public System.String GraphName { get; set; }
            public System.Boolean? Neptune_PreserveDefaultVertexLabel { get; set; }
            public System.Boolean? Neptune_PreserveEdgeId { get; set; }
            public System.String Neptune_S3ExportKmsKeyId { get; set; }
            public System.String Neptune_S3ExportPath { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.Int32? MaxProvisionedMemory { get; set; }
            public System.Int32? MinProvisionedMemory { get; set; }
            public System.Boolean? PublicConnectivity { get; set; }
            public System.Int32? ReplicaCount { get; set; }
            public System.String RoleArn { get; set; }
            public System.String Source { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? VectorSearchConfiguration_Dimension { get; set; }
            public System.Func<Amazon.NeptuneGraph.Model.CreateGraphUsingImportTaskResponse, NewNEPTGGraphUsingImportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
