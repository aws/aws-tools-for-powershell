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
    /// Saves your converted code to a file as a SQL script, and stores this file on your
    /// Amazon S3 bucket.
    /// </summary>
    [Cmdlet("Start", "DMSMetadataModelExportAsScript", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Database Migration Service StartMetadataModelExportAsScript API operation.", Operation = new[] {"StartMetadataModelExportAsScript"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse))]
    [AWSCmdletOutput("System.String or Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDMSMetadataModelExportAsScriptCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para>The name of the model file to create in the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileName { get; set; }
        #endregion
        
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
        
        #region Parameter Origin
        /// <summary>
        /// <para>
        /// <para>Whether to export the metadata model from the source or the target.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.OriginTypeValue")]
        public Amazon.DatabaseMigrationService.OriginTypeValue Origin { get; set; }
        #endregion
        
        #region Parameter SelectionRule
        /// <summary>
        /// <para>
        /// <para>A value that specifies the database objects to export.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DMSMetadataModelExportAsScript (StartMetadataModelExportAsScript)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse, StartDMSMetadataModelExportAsScriptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileName = this.FileName;
            context.MigrationProjectIdentifier = this.MigrationProjectIdentifier;
            #if MODULAR
            if (this.MigrationProjectIdentifier == null && ParameterWasBound(nameof(this.MigrationProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Origin = this.Origin;
            #if MODULAR
            if (this.Origin == null && ParameterWasBound(nameof(this.Origin)))
            {
                WriteWarning("You are passing $null as a value for parameter Origin which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptRequest();
            
            if (cmdletContext.FileName != null)
            {
                request.FileName = cmdletContext.FileName;
            }
            if (cmdletContext.MigrationProjectIdentifier != null)
            {
                request.MigrationProjectIdentifier = cmdletContext.MigrationProjectIdentifier;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origin = cmdletContext.Origin;
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
        
        private Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "StartMetadataModelExportAsScript");
            try
            {
                return client.StartMetadataModelExportAsScriptAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FileName { get; set; }
            public System.String MigrationProjectIdentifier { get; set; }
            public Amazon.DatabaseMigrationService.OriginTypeValue Origin { get; set; }
            public System.String SelectionRule { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.StartMetadataModelExportAsScriptResponse, StartDMSMetadataModelExportAsScriptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestIdentifier;
        }
        
    }
}
