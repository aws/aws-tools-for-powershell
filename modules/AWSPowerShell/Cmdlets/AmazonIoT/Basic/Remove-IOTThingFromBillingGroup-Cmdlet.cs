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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Removes the given thing from the billing group.
    /// </summary>
    [Cmdlet("Remove", "IOTThingFromBillingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS IoT RemoveThingFromBillingGroup API operation.", Operation = new[] {"RemoveThingFromBillingGroup"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ThingArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.RemoveThingFromBillingGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveIOTThingFromBillingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter BillingGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the billing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BillingGroupArn { get; set; }
        #endregion
        
        #region Parameter BillingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the billing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BillingGroupName { get; set; }
        #endregion
        
        #region Parameter ThingArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the thing to be removed from the billing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ThingArn { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the thing to be removed from the billing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ThingArn parameter.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTThingFromBillingGroup (RemoveThingFromBillingGroup)"))
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
            
            context.BillingGroupArn = this.BillingGroupArn;
            context.BillingGroupName = this.BillingGroupName;
            context.ThingArn = this.ThingArn;
            context.ThingName = this.ThingName;
            
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
            var request = new Amazon.IoT.Model.RemoveThingFromBillingGroupRequest();
            
            if (cmdletContext.BillingGroupArn != null)
            {
                request.BillingGroupArn = cmdletContext.BillingGroupArn;
            }
            if (cmdletContext.BillingGroupName != null)
            {
                request.BillingGroupName = cmdletContext.BillingGroupName;
            }
            if (cmdletContext.ThingArn != null)
            {
                request.ThingArn = cmdletContext.ThingArn;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
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
                    pipelineOutput = this.ThingArn;
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
        
        private Amazon.IoT.Model.RemoveThingFromBillingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.RemoveThingFromBillingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "RemoveThingFromBillingGroup");
            try
            {
                #if DESKTOP
                return client.RemoveThingFromBillingGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RemoveThingFromBillingGroupAsync(request);
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
            public System.String BillingGroupArn { get; set; }
            public System.String BillingGroupName { get; set; }
            public System.String ThingArn { get; set; }
            public System.String ThingName { get; set; }
        }
        
    }
}
