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

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Populates the schema for the specified endpoint. This is an asynchronous operation
    /// and can take several minutes. You can check the status of this operation by calling
    /// the DescribeRefreshSchemasStatus operation.
    /// </summary>
    [Cmdlet("Invoke", "DMSSchemaRefresh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.RefreshSchemasStatus")]
    [AWSCmdlet("Calls the AWS Database Migration Service RefreshSchemas API operation.", Operation = new[] {"RefreshSchemas"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.RefreshSchemasStatus or Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.RefreshSchemasStatus object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeDMSSchemaRefreshCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) string that uniquely identifies the endpoint.</para>
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
        public System.String EndpointArn { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the replication instance.</para>
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
        public System.String ReplicationInstanceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RefreshSchemasStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RefreshSchemasStatus";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-DMSSchemaRefresh (RefreshSchemas)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse, InvokeDMSSchemaRefreshCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndpointArn = this.EndpointArn;
            #if MODULAR
            if (this.EndpointArn == null && ParameterWasBound(nameof(this.EndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationInstanceArn = this.ReplicationInstanceArn;
            #if MODULAR
            if (this.ReplicationInstanceArn == null && ParameterWasBound(nameof(this.ReplicationInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.RefreshSchemasRequest();
            
            if (cmdletContext.EndpointArn != null)
            {
                request.EndpointArn = cmdletContext.EndpointArn;
            }
            if (cmdletContext.ReplicationInstanceArn != null)
            {
                request.ReplicationInstanceArn = cmdletContext.ReplicationInstanceArn;
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
        
        private Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.RefreshSchemasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "RefreshSchemas");
            try
            {
                return client.RefreshSchemasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EndpointArn { get; set; }
            public System.String ReplicationInstanceArn { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.RefreshSchemasResponse, InvokeDMSSchemaRefreshCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RefreshSchemasStatus;
        }
        
    }
}
