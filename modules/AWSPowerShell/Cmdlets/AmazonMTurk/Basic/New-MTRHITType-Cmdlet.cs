/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>CreateHITType</code> operation creates a new HIT type. This operation allows
    /// you to define a standard set of HIT properties to use when creating HITs. If you register
    /// a HIT type with values that match an existing HIT type, the HIT type ID of the existing
    /// type will be returned.
    /// </summary>
    [Cmdlet("New", "MTRHITType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateHITType operation against Amazon MTurk Service.", Operation = new[] {"CreateHITType"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MTurk.Model.CreateHITTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMTRHITTypeCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter AssignmentDurationInSecond
        /// <summary>
        /// <para>
        /// <para> The amount of time, in seconds, that a Worker has to complete the HIT after accepting
        /// it. If a Worker does not complete the assignment within the specified duration, the
        /// assignment is considered abandoned. If the HIT is still active (that is, its lifetime
        /// has not elapsed), the assignment becomes available for other users to find and accept.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AssignmentDurationInSeconds")]
        public System.Int64 AssignmentDurationInSecond { get; set; }
        #endregion
        
        #region Parameter AutoApprovalDelayInSecond
        /// <summary>
        /// <para>
        /// <para> The number of seconds after an assignment for the HIT has been submitted, after which
        /// the assignment is considered Approved automatically unless the Requester explicitly
        /// rejects it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoApprovalDelayInSeconds")]
        public System.Int64 AutoApprovalDelayInSecond { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A general description of the HIT. A description includes detailed information about
        /// the kind of task the HIT contains. On the Amazon Mechanical Turk web site, the HIT
        /// description appears in the expanded view of search results, and in the HIT and assignment
        /// screens. A good description gives the user enough information to evaluate the HIT
        /// before accepting it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para> One or more words or phrases that describe the HIT, separated by commas. These words
        /// are used in searches to find HITs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Keywords")]
        public System.String Keyword { get; set; }
        #endregion
        
        #region Parameter QualificationRequirement
        /// <summary>
        /// <para>
        /// <para> A condition that a Worker's Qualifications must meet before the Worker is allowed
        /// to accept and complete the HIT. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("QualificationRequirements")]
        public Amazon.MTurk.Model.QualificationRequirement[] QualificationRequirement { get; set; }
        #endregion
        
        #region Parameter Reward
        /// <summary>
        /// <para>
        /// <para> The amount of money the Requester will pay a Worker for successfully completing the
        /// HIT. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Reward { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para> The title of the HIT. A title should be short and descriptive about the kind of task
        /// the HIT contains. On the Amazon Mechanical Turk web site, the HIT title appears in
        /// search results, and everywhere the HIT is mentioned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Title { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Title", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MTRHITType (CreateHITType)"))
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
            
            if (ParameterWasBound("AssignmentDurationInSecond"))
                context.AssignmentDurationInSeconds = this.AssignmentDurationInSecond;
            if (ParameterWasBound("AutoApprovalDelayInSecond"))
                context.AutoApprovalDelayInSeconds = this.AutoApprovalDelayInSecond;
            context.Description = this.Description;
            context.Keywords = this.Keyword;
            if (this.QualificationRequirement != null)
            {
                context.QualificationRequirements = new List<Amazon.MTurk.Model.QualificationRequirement>(this.QualificationRequirement);
            }
            context.Reward = this.Reward;
            context.Title = this.Title;
            
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
            var request = new Amazon.MTurk.Model.CreateHITTypeRequest();
            
            if (cmdletContext.AssignmentDurationInSeconds != null)
            {
                request.AssignmentDurationInSeconds = cmdletContext.AssignmentDurationInSeconds.Value;
            }
            if (cmdletContext.AutoApprovalDelayInSeconds != null)
            {
                request.AutoApprovalDelayInSeconds = cmdletContext.AutoApprovalDelayInSeconds.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Keywords != null)
            {
                request.Keywords = cmdletContext.Keywords;
            }
            if (cmdletContext.QualificationRequirements != null)
            {
                request.QualificationRequirements = cmdletContext.QualificationRequirements;
            }
            if (cmdletContext.Reward != null)
            {
                request.Reward = cmdletContext.Reward;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HITTypeId;
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
        
        private Amazon.MTurk.Model.CreateHITTypeResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.CreateHITTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "CreateHITType");
            #if DESKTOP
            return client.CreateHITType(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateHITTypeAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Int64? AssignmentDurationInSeconds { get; set; }
            public System.Int64? AutoApprovalDelayInSeconds { get; set; }
            public System.String Description { get; set; }
            public System.String Keywords { get; set; }
            public List<Amazon.MTurk.Model.QualificationRequirement> QualificationRequirements { get; set; }
            public System.String Reward { get; set; }
            public System.String Title { get; set; }
        }
        
    }
}
