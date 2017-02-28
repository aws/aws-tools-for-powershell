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
    /// The <code>AssociateQualificationWithWorker</code> operation gives a Worker a Qualification.
    /// <code>AssociateQualificationWithWorker</code> does not require that the Worker submit
    /// a Qualification request. It gives the Qualification directly to the Worker. 
    /// 
    ///  
    /// <para>
    ///  You can only assign a Qualification of a Qualification type that you created (using
    /// the <code>CreateQualificationType</code> operation). 
    /// </para><note><para>
    ///  Note: <code>AssociateQualificationWithWorker</code> does not affect any pending Qualification
    /// requests for the Qualification by the Worker. If you assign a Qualification to a Worker,
    /// then later grant a Qualification request made by the Worker, the granting of the request
    /// may modify the Qualification score. To resolve a pending Qualification request without
    /// affecting the Qualification the Worker already has, reject the request with the <code>RejectQualificationRequest</code>
    /// operation. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "MTRQualificationToWorker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the AssociateQualificationWithWorker operation against Amazon MTurk Service.", Operation = new[] {"AssociateQualificationWithWorker"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the WorkerId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.MTurk.Model.AssociateQualificationWithWorkerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddMTRQualificationToWorkerCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter IntegerValue
        /// <summary>
        /// <para>
        /// <para>The value of the Qualification to assign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 IntegerValue { get; set; }
        #endregion
        
        #region Parameter QualificationTypeId
        /// <summary>
        /// <para>
        /// <para>The ID of the Qualification type to use for the assigned Qualification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String QualificationTypeId { get; set; }
        #endregion
        
        #region Parameter SendNotification
        /// <summary>
        /// <para>
        /// <para> Specifies whether to send a notification email message to the Worker saying that
        /// the qualification was assigned to the Worker. Note: this is true by default. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SendNotification { get; set; }
        #endregion
        
        #region Parameter WorkerId
        /// <summary>
        /// <para>
        /// <para> The ID of the Worker to whom the Qualification is being assigned. Worker IDs are
        /// included with submitted HIT assignments and Qualification requests. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String WorkerId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the WorkerId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("WorkerId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-MTRQualificationToWorker (AssociateQualificationWithWorker)"))
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
            
            if (ParameterWasBound("IntegerValue"))
                context.IntegerValue = this.IntegerValue;
            context.QualificationTypeId = this.QualificationTypeId;
            if (ParameterWasBound("SendNotification"))
                context.SendNotification = this.SendNotification;
            context.WorkerId = this.WorkerId;
            
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
            var request = new Amazon.MTurk.Model.AssociateQualificationWithWorkerRequest();
            
            if (cmdletContext.IntegerValue != null)
            {
                request.IntegerValue = cmdletContext.IntegerValue.Value;
            }
            if (cmdletContext.QualificationTypeId != null)
            {
                request.QualificationTypeId = cmdletContext.QualificationTypeId;
            }
            if (cmdletContext.SendNotification != null)
            {
                request.SendNotification = cmdletContext.SendNotification.Value;
            }
            if (cmdletContext.WorkerId != null)
            {
                request.WorkerId = cmdletContext.WorkerId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.WorkerId;
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
        
        private static Amazon.MTurk.Model.AssociateQualificationWithWorkerResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.AssociateQualificationWithWorkerRequest request)
        {
            #if DESKTOP
            return client.AssociateQualificationWithWorker(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AssociateQualificationWithWorkerAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? IntegerValue { get; set; }
            public System.String QualificationTypeId { get; set; }
            public System.Boolean? SendNotification { get; set; }
            public System.String WorkerId { get; set; }
        }
        
    }
}
