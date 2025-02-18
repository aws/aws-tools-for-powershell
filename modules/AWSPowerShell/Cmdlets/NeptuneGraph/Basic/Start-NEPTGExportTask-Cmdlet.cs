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
using Amazon.NeptuneGraph;
using Amazon.NeptuneGraph.Model;

namespace Amazon.PowerShell.Cmdlets.NEPTG
{
    /// <summary>
    /// Export data from an existing Neptune Analytics graph to Amazon S3. The graph state
    /// should be <c>AVAILABLE</c>.
    /// </summary>
    [Cmdlet("Start", "NEPTGExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NeptuneGraph.Model.StartExportTaskResponse")]
    [AWSCmdlet("Calls the Amazon Neptune Graph StartExportTask API operation.", Operation = new[] {"StartExportTask"}, SelectReturnType = typeof(Amazon.NeptuneGraph.Model.StartExportTaskResponse))]
    [AWSCmdletOutput("Amazon.NeptuneGraph.Model.StartExportTaskResponse",
        "This cmdlet returns an Amazon.NeptuneGraph.Model.StartExportTaskResponse object containing multiple properties."
    )]
    public partial class StartNEPTGExportTaskCmdlet : AmazonNeptuneGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where data will be exported to.</para>
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
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter ExportFilter_EdgeFilter
        /// <summary>
        /// <para>
        /// <para>Used to specify filters on a per-label basis for edges. This allows you to control
        /// which edge labels and properties are included in the export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ExportFilter_EdgeFilter { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the export task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NeptuneGraph.ExportFormat")]
        public Amazon.NeptuneGraph.ExportFormat Format { get; set; }
        #endregion
        
        #region Parameter GraphIdentifier
        /// <summary>
        /// <para>
        /// <para>The source graph identifier of the export task.</para>
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
        public System.String GraphIdentifier { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The KMS key identifier of the export task.</para>
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
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter ParquetType
        /// <summary>
        /// <para>
        /// <para>The parquet type of the export task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NeptuneGraph.ParquetType")]
        public Amazon.NeptuneGraph.ParquetType ParquetType { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that will allow data to be exported to the destination.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be applied to the export task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ExportFilter_VertexFilter
        /// <summary>
        /// <para>
        /// <para>Used to specify filters on a per-label basis for vertices. This allows you to control
        /// which vertex labels and properties are included in the export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ExportFilter_VertexFilter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NeptuneGraph.Model.StartExportTaskResponse).
        /// Specifying the name of a property of type Amazon.NeptuneGraph.Model.StartExportTaskResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GraphIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NEPTGExportTask (StartExportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NeptuneGraph.Model.StartExportTaskResponse, StartNEPTGExportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Destination = this.Destination;
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExportFilter_EdgeFilter != null)
            {
                context.ExportFilter_EdgeFilter = new Dictionary<System.String, Amazon.NeptuneGraph.Model.ExportFilterElement>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExportFilter_EdgeFilter.Keys)
                {
                    context.ExportFilter_EdgeFilter.Add((String)hashKey, (Amazon.NeptuneGraph.Model.ExportFilterElement)(this.ExportFilter_EdgeFilter[hashKey]));
                }
            }
            if (this.ExportFilter_VertexFilter != null)
            {
                context.ExportFilter_VertexFilter = new Dictionary<System.String, Amazon.NeptuneGraph.Model.ExportFilterElement>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExportFilter_VertexFilter.Keys)
                {
                    context.ExportFilter_VertexFilter.Add((String)hashKey, (Amazon.NeptuneGraph.Model.ExportFilterElement)(this.ExportFilter_VertexFilter[hashKey]));
                }
            }
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GraphIdentifier = this.GraphIdentifier;
            #if MODULAR
            if (this.GraphIdentifier == null && ParameterWasBound(nameof(this.GraphIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GraphIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            #if MODULAR
            if (this.KmsKeyIdentifier == null && ParameterWasBound(nameof(this.KmsKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParquetType = this.ParquetType;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NeptuneGraph.Model.StartExportTaskRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            
             // populate ExportFilter
            var requestExportFilterIsNull = true;
            request.ExportFilter = new Amazon.NeptuneGraph.Model.ExportFilter();
            Dictionary<System.String, Amazon.NeptuneGraph.Model.ExportFilterElement> requestExportFilter_exportFilter_EdgeFilter = null;
            if (cmdletContext.ExportFilter_EdgeFilter != null)
            {
                requestExportFilter_exportFilter_EdgeFilter = cmdletContext.ExportFilter_EdgeFilter;
            }
            if (requestExportFilter_exportFilter_EdgeFilter != null)
            {
                request.ExportFilter.EdgeFilter = requestExportFilter_exportFilter_EdgeFilter;
                requestExportFilterIsNull = false;
            }
            Dictionary<System.String, Amazon.NeptuneGraph.Model.ExportFilterElement> requestExportFilter_exportFilter_VertexFilter = null;
            if (cmdletContext.ExportFilter_VertexFilter != null)
            {
                requestExportFilter_exportFilter_VertexFilter = cmdletContext.ExportFilter_VertexFilter;
            }
            if (requestExportFilter_exportFilter_VertexFilter != null)
            {
                request.ExportFilter.VertexFilter = requestExportFilter_exportFilter_VertexFilter;
                requestExportFilterIsNull = false;
            }
             // determine if request.ExportFilter should be set to null
            if (requestExportFilterIsNull)
            {
                request.ExportFilter = null;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.GraphIdentifier != null)
            {
                request.GraphIdentifier = cmdletContext.GraphIdentifier;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.ParquetType != null)
            {
                request.ParquetType = cmdletContext.ParquetType;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.NeptuneGraph.Model.StartExportTaskResponse CallAWSServiceOperation(IAmazonNeptuneGraph client, Amazon.NeptuneGraph.Model.StartExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune Graph", "StartExportTask");
            try
            {
                return client.StartExportTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Destination { get; set; }
            public Dictionary<System.String, Amazon.NeptuneGraph.Model.ExportFilterElement> ExportFilter_EdgeFilter { get; set; }
            public Dictionary<System.String, Amazon.NeptuneGraph.Model.ExportFilterElement> ExportFilter_VertexFilter { get; set; }
            public Amazon.NeptuneGraph.ExportFormat Format { get; set; }
            public System.String GraphIdentifier { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public Amazon.NeptuneGraph.ParquetType ParquetType { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NeptuneGraph.Model.StartExportTaskResponse, StartNEPTGExportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
