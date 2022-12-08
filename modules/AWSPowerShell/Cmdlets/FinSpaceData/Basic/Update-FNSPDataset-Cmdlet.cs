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
    /// Updates a FinSpace Dataset.
    /// </summary>
    [Cmdlet("Update", "FNSPDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the FinSpace Public API UpdateDataset API operation.", Operation = new[] {"UpdateDataset"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.UpdateDatasetResponse))]
    [AWSCmdletOutput("System.String or Amazon.FinSpaceData.Model.UpdateDatasetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.FinSpaceData.Model.UpdateDatasetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFNSPDatasetCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The unique resource identifier for a Dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter TabularSchemaConfig_Column
        /// <summary>
        /// <para>
        /// <para>List of column definitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_TabularSchemaConfig_Columns")]
        public Amazon.FinSpaceData.Model.ColumnDefinition[] TabularSchemaConfig_Column { get; set; }
        #endregion
        
        #region Parameter DatasetDescription
        /// <summary>
        /// <para>
        /// <para>A description for the Dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetDescription { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Dataset to update.</para>
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
        
        #region Parameter DatasetTitle
        /// <summary>
        /// <para>
        /// <para>A display title for the Dataset.</para>
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
        public System.String DatasetTitle { get; set; }
        #endregion
        
        #region Parameter Kind
        /// <summary>
        /// <para>
        /// <para>The format in which the Dataset data is structured.</para><ul><li><para><code>TABULAR</code> – Data is structured in a tabular format.</para></li><li><para><code>NON_TABULAR</code> – Data is structured in a non-tabular format.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FinSpaceData.DatasetKind")]
        public Amazon.FinSpaceData.DatasetKind Kind { get; set; }
        #endregion
        
        #region Parameter TabularSchemaConfig_PrimaryKeyColumn
        /// <summary>
        /// <para>
        /// <para>List of column names used for primary key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_TabularSchemaConfig_PrimaryKeyColumns")]
        public System.String[] TabularSchemaConfig_PrimaryKeyColumn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.UpdateDatasetResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.UpdateDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FNSPDataset (UpdateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.UpdateDatasetResponse, UpdateFNSPDatasetCmdlet>(Select) ??
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
            context.Alias = this.Alias;
            context.ClientToken = this.ClientToken;
            context.DatasetDescription = this.DatasetDescription;
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetTitle = this.DatasetTitle;
            #if MODULAR
            if (this.DatasetTitle == null && ParameterWasBound(nameof(this.DatasetTitle)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetTitle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Kind = this.Kind;
            #if MODULAR
            if (this.Kind == null && ParameterWasBound(nameof(this.Kind)))
            {
                WriteWarning("You are passing $null as a value for parameter Kind which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TabularSchemaConfig_Column != null)
            {
                context.TabularSchemaConfig_Column = new List<Amazon.FinSpaceData.Model.ColumnDefinition>(this.TabularSchemaConfig_Column);
            }
            if (this.TabularSchemaConfig_PrimaryKeyColumn != null)
            {
                context.TabularSchemaConfig_PrimaryKeyColumn = new List<System.String>(this.TabularSchemaConfig_PrimaryKeyColumn);
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
            var request = new Amazon.FinSpaceData.Model.UpdateDatasetRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetDescription != null)
            {
                request.DatasetDescription = cmdletContext.DatasetDescription;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            if (cmdletContext.DatasetTitle != null)
            {
                request.DatasetTitle = cmdletContext.DatasetTitle;
            }
            if (cmdletContext.Kind != null)
            {
                request.Kind = cmdletContext.Kind;
            }
            
             // populate SchemaDefinition
            var requestSchemaDefinitionIsNull = true;
            request.SchemaDefinition = new Amazon.FinSpaceData.Model.SchemaUnion();
            Amazon.FinSpaceData.Model.SchemaDefinition requestSchemaDefinition_schemaDefinition_TabularSchemaConfig = null;
            
             // populate TabularSchemaConfig
            var requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull = true;
            requestSchemaDefinition_schemaDefinition_TabularSchemaConfig = new Amazon.FinSpaceData.Model.SchemaDefinition();
            List<Amazon.FinSpaceData.Model.ColumnDefinition> requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column = null;
            if (cmdletContext.TabularSchemaConfig_Column != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column = cmdletContext.TabularSchemaConfig_Column;
            }
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig.Columns = requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_Column;
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull = false;
            }
            List<System.String> requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn = null;
            if (cmdletContext.TabularSchemaConfig_PrimaryKeyColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn = cmdletContext.TabularSchemaConfig_PrimaryKeyColumn;
            }
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig.PrimaryKeyColumns = requestSchemaDefinition_schemaDefinition_TabularSchemaConfig_tabularSchemaConfig_PrimaryKeyColumn;
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull = false;
            }
             // determine if requestSchemaDefinition_schemaDefinition_TabularSchemaConfig should be set to null
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfigIsNull)
            {
                requestSchemaDefinition_schemaDefinition_TabularSchemaConfig = null;
            }
            if (requestSchemaDefinition_schemaDefinition_TabularSchemaConfig != null)
            {
                request.SchemaDefinition.TabularSchemaConfig = requestSchemaDefinition_schemaDefinition_TabularSchemaConfig;
                requestSchemaDefinitionIsNull = false;
            }
             // determine if request.SchemaDefinition should be set to null
            if (requestSchemaDefinitionIsNull)
            {
                request.SchemaDefinition = null;
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
        
        private Amazon.FinSpaceData.Model.UpdateDatasetResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.UpdateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "UpdateDataset");
            try
            {
                #if DESKTOP
                return client.UpdateDataset(request);
                #elif CORECLR
                return client.UpdateDatasetAsync(request).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatasetDescription { get; set; }
            public System.String DatasetId { get; set; }
            public System.String DatasetTitle { get; set; }
            public Amazon.FinSpaceData.DatasetKind Kind { get; set; }
            public List<Amazon.FinSpaceData.Model.ColumnDefinition> TabularSchemaConfig_Column { get; set; }
            public List<System.String> TabularSchemaConfig_PrimaryKeyColumn { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.UpdateDatasetResponse, UpdateFNSPDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetId;
        }
        
    }
}
