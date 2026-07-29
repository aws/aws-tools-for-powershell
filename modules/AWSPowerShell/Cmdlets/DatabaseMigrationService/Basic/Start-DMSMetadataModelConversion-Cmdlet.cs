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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Queues a conversion of the selected source metadata models (database objects such
    /// as tables, views, and procedures) to the target database format. If other requests
    /// created by <c>Start*</c> operations are already in the migration project's queue,
    /// the conversion begins after they complete.
    /// 
    ///  
    /// <para>
    /// The conversion request loads metadata models that are not yet in the metadata tree,
    /// but does not reload metadata models that are already present. If your source database
    /// has changed since the metadata was loaded, refresh the affected metadata models with
    /// <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_StartMetadataModelImport.html">StartMetadataModelImport</a>
    /// before calling this operation.
    /// </para><note><para>
    /// If converted objects already exist in the target metadata tree, the conversion overwrites
    /// them, including any manual edits.
    /// </para></note><para>
    /// To check the status of the conversion request, call <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_DescribeMetadataModelConversions.html">DescribeMetadataModelConversions</a>
    /// using the returned <c>RequestIdentifier</c> as a filter.
    /// </para><para>
    /// To cancel a queued or in-progress request, call <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_CancelMetadataModelConversion.html">CancelMetadataModelConversion</a>
    /// with the returned <c>RequestIdentifier</c>.
    /// </para><para>
    /// After the conversion completes successfully:
    /// </para><ul><li><para>
    /// To export a post-conversion assessment report, call <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_ExportMetadataModelAssessment.html">ExportMetadataModelAssessment</a>.
    /// </para></li><li><para>
    /// To retrieve converted code, use any of the following options:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_DescribeMetadataModel.html">DescribeMetadataModel</a>
    /// and <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_DescribeMetadataModelChildren.html">DescribeMetadataModelChildren</a>
    /// – navigate the target metadata tree and retrieve converted definitions.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_StartMetadataModelExportAsScript.html">StartMetadataModelExportAsScript</a>
    /// – export as data definition language (DDL) scripts to your Amazon S3 bucket.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_StartMetadataModelExportToTarget.html">StartMetadataModelExportToTarget</a>
    /// – apply directly to your target database.
    /// </para></li></ul></li></ul><para><b>Required permissions:</b><c>dms:StartMetadataModelConversion</c>. For more information,
    /// see <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsdatabasemigrationservice.html">Actions,
    /// resources, and condition keys for Database Migration Service</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "DMSMetadataModelConversion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Database Migration Service StartMetadataModelConversion API operation.", Operation = new[] {"StartMetadataModelConversion"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse))]
    [AWSCmdletOutput("System.String or Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDMSMetadataModelConversionCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MigrationProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The migration project name or Amazon Resource Name (ARN).</para>
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
        public System.String MigrationProjectIdentifier { get; set; }
        #endregion
        
        #region Parameter SelectionRule
        /// <summary>
        /// <para>
        /// <para>A JSON string that identifies the metadata models to convert. For the selection rule
        /// format and examples, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/sc-selection-rules.html">Selection
        /// rules in DMS Schema Conversion</a>.</para><para>Usage:</para><ul><li><para>Accepts only source selection rules, where <c>server-name</c> in the object locator
        /// matches the source data provider.</para></li><li><para>Supports <c>explicit</c>, <c>include</c>, and <c>exclude</c> rule actions.</para></li></ul>
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
        [Alias("SelectionRules")]
        public System.String SelectionRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RequestIdentifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RequestIdentifier";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MigrationProjectIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DMSMetadataModelConversion (StartMetadataModelConversion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse, StartDMSMetadataModelConversionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MigrationProjectIdentifier = this.MigrationProjectIdentifier;
            #if MODULAR
            if (this.MigrationProjectIdentifier == null && ParameterWasBound(nameof(this.MigrationProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SelectionRule = this.SelectionRule;
            #if MODULAR
            if (this.SelectionRule == null && ParameterWasBound(nameof(this.SelectionRule)))
            {
                WriteWarning("You are passing $null as a value for parameter SelectionRule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionRequest();
            
            if (cmdletContext.MigrationProjectIdentifier != null)
            {
                request.MigrationProjectIdentifier = cmdletContext.MigrationProjectIdentifier;
            }
            if (cmdletContext.SelectionRule != null)
            {
                request.SelectionRules = cmdletContext.SelectionRule;
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
        
        private Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "StartMetadataModelConversion");
            try
            {
                return client.StartMetadataModelConversionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MigrationProjectIdentifier { get; set; }
            public System.String SelectionRule { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.StartMetadataModelConversionResponse, StartDMSMetadataModelConversionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestIdentifier;
        }
        
    }
}
