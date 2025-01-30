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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Cancels a single premigration assessment run.
    /// 
    ///  
    /// <para>
    /// This operation prevents any individual assessments from running if they haven't started
    /// running. It also attempts to cancel any individual assessments that are currently
    /// running.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "DMSReplicationTaskAssessmentRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationTaskAssessmentRun")]
    [AWSCmdlet("Calls the AWS Database Migration Service CancelReplicationTaskAssessmentRun API operation.", Operation = new[] {"CancelReplicationTaskAssessmentRun"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationTaskAssessmentRun or Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.ReplicationTaskAssessmentRun object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopDMSReplicationTaskAssessmentRunCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReplicationTaskAssessmentRunArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the premigration assessment run to be canceled.</para>
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
        public System.String ReplicationTaskAssessmentRunArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationTaskAssessmentRun'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationTaskAssessmentRun";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReplicationTaskAssessmentRunArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReplicationTaskAssessmentRunArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReplicationTaskAssessmentRunArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationTaskAssessmentRunArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-DMSReplicationTaskAssessmentRun (CancelReplicationTaskAssessmentRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse, StopDMSReplicationTaskAssessmentRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReplicationTaskAssessmentRunArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ReplicationTaskAssessmentRunArn = this.ReplicationTaskAssessmentRunArn;
            #if MODULAR
            if (this.ReplicationTaskAssessmentRunArn == null && ParameterWasBound(nameof(this.ReplicationTaskAssessmentRunArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationTaskAssessmentRunArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunRequest();
            
            if (cmdletContext.ReplicationTaskAssessmentRunArn != null)
            {
                request.ReplicationTaskAssessmentRunArn = cmdletContext.ReplicationTaskAssessmentRunArn;
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
        
        private Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CancelReplicationTaskAssessmentRun");
            try
            {
                #if DESKTOP
                return client.CancelReplicationTaskAssessmentRun(request);
                #elif CORECLR
                return client.CancelReplicationTaskAssessmentRunAsync(request).GetAwaiter().GetResult();
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
            public System.String ReplicationTaskAssessmentRunArn { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.CancelReplicationTaskAssessmentRunResponse, StopDMSReplicationTaskAssessmentRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationTaskAssessmentRun;
        }
        
    }
}
