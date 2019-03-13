/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon Redshift ModifySnapshotSchedule API operation.", Operation = new[] {"ModifySnapshotSchedule"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ModifySnapshotScheduleResponse",
        "This cmdlet returns a Amazon.Redshift.Model.ModifySnapshotScheduleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSSnapshotScheduleCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ScheduleDefinition
        /// <summary>
        /// <para>
        /// <para>An updated list of schedule definitions. A schedule definition is made up of schedule
        /// expressions, for example, "cron(30 12 *)" or "rate(12 hours)".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ScheduleDefinitions")]
        public System.String[] ScheduleDefinition { get; set; }
        #endregion
        
        #region Parameter ScheduleIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique alphanumeric identifier of the schedule to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ScheduleIdentifier { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ScheduleIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSSnapshotSchedule (ModifySnapshotSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.ScheduleDefinition != null)
            {
                context.ScheduleDefinitions = new List<System.String>(this.ScheduleDefinition);
            }
            context.ScheduleIdentifier = this.ScheduleIdentifier;
            
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
            
            if (cmdletContext.ScheduleDefinitions != null)
            {
                request.ScheduleDefinitions = cmdletContext.ScheduleDefinitions;
            }
            if (cmdletContext.ScheduleIdentifier != null)
            {
                request.ScheduleIdentifier = cmdletContext.ScheduleIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public List<System.String> ScheduleDefinitions { get; set; }
            public System.String ScheduleIdentifier { get; set; }
        }
        
    }
}
