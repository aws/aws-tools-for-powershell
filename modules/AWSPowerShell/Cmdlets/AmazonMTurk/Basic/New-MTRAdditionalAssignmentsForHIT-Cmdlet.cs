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
    /// The <code>CreateAdditionalAssignmentsForHIT</code> operation increases the maximum
    /// number of assignments of an existing HIT. 
    /// 
    ///  
    /// <para>
    ///  To extend the maximum number of assignments, specify the number of additional assignments.
    /// </para><note><ul><li><para>
    /// HITs created with fewer than 10 assignments cannot be extended to have 10 or more
    /// assignments. Attempting to add assignments in a way that brings the total number of
    /// assignments for a HIT from fewer than 10 assignments to 10 or more assignments will
    /// result in an <code>AWS.MechanicalTurk.InvalidMaximumAssignmentsIncrease</code> exception.
    /// </para></li><li><para>
    /// HITs that were created before July 22, 2015 cannot be extended. Attempting to extend
    /// HITs that were created before July 22, 2015 will result in an <code>AWS.MechanicalTurk.HITTooOldForExtension</code>
    /// exception. 
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "MTRAdditionalAssignmentsForHIT", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the CreateAdditionalAssignmentsForHIT operation against Amazon MTurk Service.", Operation = new[] {"CreateAdditionalAssignmentsForHIT"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMTRAdditionalAssignmentsForHITCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter HITId
        /// <summary>
        /// <para>
        /// <para>The ID of the HIT to extend.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HITId { get; set; }
        #endregion
        
        #region Parameter NumberOfAdditionalAssignment
        /// <summary>
        /// <para>
        /// <para>The number of additional assignments to request for this HIT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NumberOfAdditionalAssignments")]
        public System.Int32 NumberOfAdditionalAssignment { get; set; }
        #endregion
        
        #region Parameter UniqueRequestToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for this request, which allows you to retry the call on error
        /// without extending the HIT multiple times. This is useful in cases such as network
        /// timeouts where it is unclear whether or not the call succeeded on the server. If the
        /// extend HIT already exists in the system from a previous call using the same <code>UniqueRequestToken</code>,
        /// subsequent calls will return an error with a message containing the request ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UniqueRequestToken { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HITId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MTRAdditionalAssignmentsForHIT (CreateAdditionalAssignmentsForHIT)"))
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
            
            context.HITId = this.HITId;
            if (ParameterWasBound("NumberOfAdditionalAssignment"))
                context.NumberOfAdditionalAssignments = this.NumberOfAdditionalAssignment;
            context.UniqueRequestToken = this.UniqueRequestToken;
            
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
            var request = new Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITRequest();
            
            if (cmdletContext.HITId != null)
            {
                request.HITId = cmdletContext.HITId;
            }
            if (cmdletContext.NumberOfAdditionalAssignments != null)
            {
                request.NumberOfAdditionalAssignments = cmdletContext.NumberOfAdditionalAssignments.Value;
            }
            if (cmdletContext.UniqueRequestToken != null)
            {
                request.UniqueRequestToken = cmdletContext.UniqueRequestToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.CreateAdditionalAssignmentsForHITRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "CreateAdditionalAssignmentsForHIT");
            #if DESKTOP
            return client.CreateAdditionalAssignmentsForHIT(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateAdditionalAssignmentsForHITAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String HITId { get; set; }
            public System.Int32? NumberOfAdditionalAssignments { get; set; }
            public System.String UniqueRequestToken { get; set; }
        }
        
    }
}
