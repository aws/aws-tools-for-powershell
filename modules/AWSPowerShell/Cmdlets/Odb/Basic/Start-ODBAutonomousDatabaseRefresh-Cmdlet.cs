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
    /// Starts a refresh of the specified refreshable clone Autonomous Database with data
    /// from its source database. The refresh runs asynchronously. To track its progress,
    /// check the <c>refreshableStatus</c> of the Autonomous Database.
    /// </summary>
    [Cmdlet("Start", "ODBAutonomousDatabaseRefresh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse")]
    [AWSCmdlet("Calls the odb StartAutonomousDatabaseRefresh API operation.", Operation = new[] {"StartAutonomousDatabaseRefresh"}, SelectReturnType = typeof(Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse",
        "This cmdlet returns an Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse object containing multiple properties."
    )]
    public partial class StartODBAutonomousDatabaseRefreshCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutonomousDatabaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the refreshable clone Autonomous Database to refresh.</para>
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
        public System.String AutonomousDatabaseId { get; set; }
        #endregion
        
        #region Parameter TimeOfRefreshCutoff
        /// <summary>
        /// <para>
        /// <para>The date and time up to which the refreshable clone Autonomous Database is refreshed
        /// from its source database. Data committed on the source database after this time isn't
        /// applied to the refreshable clone. The time must be at least 1 minute and at most 7
        /// days in the past, and later than the clone's last refresh point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeOfRefreshCutoff { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutonomousDatabaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ODBAutonomousDatabaseRefresh (StartAutonomousDatabaseRefresh)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse, StartODBAutonomousDatabaseRefreshCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutonomousDatabaseId = this.AutonomousDatabaseId;
            #if MODULAR
            if (this.AutonomousDatabaseId == null && ParameterWasBound(nameof(this.AutonomousDatabaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter AutonomousDatabaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeOfRefreshCutoff = this.TimeOfRefreshCutoff;
            
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
            var request = new Amazon.Odb.Model.StartAutonomousDatabaseRefreshRequest();
            
            if (cmdletContext.AutonomousDatabaseId != null)
            {
                request.AutonomousDatabaseId = cmdletContext.AutonomousDatabaseId;
            }
            if (cmdletContext.TimeOfRefreshCutoff != null)
            {
                request.TimeOfRefreshCutoff = cmdletContext.TimeOfRefreshCutoff.Value;
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
        
        private Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.StartAutonomousDatabaseRefreshRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "odb", "StartAutonomousDatabaseRefresh");
            try
            {
                return client.StartAutonomousDatabaseRefreshAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AutonomousDatabaseId { get; set; }
            public System.DateTime? TimeOfRefreshCutoff { get; set; }
            public System.Func<Amazon.Odb.Model.StartAutonomousDatabaseRefreshResponse, StartODBAutonomousDatabaseRefreshCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
