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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Adds additional customer communication to an AWS Support case. You use the <code>caseId</code>
    /// value to identify the case to add communication to. You can list a set of email addresses
    /// to copy on the communication using the <code>ccEmailAddresses</code> value. The <code>communicationBody</code>
    /// value contains the text of the communication.
    /// 
    ///  
    /// <para>
    /// The response indicates the success or failure of the request.
    /// </para><para>
    /// This operation implements a subset of the features of the AWS Support Center.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "ASACommunicationToCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Invokes the AddCommunicationToCase operation against AWS Support API.", Operation = new[] {"AddCommunicationToCase"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.AWSSupport.Model.AddCommunicationToCaseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddASACommunicationToCaseCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        #region Parameter AttachmentSetId
        /// <summary>
        /// <para>
        /// <para>The ID of a set of one or more attachments for the communication to add to the case.
        /// Create the set by calling <a>AddAttachmentsToSet</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AttachmentSetId { get; set; }
        #endregion
        
        #region Parameter CaseId
        /// <summary>
        /// <para>
        /// <para>The AWS Support case ID requested or returned in the call. The case ID is an alphanumeric
        /// string formatted as shown in this example: case-<i>12345678910-2013-c4c1d2bf33c5cf47</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CaseId { get; set; }
        #endregion
        
        #region Parameter CcEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email addresses in the CC line of an email to be added to the support case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("CcEmailAddresses")]
        public System.String[] CcEmailAddress { get; set; }
        #endregion
        
        #region Parameter CommunicationBody
        /// <summary>
        /// <para>
        /// <para>The body of an email communication to add to the support case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String CommunicationBody { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CaseId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ASACommunicationToCase (AddCommunicationToCase)"))
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
            
            context.AttachmentSetId = this.AttachmentSetId;
            context.CaseId = this.CaseId;
            if (this.CcEmailAddress != null)
            {
                context.CcEmailAddresses = new List<System.String>(this.CcEmailAddress);
            }
            context.CommunicationBody = this.CommunicationBody;
            
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
            var request = new Amazon.AWSSupport.Model.AddCommunicationToCaseRequest();
            
            if (cmdletContext.AttachmentSetId != null)
            {
                request.AttachmentSetId = cmdletContext.AttachmentSetId;
            }
            if (cmdletContext.CaseId != null)
            {
                request.CaseId = cmdletContext.CaseId;
            }
            if (cmdletContext.CcEmailAddresses != null)
            {
                request.CcEmailAddresses = cmdletContext.CcEmailAddresses;
            }
            if (cmdletContext.CommunicationBody != null)
            {
                request.CommunicationBody = cmdletContext.CommunicationBody;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Result;
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
        
        private static Amazon.AWSSupport.Model.AddCommunicationToCaseResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.AddCommunicationToCaseRequest request)
        {
            #if DESKTOP
            return client.AddCommunicationToCase(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddCommunicationToCaseAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AttachmentSetId { get; set; }
            public System.String CaseId { get; set; }
            public List<System.String> CcEmailAddresses { get; set; }
            public System.String CommunicationBody { get; set; }
        }
        
    }
}
