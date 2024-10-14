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
    /// Create a snapshot schedule that can be associated to a cluster and which overrides
    /// the default system backup schedule.
    /// </summary>
    [Cmdlet("New", "RSSnapshotSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.CreateSnapshotScheduleResponse")]
    [AWSCmdlet("Calls the Amazon Redshift CreateSnapshotSchedule API operation.", Operation = new[] {"CreateSnapshotSchedule"}, SelectReturnType = typeof(Amazon.Redshift.Model.CreateSnapshotScheduleResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.CreateSnapshotScheduleResponse",
        "This cmdlet returns an Amazon.Redshift.Model.CreateSnapshotScheduleResponse object containing multiple properties."
    )]
    public partial class NewRSSnapshotScheduleCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter NextInvocation
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextInvocations")]
        public System.Int32? NextInvocation { get; set; }
        #endregion
        
        #region Parameter ScheduleDefinition
        /// <summary>
        /// <para>
        /// <para>The definition of the snapshot schedule. The definition is made up of schedule expressions,
        /// for example "cron(30 12 *)" or "rate(12 hours)". </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleDefinitions")]
        public System.String[] ScheduleDefinition { get; set; }
        #endregion
        
        #region Parameter ScheduleDescription
        /// <summary>
        /// <para>
        /// <para>The description of the snapshot schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleDescription { get; set; }
        #endregion
        
        #region Parameter ScheduleIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a snapshot schedule. Only alphanumeric characters are allowed
        /// for the identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ScheduleIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional set of tags you can use to search for the schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CreateSnapshotScheduleResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CreateSnapshotScheduleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScheduleIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScheduleIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScheduleIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduleIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSSnapshotSchedule (CreateSnapshotSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CreateSnapshotScheduleResponse, NewRSSnapshotScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScheduleIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            context.NextInvocation = this.NextInvocation;
            if (this.ScheduleDefinition != null)
            {
                context.ScheduleDefinition = new List<System.String>(this.ScheduleDefinition);
            }
            context.ScheduleDescription = this.ScheduleDescription;
            context.ScheduleIdentifier = this.ScheduleIdentifier;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Redshift.Model.Tag>(this.Tag);
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
            if (cmdletContext.NextInvocation != null)
            {
                request.NextInvocations = cmdletContext.NextInvocation.Value;
            }
            if (cmdletContext.ScheduleDefinition != null)
            {
                request.ScheduleDefinitions = cmdletContext.ScheduleDefinition;
            }
            if (cmdletContext.ScheduleDescription != null)
            {
                request.ScheduleDescription = cmdletContext.ScheduleDescription;
            }
            if (cmdletContext.ScheduleIdentifier != null)
            {
                request.ScheduleIdentifier = cmdletContext.ScheduleIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            public System.Int32? NextInvocation { get; set; }
            public List<System.String> ScheduleDefinition { get; set; }
            public System.String ScheduleDescription { get; set; }
            public System.String ScheduleIdentifier { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Redshift.Model.CreateSnapshotScheduleResponse, NewRSSnapshotScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
