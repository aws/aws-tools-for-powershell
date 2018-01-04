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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>UpdateQualificationType</code> operation modifies the attributes of an
    /// existing Qualification type, which is represented by a QualificationType data structure.
    /// Only the owner of a Qualification type can modify its attributes. 
    /// 
    ///  
    /// <para>
    ///  Most attributes of a Qualification type can be changed after the type has been created.
    /// However, the Name and Keywords fields cannot be modified. The RetryDelayInSeconds
    /// parameter can be modified or added to change the delay or to enable retries, but RetryDelayInSeconds
    /// cannot be used to disable retries. 
    /// </para><para>
    ///  You can use this operation to update the test for a Qualification type. The test
    /// is updated based on the values specified for the Test, TestDurationInSeconds and AnswerKey
    /// parameters. All three parameters specify the updated test. If you are updating the
    /// test for a type, you must specify the Test and TestDurationInSeconds parameters. The
    /// AnswerKey parameter is optional; omitting it specifies that the updated test does
    /// not have an answer key. 
    /// </para><para>
    ///  If you omit the Test parameter, the test for the Qualification type is unchanged.
    /// There is no way to remove a test from a Qualification type that has one. If the type
    /// already has a test, you cannot update it to be AutoGranted. If the Qualification type
    /// does not have a test and one is provided by an update, the type will henceforth have
    /// a test. 
    /// </para><para>
    ///  If you want to update the test duration or answer key for an existing test without
    /// changing the questions, you must specify a Test parameter with the original questions,
    /// along with the updated values. 
    /// </para><para>
    ///  If you provide an updated Test but no AnswerKey, the new test will not have an answer
    /// key. Requests for such Qualifications must be granted manually. 
    /// </para><para>
    ///  You can also update the AutoGranted and AutoGrantedValue attributes of the Qualification
    /// type.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MTRQualificationType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MTurk.Model.QualificationType")]
    [AWSCmdlet("Calls the Amazon MTurk Service UpdateQualificationType API operation.", Operation = new[] {"UpdateQualificationType"})]
    [AWSCmdletOutput("Amazon.MTurk.Model.QualificationType",
        "This cmdlet returns a QualificationType object.",
        "The service call response (type Amazon.MTurk.Model.UpdateQualificationTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMTRQualificationTypeCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter AnswerKey
        /// <summary>
        /// <para>
        /// <para>The answers to the Qualification test specified in the Test parameter, in the form
        /// of an AnswerKey data structure.</para>
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
        /// <para>The new description of the Qualification type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter QualificationTypeId
        /// <summary>
        /// <para>
        /// <para>The ID of the Qualification type to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String QualificationTypeId { get; set; }
        #endregion
        
        #region Parameter QualificationTypeStatus
        /// <summary>
        /// <para>
        /// <para>The new status of the Qualification type - Active | Inactive</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MTurk.QualificationTypeStatus")]
        public Amazon.MTurk.QualificationTypeStatus QualificationTypeStatus { get; set; }
        #endregion
        
        #region Parameter RetryDelayInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that Workers must wait after requesting a Qualification
        /// of the specified Qualification type before they can retry the Qualification request.
        /// It is not possible to disable retries for a Qualification type after it has been created
        /// with retries enabled. If you want to disable retries, you must dispose of the existing
        /// retry-enabled Qualification type using DisposeQualificationType and then create a
        /// new Qualification type with retries disabled using CreateQualificationType.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetryDelayInSeconds")]
        public System.Int64 RetryDelayInSecond { get; set; }
        #endregion
        
        #region Parameter Test
        /// <summary>
        /// <para>
        /// <para>The questions for the Qualification test a Worker must answer correctly to obtain
        /// a Qualification of this type. If this parameter is specified, <code>TestDurationInSeconds</code>
        /// must also be specified.</para><para>Constraints: Must not be longer than 65535 bytes. Must be a QuestionForm data structure.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("QualificationTypeId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MTRQualificationType (UpdateQualificationType)"))
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
            context.QualificationTypeId = this.QualificationTypeId;
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
            var request = new Amazon.MTurk.Model.UpdateQualificationTypeRequest();
            
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
            if (cmdletContext.QualificationTypeId != null)
            {
                request.QualificationTypeId = cmdletContext.QualificationTypeId;
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
        
        private Amazon.MTurk.Model.UpdateQualificationTypeResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.UpdateQualificationTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "UpdateQualificationType");
            try
            {
                #if DESKTOP
                return client.UpdateQualificationType(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateQualificationTypeAsync(request);
                return task.Result;
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
            public System.String AnswerKey { get; set; }
            public System.Boolean? AutoGranted { get; set; }
            public System.Int32? AutoGrantedValue { get; set; }
            public System.String Description { get; set; }
            public System.String QualificationTypeId { get; set; }
            public Amazon.MTurk.QualificationTypeStatus QualificationTypeStatus { get; set; }
            public System.Int64? RetryDelayInSeconds { get; set; }
            public System.String Test { get; set; }
            public System.Int64? TestDurationInSeconds { get; set; }
        }
        
    }
}
