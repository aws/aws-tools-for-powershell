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
    /// The <code>CreateQualificationType</code> operation creates a new Qualification type,
    /// which is represented by a <code>QualificationType</code> data structure.
    /// </summary>
    [Cmdlet("New", "MTRQualificationType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MTurk.Model.QualificationType")]
    [AWSCmdlet("Invokes the CreateQualificationType operation against Amazon MTurk Service.", Operation = new[] {"CreateQualificationType"})]
    [AWSCmdletOutput("Amazon.MTurk.Model.QualificationType",
        "This cmdlet returns a QualificationType object.",
        "The service call response (type Amazon.MTurk.Model.CreateQualificationTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMTRQualificationTypeCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter AnswerKey
        /// <summary>
        /// <para>
        /// <para>The answers to the Qualification test specified in the Test parameter, in the form
        /// of an AnswerKey data structure.</para><para>Constraints: Must not be longer than 65535 bytes.</para><para>Constraints: None. If not specified, you must process Qualification requests manually.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AnswerKey { get; set; }
        #endregion
        
        #region Parameter AutoGranted
        /// <summary>
        /// <para>
        /// <para>Specifies whether requests for the Qualification type are granted immediately, without
        /// prompting the Worker with a Qualification test.</para><para>Constraints: If the Test parameter is specified, this parameter cannot be true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoGranted { get; set; }
        #endregion
        
        #region Parameter AutoGrantedValue
        /// <summary>
        /// <para>
        /// <para>The Qualification value to use for automatically granted Qualifications. This parameter
        /// is used only if the AutoGranted parameter is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AutoGrantedValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A long description for the Qualification type. On the Amazon Mechanical Turk website,
        /// the long description is displayed when a Worker examines a Qualification type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para>One or more words or phrases that describe the Qualification type, separated by commas.
        /// The keywords of a type make the type easier to find during a search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Keywords")]
        public System.String Keyword { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name you give to the Qualification type. The type name is used to represent the
        /// Qualification to Workers, and to find the type using a Qualification type search.
        /// It must be unique across all of your Qualification types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter QualificationTypeStatus
        /// <summary>
        /// <para>
        /// <para>The initial status of the Qualification type.</para><para>Constraints: Valid values are: Active | Inactive</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MTurk.QualificationTypeStatus")]
        public Amazon.MTurk.QualificationTypeStatus QualificationTypeStatus { get; set; }
        #endregion
        
        #region Parameter RetryDelayInSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds that a Worker must wait after requesting a Qualification of
        /// the Qualification type before the worker can retry the Qualification request.</para><para>Constraints: None. If not specified, retries are disabled and Workers can request
        /// a Qualification of this type only once, even if the Worker has not been granted the
        /// Qualification. It is not possible to disable retries for a Qualification type after
        /// it has been created with retries enabled. If you want to disable retries, you must
        /// delete existing retry-enabled Qualification type and then create a new Qualification
        /// type with retries disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetryDelayInSeconds")]
        public System.Int64 RetryDelayInSecond { get; set; }
        #endregion
        
        #region Parameter Test
        /// <summary>
        /// <para>
        /// <para> The questions for the Qualification test a Worker must answer correctly to obtain
        /// a Qualification of this type. If this parameter is specified, <code>TestDurationInSeconds</code>
        /// must also be specified. </para><para>Constraints: Must not be longer than 65535 bytes. Must be a QuestionForm data structure.
        /// This parameter cannot be specified if AutoGranted is true.</para><para>Constraints: None. If not specified, the Worker may request the Qualification without
        /// answering any questions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Test { get; set; }
        #endregion
        
        #region Parameter TestDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds the Worker has to complete the Qualification test, starting
        /// from the time the Worker requests the Qualification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TestDurationInSeconds")]
        public System.Int64 TestDurationInSecond { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MTRQualificationType (CreateQualificationType)"))
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
            
            context.AnswerKey = this.AnswerKey;
            if (ParameterWasBound("AutoGranted"))
                context.AutoGranted = this.AutoGranted;
            if (ParameterWasBound("AutoGrantedValue"))
                context.AutoGrantedValue = this.AutoGrantedValue;
            context.Description = this.Description;
            context.Keywords = this.Keyword;
            context.Name = this.Name;
            context.QualificationTypeStatus = this.QualificationTypeStatus;
            if (ParameterWasBound("RetryDelayInSecond"))
                context.RetryDelayInSeconds = this.RetryDelayInSecond;
            context.Test = this.Test;
            if (ParameterWasBound("TestDurationInSecond"))
                context.TestDurationInSeconds = this.TestDurationInSecond;
            
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
            var request = new Amazon.MTurk.Model.CreateQualificationTypeRequest();
            
            if (cmdletContext.AnswerKey != null)
            {
                request.AnswerKey = cmdletContext.AnswerKey;
            }
            if (cmdletContext.AutoGranted != null)
            {
                request.AutoGranted = cmdletContext.AutoGranted.Value;
            }
            if (cmdletContext.AutoGrantedValue != null)
            {
                request.AutoGrantedValue = cmdletContext.AutoGrantedValue.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Keywords != null)
            {
                request.Keywords = cmdletContext.Keywords;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.QualificationTypeStatus != null)
            {
                request.QualificationTypeStatus = cmdletContext.QualificationTypeStatus;
            }
            if (cmdletContext.RetryDelayInSeconds != null)
            {
                request.RetryDelayInSeconds = cmdletContext.RetryDelayInSeconds.Value;
            }
            if (cmdletContext.Test != null)
            {
                request.Test = cmdletContext.Test;
            }
            if (cmdletContext.TestDurationInSeconds != null)
            {
                request.TestDurationInSeconds = cmdletContext.TestDurationInSeconds.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.QualificationType;
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
        
        private Amazon.MTurk.Model.CreateQualificationTypeResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.CreateQualificationTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "CreateQualificationType");
            #if DESKTOP
            return client.CreateQualificationType(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateQualificationTypeAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AnswerKey { get; set; }
            public System.Boolean? AutoGranted { get; set; }
            public System.Int32? AutoGrantedValue { get; set; }
            public System.String Description { get; set; }
            public System.String Keywords { get; set; }
            public System.String Name { get; set; }
            public Amazon.MTurk.QualificationTypeStatus QualificationTypeStatus { get; set; }
            public System.Int64? RetryDelayInSeconds { get; set; }
            public System.String Test { get; set; }
            public System.Int64? TestDurationInSeconds { get; set; }
        }
        
    }
}
