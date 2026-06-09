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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Gets information about a specific Autonomous Database backup.
    /// </summary>
    [Cmdlet("Get", "ODBAutonomousDatabaseBackup")]
    [OutputType("Amazon.Odb.Model.AutonomousDatabaseBackup")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services GetAutonomousDatabaseBackup API operation.", Operation = new[] {"GetAutonomousDatabaseBackup"}, SelectReturnType = typeof(Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.AutonomousDatabaseBackup or Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse",
        "This cmdlet returns an Amazon.Odb.Model.AutonomousDatabaseBackup object.",
        "The service call response (type Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetODBAutonomousDatabaseBackupCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutonomousDatabaseBackupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Autonomous Database backup to retrieve information about.</para>
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
        public System.String AutonomousDatabaseBackupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutonomousDatabaseBackup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutonomousDatabaseBackup";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse, GetODBAutonomousDatabaseBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutonomousDatabaseBackupId = this.AutonomousDatabaseBackupId;
            #if MODULAR
            if (this.AutonomousDatabaseBackupId == null && ParameterWasBound(nameof(this.AutonomousDatabaseBackupId)))
            {
                WriteWarning("You are passing $null as a value for parameter AutonomousDatabaseBackupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Odb.Model.GetAutonomousDatabaseBackupRequest();
            
            if (cmdletContext.AutonomousDatabaseBackupId != null)
            {
                request.AutonomousDatabaseBackupId = cmdletContext.AutonomousDatabaseBackupId;
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
        
        private Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.GetAutonomousDatabaseBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "GetAutonomousDatabaseBackup");
            try
            {
                return client.GetAutonomousDatabaseBackupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AutonomousDatabaseBackupId { get; set; }
            public System.Func<Amazon.Odb.Model.GetAutonomousDatabaseBackupResponse, GetODBAutonomousDatabaseBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutonomousDatabaseBackup;
        }
        
    }
}
