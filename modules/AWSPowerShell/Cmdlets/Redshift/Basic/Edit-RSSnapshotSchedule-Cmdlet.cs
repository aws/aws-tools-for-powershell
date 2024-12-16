/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Modifies a snapshot schedule. Any schedule associated with a cluster is modified asynchronously.
    /// </summary>
    [Cmdlet("Edit", "RSSnapshotSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ModifySnapshotScheduleResponse")]
    [AWSCmdlet("Calls the Amazon Redshift ModifySnapshotSchedule API operation.", Operation = new[] {"ModifySnapshotSchedule"}, SelectReturnType = typeof(Amazon.Redshift.Model.ModifySnapshotScheduleResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.ModifySnapshotScheduleResponse",
        "This cmdlet returns an Amazon.Redshift.Model.ModifySnapshotScheduleResponse object containing multiple properties."
    )]
    public partial class EditRSSnapshotScheduleCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ScheduleDefinition
        /// <summary>
        /// <para>
        /// <para>An updated list of schedule definitions. A schedule definition is made up of schedule
        /// expressions, for example, "cron(30 12 *)" or "rate(12 hours)".</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ScheduleDefinitions")]
        public System.String[] ScheduleDefinition { get; set; }
        #endregion
        
        #region Parameter ScheduleIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique alphanumeric identifier of the schedule to modify.</para>
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
        public System.String ScheduleIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.ModifySnapshotScheduleResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.ModifySnapshotScheduleResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduleIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSSnapshotSchedule (ModifySnapshotSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.ModifySnapshotScheduleResponse, EditRSSnapshotScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ScheduleDefinition != null)
            {
                context.ScheduleDefinition = new List<System.String>(this.ScheduleDefinition);
            }
            #if MODULAR
            if (this.ScheduleDefinition == null && ParameterWasBound(nameof(this.ScheduleDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleIdentifier = this.ScheduleIdentifier;
            #if MODULAR
            if (this.ScheduleIdentifier == null && ParameterWasBound(nameof(this.ScheduleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.ModifySnapshotScheduleRequest();
            
            if (cmdletContext.ScheduleDefinition != null)
            {
                request.ScheduleDefinitions = cmdletContext.ScheduleDefinition;
            }
            if (cmdletContext.ScheduleIdentifier != null)
            {
                request.ScheduleIdentifier = cmdletContext.ScheduleIdentifier;
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
        
        private Amazon.Redshift.Model.ModifySnapshotScheduleResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifySnapshotScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifySnapshotSchedule");
            try
            {
                #if DESKTOP
                return client.ModifySnapshotSchedule(request);
                #elif CORECLR
                return client.ModifySnapshotScheduleAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ScheduleDefinition { get; set; }
            public System.String ScheduleIdentifier { get; set; }
            public System.Func<Amazon.Redshift.Model.ModifySnapshotScheduleResponse, EditRSSnapshotScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
