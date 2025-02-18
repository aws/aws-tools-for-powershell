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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Updates the permissions mode of a ledger.
    /// 
    ///  <important><para>
    /// Before you switch to the <c>STANDARD</c> permissions mode, you must first create all
    /// required IAM policies and table tags to avoid disruption to your users. To learn more,
    /// see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/ledger-management.basics.html#ledger-mgmt.basics.update-permissions.migrating">Migrating
    /// to the standard permissions mode</a> in the <i>Amazon QLDB Developer Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "QLDBLedgerPermissionsMode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse")]
    [AWSCmdlet("Calls the Amazon QLDB UpdateLedgerPermissionsMode API operation.", Operation = new[] {"UpdateLedgerPermissionsMode"}, SelectReturnType = typeof(Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse))]
    [AWSCmdletOutput("Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse",
        "This cmdlet returns an Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse object containing multiple properties."
    )]
    public partial class UpdateQLDBLedgerPermissionsModeCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the ledger.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PermissionsMode
        /// <summary>
        /// <para>
        /// <para>The permissions mode to assign to the ledger. This parameter can have one of the following
        /// values:</para><ul><li><para><c>ALLOW_ALL</c>: A legacy permissions mode that enables access control with API-level
        /// granularity for ledgers.</para><para>This mode allows users who have the <c>SendCommand</c> API permission for this ledger
        /// to run all PartiQL commands (hence, <c>ALLOW_ALL</c>) on any tables in the specified
        /// ledger. This mode disregards any table-level or command-level IAM permissions policies
        /// that you create for the ledger.</para></li><li><para><c>STANDARD</c>: (<i>Recommended</i>) A permissions mode that enables access control
        /// with finer granularity for ledgers, tables, and PartiQL commands.</para><para>By default, this mode denies all user requests to run any PartiQL commands on any
        /// tables in this ledger. To allow PartiQL commands to run, you must create IAM permissions
        /// policies for specific table resources and PartiQL actions, in addition to the <c>SendCommand</c>
        /// API permission for the ledger. For information, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/getting-started-standard-mode.html">Getting
        /// started with the standard permissions mode</a> in the <i>Amazon QLDB Developer Guide</i>.</para></li></ul><note><para>We strongly recommend using the <c>STANDARD</c> permissions mode to maximize the security
        /// of your ledger data.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QLDB.PermissionsMode")]
        public Amazon.QLDB.PermissionsMode PermissionsMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QLDBLedgerPermissionsMode (UpdateLedgerPermissionsMode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse, UpdateQLDBLedgerPermissionsModeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PermissionsMode = this.PermissionsMode;
            #if MODULAR
            if (this.PermissionsMode == null && ParameterWasBound(nameof(this.PermissionsMode)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionsMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QLDB.Model.UpdateLedgerPermissionsModeRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PermissionsMode != null)
            {
                request.PermissionsMode = cmdletContext.PermissionsMode;
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
        
        private Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.UpdateLedgerPermissionsModeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "UpdateLedgerPermissionsMode");
            try
            {
                return client.UpdateLedgerPermissionsModeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public Amazon.QLDB.PermissionsMode PermissionsMode { get; set; }
            public System.Func<Amazon.QLDB.Model.UpdateLedgerPermissionsModeResponse, UpdateQLDBLedgerPermissionsModeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
