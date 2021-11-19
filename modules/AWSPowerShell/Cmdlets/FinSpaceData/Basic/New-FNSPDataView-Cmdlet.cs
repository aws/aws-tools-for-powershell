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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Creates a Dataview for a Dataset.
    /// </summary>
    [Cmdlet("New", "FNSPDataView", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FinSpaceData.Model.CreateDataViewResponse")]
    [AWSCmdlet("Calls the FinSpace Public API CreateDataView API operation.", Operation = new[] {"CreateDataView"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.CreateDataViewResponse))]
    [AWSCmdletOutput("Amazon.FinSpaceData.Model.CreateDataViewResponse",
        "This cmdlet returns an Amazon.FinSpaceData.Model.CreateDataViewResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFNSPDataViewCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        #region Parameter AsOfTimestamp
        /// <summary>
        /// <para>
        /// <para>Beginning time to use for the Dataview. The value is determined as Epoch time in milliseconds.
        /// For example, the value for Monday, November 1, 2021 12:00:00 PM UTC is specified as
        /// 1635768000000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? AsOfTimestamp { get; set; }
        #endregion
        
        #region Parameter AutoUpdate
        /// <summary>
        /// <para>
        /// <para>Flag to indicate Dataview should be updated automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoUpdate { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique Dataset identifier that is used to create a Dataview.</para>
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
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter DestinationTypeParams_DestinationType
        /// <summary>
        /// <para>
        /// <para>Destination type for a Dataview.</para><ul><li><para><code>GLUE_TABLE</code> - Glue table destination type.</para></li></ul>
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
        public System.String DestinationTypeParams_DestinationType { get; set; }
        #endregion
        
        #region Parameter PartitionColumn
        /// <summary>
        /// <para>
        /// <para>Ordered set of column names used to partition data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PartitionColumns")]
        public System.String[] PartitionColumn { get; set; }
        #endregion
        
        #region Parameter DestinationTypeParams_S3DestinationExportFileFormat
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FinSpaceData.ExportFileFormat")]
        public Amazon.FinSpaceData.ExportFileFormat DestinationTypeParams_S3DestinationExportFileFormat { get; set; }
        #endregion
        
        #region Parameter DestinationTypeParams_S3DestinationExportFileFormatOption
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationTypeParams_S3DestinationExportFileFormatOptions")]
        public System.Collections.Hashtable DestinationTypeParams_S3DestinationExportFileFormatOption { get; set; }
        #endregion
        
        #region Parameter SortColumn
        /// <summary>
        /// <para>
        /// <para>Columns to be used for sorting the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SortColumns")]
        public System.String[] SortColumn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token used to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.CreateDataViewResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.CreateDataViewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FNSPDataView (CreateDataView)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.CreateDataViewResponse, NewFNSPDataViewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AsOfTimestamp = this.AsOfTimestamp;
            context.AutoUpdate = this.AutoUpdate;
            context.ClientToken = this.ClientToken;
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationTypeParams_DestinationType = this.DestinationTypeParams_DestinationType;
            #if MODULAR
            if (this.DestinationTypeParams_DestinationType == null && ParameterWasBound(nameof(this.DestinationTypeParams_DestinationType)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationTypeParams_DestinationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationTypeParams_S3DestinationExportFileFormat = this.DestinationTypeParams_S3DestinationExportFileFormat;
            if (this.DestinationTypeParams_S3DestinationExportFileFormatOption != null)
            {
                context.DestinationTypeParams_S3DestinationExportFileFormatOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationTypeParams_S3DestinationExportFileFormatOption.Keys)
                {
                    context.DestinationTypeParams_S3DestinationExportFileFormatOption.Add((String)hashKey, (String)(this.DestinationTypeParams_S3DestinationExportFileFormatOption[hashKey]));
                }
            }
            if (this.PartitionColumn != null)
            {
                context.PartitionColumn = new List<System.String>(this.PartitionColumn);
            }
            if (this.SortColumn != null)
            {
                context.SortColumn = new List<System.String>(this.SortColumn);
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
            var request = new Amazon.FinSpaceData.Model.CreateDataViewRequest();
            
            if (cmdletContext.AsOfTimestamp != null)
            {
                request.AsOfTimestamp = cmdletContext.AsOfTimestamp.Value;
            }
            if (cmdletContext.AutoUpdate != null)
            {
                request.AutoUpdate = cmdletContext.AutoUpdate.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            
             // populate DestinationTypeParams
            var requestDestinationTypeParamsIsNull = true;
            request.DestinationTypeParams = new Amazon.FinSpaceData.Model.DataViewDestinationTypeParams();
            System.String requestDestinationTypeParams_destinationTypeParams_DestinationType = null;
            if (cmdletContext.DestinationTypeParams_DestinationType != null)
            {
                requestDestinationTypeParams_destinationTypeParams_DestinationType = cmdletContext.DestinationTypeParams_DestinationType;
            }
            if (requestDestinationTypeParams_destinationTypeParams_DestinationType != null)
            {
                request.DestinationTypeParams.DestinationType = requestDestinationTypeParams_destinationTypeParams_DestinationType;
                requestDestinationTypeParamsIsNull = false;
            }
            Amazon.FinSpaceData.ExportFileFormat requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormat = null;
            if (cmdletContext.DestinationTypeParams_S3DestinationExportFileFormat != null)
            {
                requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormat = cmdletContext.DestinationTypeParams_S3DestinationExportFileFormat;
            }
            if (requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormat != null)
            {
                request.DestinationTypeParams.S3DestinationExportFileFormat = requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormat;
                requestDestinationTypeParamsIsNull = false;
            }
            Dictionary<System.String, System.String> requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormatOption = null;
            if (cmdletContext.DestinationTypeParams_S3DestinationExportFileFormatOption != null)
            {
                requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormatOption = cmdletContext.DestinationTypeParams_S3DestinationExportFileFormatOption;
            }
            if (requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormatOption != null)
            {
                request.DestinationTypeParams.S3DestinationExportFileFormatOptions = requestDestinationTypeParams_destinationTypeParams_S3DestinationExportFileFormatOption;
                requestDestinationTypeParamsIsNull = false;
            }
             // determine if request.DestinationTypeParams should be set to null
            if (requestDestinationTypeParamsIsNull)
            {
                request.DestinationTypeParams = null;
            }
            if (cmdletContext.PartitionColumn != null)
            {
                request.PartitionColumns = cmdletContext.PartitionColumn;
            }
            if (cmdletContext.SortColumn != null)
            {
                request.SortColumns = cmdletContext.SortColumn;
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
        
        private Amazon.FinSpaceData.Model.CreateDataViewResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.CreateDataViewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "CreateDataView");
            try
            {
                #if DESKTOP
                return client.CreateDataView(request);
                #elif CORECLR
                return client.CreateDataViewAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? AsOfTimestamp { get; set; }
            public System.Boolean? AutoUpdate { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatasetId { get; set; }
            public System.String DestinationTypeParams_DestinationType { get; set; }
            public Amazon.FinSpaceData.ExportFileFormat DestinationTypeParams_S3DestinationExportFileFormat { get; set; }
            public Dictionary<System.String, System.String> DestinationTypeParams_S3DestinationExportFileFormatOption { get; set; }
            public List<System.String> PartitionColumn { get; set; }
            public List<System.String> SortColumn { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.CreateDataViewResponse, NewFNSPDataViewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
