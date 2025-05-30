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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// This API is used to provide optional override properties for the the tables that need
    /// to be replicated. These properties can include properties for filtering and partitioning
    /// for the source and target tables. To set both source and target properties the same
    /// API need to be invoked with the Glue connection ARN as <c>ResourceArn</c> with <c>SourceTableConfig</c>,
    /// and the Glue database ARN as <c>ResourceArn</c> with <c>TargetTableConfig</c> respectively.
    /// </summary>
    [Cmdlet("New", "GLUEIntegrationTableProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue CreateIntegrationTableProperties API operation.", Operation = new[] {"CreateIntegrationTableProperties"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateIntegrationTablePropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.CreateIntegrationTablePropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.CreateIntegrationTablePropertiesResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewGLUEIntegrationTablePropertyCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SourceTableConfig_Field
        /// <summary>
        /// <para>
        /// <para>A list of fields used for column-level filtering. Currently unsupported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceTableConfig_Fields")]
        public System.String[] SourceTableConfig_Field { get; set; }
        #endregion
        
        #region Parameter SourceTableConfig_FilterPredicate
        /// <summary>
        /// <para>
        /// <para>A condition clause used for row-level filtering. Currently unsupported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceTableConfig_FilterPredicate { get; set; }
        #endregion
        
        #region Parameter TargetTableConfig_PartitionSpec
        /// <summary>
        /// <para>
        /// <para>Determines the file layout on the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.IntegrationPartition[] TargetTableConfig_PartitionSpec { get; set; }
        #endregion
        
        #region Parameter SourceTableConfig_PrimaryKey
        /// <summary>
        /// <para>
        /// <para>Provide the primary key set for this table. Currently supported specifically for SAP
        /// <c>EntityOf</c> entities upon request. Contact Amazon Web Services Support to make
        /// this feature available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SourceTableConfig_PrimaryKey { get; set; }
        #endregion
        
        #region Parameter SourceTableConfig_RecordUpdateField
        /// <summary>
        /// <para>
        /// <para>Incremental pull timestamp-based field. Currently unsupported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceTableConfig_RecordUpdateField { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target table for which to create integration
        /// table properties. Currently, this API only supports creating integration table properties
        /// for target tables, and the provided ARN should be the ARN of the target table in the
        /// Glue Data Catalog. Support for creating integration table properties for source connections
        /// (using the connection ARN) is not yet implemented and will be added in a future release.
        /// </para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to be replicated.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter TargetTableConfig_TargetTableName
        /// <summary>
        /// <para>
        /// <para>The optional name of a target table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetTableConfig_TargetTableName { get; set; }
        #endregion
        
        #region Parameter TargetTableConfig_UnnestSpec
        /// <summary>
        /// <para>
        /// <para>Specifies how nested objects are flattened to top-level elements. Valid values are:
        /// "TOPLEVEL", "FULL", or "NOUNNEST".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.UnnestSpec")]
        public Amazon.Glue.UnnestSpec TargetTableConfig_UnnestSpec { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateIntegrationTablePropertiesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEIntegrationTableProperty (CreateIntegrationTableProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateIntegrationTablePropertiesResponse, NewGLUEIntegrationTablePropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceTableConfig_Field != null)
            {
                context.SourceTableConfig_Field = new List<System.String>(this.SourceTableConfig_Field);
            }
            context.SourceTableConfig_FilterPredicate = this.SourceTableConfig_FilterPredicate;
            if (this.SourceTableConfig_PrimaryKey != null)
            {
                context.SourceTableConfig_PrimaryKey = new List<System.String>(this.SourceTableConfig_PrimaryKey);
            }
            context.SourceTableConfig_RecordUpdateField = this.SourceTableConfig_RecordUpdateField;
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetTableConfig_PartitionSpec != null)
            {
                context.TargetTableConfig_PartitionSpec = new List<Amazon.Glue.Model.IntegrationPartition>(this.TargetTableConfig_PartitionSpec);
            }
            context.TargetTableConfig_TargetTableName = this.TargetTableConfig_TargetTableName;
            context.TargetTableConfig_UnnestSpec = this.TargetTableConfig_UnnestSpec;
            
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
            var request = new Amazon.Glue.Model.CreateIntegrationTablePropertiesRequest();
            
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
             // populate SourceTableConfig
            var requestSourceTableConfigIsNull = true;
            request.SourceTableConfig = new Amazon.Glue.Model.SourceTableConfig();
            List<System.String> requestSourceTableConfig_sourceTableConfig_Field = null;
            if (cmdletContext.SourceTableConfig_Field != null)
            {
                requestSourceTableConfig_sourceTableConfig_Field = cmdletContext.SourceTableConfig_Field;
            }
            if (requestSourceTableConfig_sourceTableConfig_Field != null)
            {
                request.SourceTableConfig.Fields = requestSourceTableConfig_sourceTableConfig_Field;
                requestSourceTableConfigIsNull = false;
            }
            System.String requestSourceTableConfig_sourceTableConfig_FilterPredicate = null;
            if (cmdletContext.SourceTableConfig_FilterPredicate != null)
            {
                requestSourceTableConfig_sourceTableConfig_FilterPredicate = cmdletContext.SourceTableConfig_FilterPredicate;
            }
            if (requestSourceTableConfig_sourceTableConfig_FilterPredicate != null)
            {
                request.SourceTableConfig.FilterPredicate = requestSourceTableConfig_sourceTableConfig_FilterPredicate;
                requestSourceTableConfigIsNull = false;
            }
            List<System.String> requestSourceTableConfig_sourceTableConfig_PrimaryKey = null;
            if (cmdletContext.SourceTableConfig_PrimaryKey != null)
            {
                requestSourceTableConfig_sourceTableConfig_PrimaryKey = cmdletContext.SourceTableConfig_PrimaryKey;
            }
            if (requestSourceTableConfig_sourceTableConfig_PrimaryKey != null)
            {
                request.SourceTableConfig.PrimaryKey = requestSourceTableConfig_sourceTableConfig_PrimaryKey;
                requestSourceTableConfigIsNull = false;
            }
            System.String requestSourceTableConfig_sourceTableConfig_RecordUpdateField = null;
            if (cmdletContext.SourceTableConfig_RecordUpdateField != null)
            {
                requestSourceTableConfig_sourceTableConfig_RecordUpdateField = cmdletContext.SourceTableConfig_RecordUpdateField;
            }
            if (requestSourceTableConfig_sourceTableConfig_RecordUpdateField != null)
            {
                request.SourceTableConfig.RecordUpdateField = requestSourceTableConfig_sourceTableConfig_RecordUpdateField;
                requestSourceTableConfigIsNull = false;
            }
             // determine if request.SourceTableConfig should be set to null
            if (requestSourceTableConfigIsNull)
            {
                request.SourceTableConfig = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
             // populate TargetTableConfig
            var requestTargetTableConfigIsNull = true;
            request.TargetTableConfig = new Amazon.Glue.Model.TargetTableConfig();
            List<Amazon.Glue.Model.IntegrationPartition> requestTargetTableConfig_targetTableConfig_PartitionSpec = null;
            if (cmdletContext.TargetTableConfig_PartitionSpec != null)
            {
                requestTargetTableConfig_targetTableConfig_PartitionSpec = cmdletContext.TargetTableConfig_PartitionSpec;
            }
            if (requestTargetTableConfig_targetTableConfig_PartitionSpec != null)
            {
                request.TargetTableConfig.PartitionSpec = requestTargetTableConfig_targetTableConfig_PartitionSpec;
                requestTargetTableConfigIsNull = false;
            }
            System.String requestTargetTableConfig_targetTableConfig_TargetTableName = null;
            if (cmdletContext.TargetTableConfig_TargetTableName != null)
            {
                requestTargetTableConfig_targetTableConfig_TargetTableName = cmdletContext.TargetTableConfig_TargetTableName;
            }
            if (requestTargetTableConfig_targetTableConfig_TargetTableName != null)
            {
                request.TargetTableConfig.TargetTableName = requestTargetTableConfig_targetTableConfig_TargetTableName;
                requestTargetTableConfigIsNull = false;
            }
            Amazon.Glue.UnnestSpec requestTargetTableConfig_targetTableConfig_UnnestSpec = null;
            if (cmdletContext.TargetTableConfig_UnnestSpec != null)
            {
                requestTargetTableConfig_targetTableConfig_UnnestSpec = cmdletContext.TargetTableConfig_UnnestSpec;
            }
            if (requestTargetTableConfig_targetTableConfig_UnnestSpec != null)
            {
                request.TargetTableConfig.UnnestSpec = requestTargetTableConfig_targetTableConfig_UnnestSpec;
                requestTargetTableConfigIsNull = false;
            }
             // determine if request.TargetTableConfig should be set to null
            if (requestTargetTableConfigIsNull)
            {
                request.TargetTableConfig = null;
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
        
        private Amazon.Glue.Model.CreateIntegrationTablePropertiesResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateIntegrationTablePropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateIntegrationTableProperties");
            try
            {
                return client.CreateIntegrationTablePropertiesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceArn { get; set; }
            public List<System.String> SourceTableConfig_Field { get; set; }
            public System.String SourceTableConfig_FilterPredicate { get; set; }
            public List<System.String> SourceTableConfig_PrimaryKey { get; set; }
            public System.String SourceTableConfig_RecordUpdateField { get; set; }
            public System.String TableName { get; set; }
            public List<Amazon.Glue.Model.IntegrationPartition> TargetTableConfig_PartitionSpec { get; set; }
            public System.String TargetTableConfig_TargetTableName { get; set; }
            public Amazon.Glue.UnnestSpec TargetTableConfig_UnnestSpec { get; set; }
            public System.Func<Amazon.Glue.Model.CreateIntegrationTablePropertiesResponse, NewGLUEIntegrationTablePropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
