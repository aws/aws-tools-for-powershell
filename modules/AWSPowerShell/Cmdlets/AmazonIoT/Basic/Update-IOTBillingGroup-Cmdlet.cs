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
    /// Updates information about the billing group.
    /// </summary>
    [Cmdlet("Update", "IOTBillingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the AWS IoT UpdateBillingGroup API operation.", Operation = new[] {"UpdateBillingGroup"})]
    [AWSCmdletOutput("System.Int64",
        "This cmdlet returns a Int64 object.",
        "The service call response (type Amazon.IoT.Model.UpdateBillingGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTBillingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter BillingGroupProperties_BillingGroupDescription
        /// <summary>
        /// <para>
        /// <para>The description of the billing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BillingGroupProperties_BillingGroupDescription { get; set; }
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
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the billing group. If the version of the billing group does
        /// not match the expected version specified in the request, the <code>UpdateBillingGroup</code>
        /// request is rejected with a <code>VersionConflictException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ExpectedVersion { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BillingGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTBillingGroup (UpdateBillingGroup)"))
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
            
            context.BillingGroupName = this.BillingGroupName;
            context.BillingGroupProperties_BillingGroupDescription = this.BillingGroupProperties_BillingGroupDescription;
            if (ParameterWasBound("ExpectedVersion"))
                context.ExpectedVersion = this.ExpectedVersion;
            
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
            var request = new Amazon.IoT.Model.UpdateBillingGroupRequest();
            
            if (cmdletContext.BillingGroupName != null)
            {
                request.BillingGroupName = cmdletContext.BillingGroupName;
            }
            
             // populate BillingGroupProperties
            bool requestBillingGroupPropertiesIsNull = true;
            request.BillingGroupProperties = new Amazon.IoT.Model.BillingGroupProperties();
            System.String requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription = null;
            if (cmdletContext.BillingGroupProperties_BillingGroupDescription != null)
            {
                requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription = cmdletContext.BillingGroupProperties_BillingGroupDescription;
            }
            if (requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription != null)
            {
                request.BillingGroupProperties.BillingGroupDescription = requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription;
                requestBillingGroupPropertiesIsNull = false;
            }
             // determine if request.BillingGroupProperties should be set to null
            if (requestBillingGroupPropertiesIsNull)
            {
                request.BillingGroupProperties = null;
            }
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Version;
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
        
        private Amazon.IoT.Model.UpdateBillingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateBillingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateBillingGroup");
            try
            {
                #if DESKTOP
                return client.UpdateBillingGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateBillingGroupAsync(request);
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
            public System.String BillingGroupName { get; set; }
            public System.String BillingGroupProperties_BillingGroupDescription { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
        }
        
    }
}
