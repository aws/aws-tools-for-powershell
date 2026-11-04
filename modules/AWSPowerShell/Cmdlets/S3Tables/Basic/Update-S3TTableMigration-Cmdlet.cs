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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Requests a state change for a migration. Identify the migration by its <c>migrationId</c>
    /// or by the <c>tableARN</c> of its destination table.
    /// 
    ///  
    /// <para>
    /// Set <c>requestedState</c> to <c>queued</c> to continue a migration in the <c>pendingReview</c>
    /// state; the migration moves to <c>queued</c> or <c>migrating</c>. Set it to <c>cancelled</c>
    /// to cancel a migration in the <c>new</c>, <c>planning</c>, <c>pendingReview</c>, <c>queued</c>
    /// or <c>migrating</c> state; the migration moves to <c>cancelling</c>, finishes the
    /// work in progress, and then ends in the <c>cancelled</c> state, or in the <c>failed</c>
    /// state if any objects failed to migrate. Data that the migration already committed
    /// stays in the destination table.
    /// </para><dl><dt>Permissions</dt><dd><ul><li><para>
    /// You must have the <c>s3tables:UpdateTableMigration</c> permission to use this operation.
    /// </para></li></ul></dd></dl>
    /// </summary>
    [Cmdlet("Update", "S3TTableMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Tables.Model.UpdateTableMigrationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables UpdateTableMigration API operation.", Operation = new[] {"UpdateTableMigration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.UpdateTableMigrationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.UpdateTableMigrationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.UpdateTableMigrationResponse object containing multiple properties."
    )]
    public partial class UpdateS3TTableMigrationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MigrationId
        /// <summary>
        /// <para>
        /// <para>The ID of the migration to update. Specify either <c>migrationId</c> or <c>tableARN</c>,
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationId { get; set; }
        #endregion
        
        #region Parameter RequestedState
        /// <summary>
        /// <para>
        /// <para>The state to move the migration to: <c>queued</c> to continue a migration in the <c>pendingReview</c>
        /// state, or <c>cancelled</c> to cancel a migration in the <c>new</c>, <c>planning</c>,
        /// <c>pendingReview</c>, <c>queued</c> or <c>migrating</c> state.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Tables.MigrationRequestedState")]
        public Amazon.S3Tables.MigrationRequestedState RequestedState { get; set; }
        #endregion
        
        #region Parameter TableARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination table. Updates the table's most
        /// recent migration. Until the migration creates the destination table, specify <c>migrationId</c>.
        /// Specify either <c>tableARN</c> or <c>migrationId</c>, not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableARN { get; set; }
        #endregion
        
        #region Parameter UpdateDescription
        /// <summary>
        /// <para>
        /// <para>A description of the update, up to 1,024 characters, with no control characters. <c>GetTableMigration</c>
        /// doesn't return it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateDescription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.UpdateTableMigrationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.UpdateTableMigrationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RequestedState), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3TTableMigration (UpdateTableMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.UpdateTableMigrationResponse, UpdateS3TTableMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MigrationId = this.MigrationId;
            context.RequestedState = this.RequestedState;
            #if MODULAR
            if (this.RequestedState == null && ParameterWasBound(nameof(this.RequestedState)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestedState which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableARN = this.TableARN;
            context.UpdateDescription = this.UpdateDescription;
            
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
            var request = new Amazon.S3Tables.Model.UpdateTableMigrationRequest();
            
            if (cmdletContext.MigrationId != null)
            {
                request.MigrationId = cmdletContext.MigrationId;
            }
            if (cmdletContext.RequestedState != null)
            {
                request.RequestedState = cmdletContext.RequestedState;
            }
            if (cmdletContext.TableARN != null)
            {
                request.TableARN = cmdletContext.TableARN;
            }
            if (cmdletContext.UpdateDescription != null)
            {
                request.UpdateDescription = cmdletContext.UpdateDescription;
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
        
        private Amazon.S3Tables.Model.UpdateTableMigrationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.UpdateTableMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "UpdateTableMigration");
            try
            {
                return client.UpdateTableMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MigrationId { get; set; }
            public Amazon.S3Tables.MigrationRequestedState RequestedState { get; set; }
            public System.String TableARN { get; set; }
            public System.String UpdateDescription { get; set; }
            public System.Func<Amazon.S3Tables.Model.UpdateTableMigrationResponse, UpdateS3TTableMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
