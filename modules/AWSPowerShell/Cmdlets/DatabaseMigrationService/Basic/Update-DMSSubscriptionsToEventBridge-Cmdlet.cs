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
    /// Migrates 10 active and enabled Amazon SNS subscriptions at a time and converts them
    /// to corresponding Amazon EventBridge rules. By default, this operation migrates subscriptions
    /// only when all your replication instance versions are 3.4.5 or higher. If any replication
    /// instances are from versions earlier than 3.4.5, the operation raises an error and
    /// tells you to upgrade these instances to version 3.4.5 or higher. To enable migration
    /// regardless of version, set the <c>Force</c> option to true. However, if you don't
    /// upgrade instances earlier than version 3.4.5, some types of events might not be available
    /// when you use Amazon EventBridge.
    /// 
    ///  
    /// <para>
    /// To call this operation, make sure that you have certain permissions added to your
    /// user account. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Events.html#CHAP_Events-migrate-to-eventbridge">Migrating
    /// event subscriptions to Amazon EventBridge</a> in the <i>Amazon Web Services Database
    /// Migration Service User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DMSSubscriptionsToEventBridge", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Database Migration Service UpdateSubscriptionsToEventBridge API operation.", Operation = new[] {"UpdateSubscriptionsToEventBridge"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse))]
    [AWSCmdletOutput("System.String or Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDMSSubscriptionsToEventBridgeCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ForceMove
        /// <summary>
        /// <para>
        /// <para>When set to true, this operation migrates DMS subscriptions for Amazon SNS notifications
        /// no matter what your replication instance version is. If not set or set to false, this
        /// operation runs only when all your replication instances are from DMS version 3.4.5
        /// or higher. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? ForceMove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Result'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Result";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ForceMove), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DMSSubscriptionsToEventBridge (UpdateSubscriptionsToEventBridge)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse, UpdateDMSSubscriptionsToEventBridgeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ForceMove = this.ForceMove;
            
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
            var request = new Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeRequest();
            
            if (cmdletContext.ForceMove != null)
            {
                request.ForceMove = cmdletContext.ForceMove.Value;
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
        
        private Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "UpdateSubscriptionsToEventBridge");
            try
            {
                return client.UpdateSubscriptionsToEventBridgeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ForceMove { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.UpdateSubscriptionsToEventBridgeResponse, UpdateDMSSubscriptionsToEventBridgeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Result;
        }
        
    }
}
