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
    /// Creates a new snapshot schedule.
    /// </summary>
    [Cmdlet("New", "RSSnapshotSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.CreateSnapshotScheduleResponse")]
    [AWSCmdlet("Calls the Amazon Redshift CreateSnapshotSchedule API operation.", Operation = new[] {"CreateSnapshotSchedule"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.CreateSnapshotScheduleResponse",
        "This cmdlet returns a Amazon.Redshift.Model.CreateSnapshotScheduleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRSSnapshotScheduleCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DryRun { get; set; }
        #endregion
        
        #region Parameter NextInvocation
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextInvocations")]
        public System.Int32 NextInvocation { get; set; }
        #endregion
        
        #region Parameter ScheduleDefinition
        /// <summary>
        /// <para>
        /// <para>The definition of the snapshot schedule. The definition is made up of schedule expressions,
        /// for example "cron(30 12 *)" or "rate(12 hours)". </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ScheduleDefinitions")]
        public System.String[] ScheduleDefinition { get; set; }
        #endregion
        
        #region Parameter ScheduleDescription
        /// <summary>
        /// <para>
        /// <para>The description of the snapshot schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ScheduleDescription { get; set; }
        #endregion
        
        #region Parameter ScheduleIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a snapshot schedule. Only alphanumeric characters are allowed
        /// for the identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ScheduleIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSSnapshotSchedule (CreateSnapshotSchedule)"))
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
            
            if (ParameterWasBound("DryRun"))
                context.DryRun = this.DryRun;
            if (ParameterWasBound("NextInvocation"))
                context.NextInvocations = this.NextInvocation;
            if (this.ScheduleDefinition != null)
            {
                context.ScheduleDefinitions = new List<System.String>(this.ScheduleDefinition);
            }
            context.ScheduleDescription = this.ScheduleDescription;
            context.ScheduleIdentifier = this.ScheduleIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Redshift.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Redshift.Model.CreateSnapshotScheduleRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.NextInvocations != null)
            {
                request.NextInvocations = cmdletContext.NextInvocations.Value;
            }
            if (cmdletContext.ScheduleDefinitions != null)
            {
                request.ScheduleDefinitions = cmdletContext.ScheduleDefinitions;
            }
            if (cmdletContext.ScheduleDescription != null)
            {
                request.ScheduleDescription = cmdletContext.ScheduleDescription;
            }
            if (cmdletContext.ScheduleIdentifier != null)
            {
                request.ScheduleIdentifier = cmdletContext.ScheduleIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
        
        private Amazon.Redshift.Model.CreateSnapshotScheduleResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateSnapshotScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateSnapshotSchedule");
            try
            {
                #if DESKTOP
                return client.CreateSnapshotSchedule(request);
                #elif CORECLR
                return client.CreateSnapshotScheduleAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.Int32? NextInvocations { get; set; }
            public List<System.String> ScheduleDefinitions { get; set; }
            public System.String ScheduleDescription { get; set; }
            public System.String ScheduleIdentifier { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tags { get; set; }
        }
        
    }
}
